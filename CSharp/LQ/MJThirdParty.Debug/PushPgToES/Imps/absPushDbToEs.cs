using System.Data;

using Elasticsearch.Net;

using Nest;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using PushPgToES.DTO;
using PushPgToES.Interfaces;

namespace PushPgToES.Imps
{
    public abstract class absPushDbToEs : IPushDbToEs
    {

        const int BulkCommitSize = 1000;
        private readonly ElasticClient esClient;
        protected readonly ILogger logger;
        public absPushDbToEs(ElasticClient esClient, ILogger<absPushDbToEs> logger)
        {
            this.esClient = esClient;
            this.logger = logger;
        }

        public async Task PublishAll()
        {
            foreach (var db in await this.GetAllDataBases())
            {
                if (!db.StartsWith("mj_", StringComparison.CurrentCultureIgnoreCase))
                    continue;
                await this.PublishAllDataBase(db);

            }
        }

        public async Task PublishAllDataBase(string dbName)
        {
            foreach (var tab in await this.GetAllTables(dbName))
            {
                //跳过MetaData
                if (tab.EndsWith("MetaData"))
                    continue;

                await this.PublishAllTable(dbName, tab);
            }
        }

        public abstract Task PublishAllTable(string dbName, string tabName);
        /// <summary>
        /// 获取某个库内全部表
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        protected abstract Task<List<string>> GetAllTables(string dbName);

        /// <summary>
        /// 获取服务器上 全部的数据表
        /// </summary>
        /// <returns></returns>
        protected abstract Task<List<string>> GetAllDataBases();


        private string GetAlias(string dbName, string tabName)
        {
            //Replace("mj_", "").
            return $"{dbName.ToLower()}_{tabName.ToLower()}";
        }

        protected async Task CommitBulkData(IDataReader dr, string dbName, string tabName)
        {
            var jsonDataList = new List<string>();
            int count = 0;
            string alias = GetAlias(dbName, tabName);
            bool createIndex = false;
            while (dr.Read())
            {
                var json = dr.GetString(1);

                if (!createIndex)
                {
                    await CreateIndex(json, alias);
                    createIndex = true;
                }

                jsonDataList.Add(JObject.FromObject(new BulkCommitDataItem
                {
                    Index = new BulkCommitDataIndexItem
                    {
                        Alias = alias,
                        ID = dr.GetString(0)
                    }
                }).ToString(Formatting.None));
                jsonDataList.Add(dr.GetString(1));


                count++;

                if (count >= BulkCommitSize)
                {
                    await CommitBulkData(jsonDataList);
                    jsonDataList.Clear();
                    count = 0;
                }

            }

            await CommitBulkData(jsonDataList);

        }

        private async Task<bool> CommitBulkData(List<string> jsonDataList)
        {
            if (jsonDataList.Count == 0)
                return true;

            var postData = PostData.MultiJson(jsonDataList);
            var respond = await esClient.LowLevel.BulkAsync<VoidResponse>(postData);

            return respond.Success;
        }



        private PropertiesDescriptor<object> GenerateMappingFromJson(PropertiesDescriptor<object> properties, JObject jsonObject)
        {
            foreach (var property in jsonObject.Properties())
            {
                var propertyName = property.Name;
                var propertyValue = property.Value;

                properties = AddProperty(properties, propertyName, propertyValue);
            }

            return properties;
        }

        private PropertiesDescriptor<object> AddProperty(PropertiesDescriptor<object> properties, string propertyName, JToken value)
        {
            switch (value.Type)
            {
                case JTokenType.String:
                    properties = properties.Text(t => t.Name(propertyName));
                    break;
                case JTokenType.Integer:
                    properties = properties.Number(n => n.Name(propertyName).Type(NumberType.Integer));
                    break;
                case JTokenType.Float:
                    properties = properties.Number(n => n.Name(propertyName).Type(NumberType.Float));
                    break;
                case JTokenType.Boolean:
                    properties = properties.Boolean(b => b.Name(propertyName));
                    break;
                case JTokenType.Array:
                    properties = properties.Nested<object>(n => n
                        .Name(propertyName)
                        .Properties(np => InferArrayType(np, (JArray)value))
                    );
                    break;
                case JTokenType.Object:
                    properties = properties.Object<object>(o => o
                        .Name(propertyName)
                        .Properties(ps => GenerateMappingFromJson(ps, (JObject)value))
                    );
                    break;
                default:
                    properties = properties.Text(t => t.Name(propertyName));
                    break;
            }

            return properties;
        }

        private PropertiesDescriptor<object> InferArrayType(PropertiesDescriptor<object> properties, JArray array)
        {
            if (array.Count == 0)
            {
                return properties;
            }

            // Assume all elements in the array are of the same type, using the first element
            var firstElement = array.First;

            switch (firstElement.Type)
            {
                case JTokenType.String:
                    properties = properties.Text(t => t.Name("value"));
                    break;
                case JTokenType.Integer:
                    properties = properties.Number(n => n.Name("value").Type(NumberType.Integer));
                    break;
                case JTokenType.Float:
                    properties = properties.Number(n => n.Name("value").Type(NumberType.Float));
                    break;
                case JTokenType.Boolean:
                    properties = properties.Boolean(b => b.Name("value"));
                    break;
                case JTokenType.Object:
                    properties = GenerateMappingFromJson(properties, (JObject)firstElement);
                    break;
                default:
                    properties = properties.Text(t => t.Name("value"));
                    break;
            }

            return properties;
        }


        protected async Task<bool> CreateIndex(string json, string indexName)
        {

            var jObj = JObject.Parse(json);

            if (!jObj.ContainsKey("ID"))
            {
                this.logger.LogError($"{indexName} 没有 ID ");
                return false;
            }

            await this.esClient.Indices.DeleteAsync(indexName);
            var createIndexResponse = await this.esClient.Indices.CreateAsync(indexName, c => c
                .Map<object>(m => m
                    .AutoMap()
                    .Properties(ps => GenerateMappingFromJson(ps, jObj))
                )
                .Aliases(x => x.Alias(indexName + "_alias"))
                .Settings(s => s.RefreshInterval(new Time(TimeSpan.FromSeconds(1))))
            );

            return createIndexResponse.IsValid;

        }
    }
}
