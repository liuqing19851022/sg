using Nest;

using Npgsql;

namespace PushPgToES.Imps
{
    public class PgSqlPushToEs : absPushDbToEs
    {

        private readonly string connStr;



        public PgSqlPushToEs(IConfiguration configuration, ElasticClient esClient, ILogger<absPushDbToEs> logger) : base(esClient, logger)
        {
            this.connStr = configuration.GetConnectionString("PgSql")!;
        }





        public override async Task PublishAllTable(string dbName, string tabName)
        {

            try
            {
                var sql = $"SELECT \"DataID\",\"StateJson\" FROM \"{tabName}\"";
                base.logger.LogWarning(sql);
                using var conn = new NpgsqlConnection(this.connStr);

                await conn.OpenAsync();
                await conn.ChangeDatabaseAsync(dbName);
                using var cmd = new NpgsqlCommand(sql, conn);

                using var dr = cmd.ExecuteReader();
                //Type keyType = dr.GetFieldType(0);
                //this.logger.LogInformation(keyType.FullName);


                await CommitBulkData(dr, dbName, tabName);

                //JTokenType keyType = JTokenType.None;



                //while (dr.Read())
                //{
                //    var json = dr.GetString(1);


                //    var jobj = JObject.Parse(json);

                //    #region 建立索引

                //    if (keyType == JTokenType.None)
                //    {

                //        //建立索引 ?;

                //        if (jobj.ContainsKey("DataVersion"))
                //        {
                //            throw new Exception("不存在 DataVersion 字段");
                //        }

                //        var id = jobj["ID"] as JValue;
                //        if (id == null)
                //        {
                //            return;
                //        }

                //        keyType = id.Type;
                //        switch (keyType)
                //        {
                //            case JTokenType.String:

                //                break;
                //            case JTokenType.Integer:

                //                break;
                //            default:

                //                throw new Exception($"不支持的主键类型{keyType.ToString()}");
                //        }
                //    }

                //    #endregion

                //    var dataVer = jobj["DataVersion"];

                //    #region 批量提交




                //    #endregion
                //}

            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.GetBaseException().Message, ex);
            }




        }

        protected override async Task<List<string>> GetAllDataBases()
        {
            var dbList = new List<string>();
            using (var conn = new NpgsqlConnection(this.connStr))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("SELECT datname FROM pg_database", conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var dbName = dr.GetString(0);

                            dbList.Add(dbName);
                        }
                    }
                }
            }
            return dbList;

        }

        protected override async Task<List<string>> GetAllTables(string dbName)
        {
            this.logger.LogInformation($" get {dbName} tables");
            var tabList = new List<string>();

            using (var conn = new NpgsqlConnection(this.connStr))
            {
                await conn.OpenAsync();
                await conn.ChangeDatabaseAsync(dbName);

                using (var cmd = new NpgsqlCommand("SELECT table_name FROM information_schema.tables WHERE table_schema='public'", conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tabList.Add(dr.GetString(0));
                        }
                    }
                }
            }
            return tabList;
        }
    }
}
