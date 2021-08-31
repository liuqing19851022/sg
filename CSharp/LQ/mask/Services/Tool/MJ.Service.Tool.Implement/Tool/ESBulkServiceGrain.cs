using Elasticsearch.Net;
using MJ.Service.Tool.DTO.Tool.Bulk;
using MJ.Service.Tool.DTO.Tool.Bulk.Request;
using MJ.Service.Tool.DTO.Tool.Bulk.Respond;
using MJ.Service.Tool.Interface.Tool;
using MJUSS.Infrastructure.Core.BaseClass;
using MJUSS.Infrastructure.Core.Error;
using MJUSS.Infrastructure.Core.Exceptions;
using MJUSS.Infrastructure.Utils.Extentions;
using MJUSS.Infrastructure.Utils.Helper;
using Newtonsoft.Json.Linq;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Implement.Tool
{
    public partial class ESBulkServiceGrain : Grain, IESBulkServiceGrain
    {
        private List<BulkIndexData> bulkIndexDataList;
        private string id;
        private IEsClientFactory esClientFactory;
        public ESBulkServiceGrain(IEsClientFactory esClientFactory)
        {
            this.esClientFactory = esClientFactory;
        }
        public override Task OnActivateAsync()
        {
            id = this.GetPrimaryKeyString();
            bulkIndexDataList = new List<BulkIndexData>();
            return base.OnActivateAsync();
        }

        public Task<RespondData<RespondBeginBulkDTO>> BeginBulk(RequestData<RequestBeginBulkDTO> request)
        {
            var result = new RespondBeginBulkDTO();
            result.BulkID = id;
            bulkIndexDataList.Clear();
            return Task.FromResult(new RespondData<RespondBeginBulkDTO>(result));
        }

        public Task<RespondData<RespondAddBulkDataDTO>> AddBulkData(RequestData<RequestAddBulkDataDTO> request)
        {
            bulkIndexDataList.AddRange(request.Data.BulkIndexDataList);
            return Task.FromResult(new RespondData<RespondAddBulkDataDTO>(new RespondAddBulkDataDTO()));
        }

        public async Task<RespondData<RespondCommitBulkDataDTO>> CommitBulkData(RequestData<RequestCommitBulkDataDTO> request)
        {
            if (bulkIndexDataList.Count == 0)
            {
                return new RespondData<RespondCommitBulkDataDTO>(new RespondCommitBulkDataDTO());
            }
            var elasticClient = esClientFactory.CreateElasticClient();

            List<string> jsonDataList = new List<string>();
            foreach (var item in bulkIndexDataList)
            {
                var dataJObject = JObject.Parse(item.Data);
                JObject indexObject = new JObject();
                indexObject["index"] = new JObject();
                indexObject["index"]["_index"] = item.IndexName;
                indexObject["index"]["_type"] = item.TypeName;
                indexObject["index"]["_id"] = dataJObject["ID"].Value<string>();
                jsonDataList.Add(indexObject.ToString(Newtonsoft.Json.Formatting.None));
                jsonDataList.Add(await GetFirstKeyCharToLower(dataJObject));
            }
            var postData = PostData.MultiJson(jsonDataList);
            var respondData = await elasticClient.LowLevel.BulkAsync<VoidResponse>(postData);
            if (!respondData.Success)
            {
                throw new BaseValidationException(MJErrorCode.ValidationError.ErrorCode, respondData.OriginalException.ToString());
            }
            foreach (var indexDataGrainBase in bulkIndexDataList)
            {
                if (string.IsNullOrEmpty(indexDataGrainBase.DataID)
                    || indexDataGrainBase.IndexDataGrain == null)
                {
                    continue;
                }
                await indexDataGrainBase.IndexDataGrain.CommitState();
            }
            DeactivateOnIdle();
            return new RespondData<RespondCommitBulkDataDTO>(new RespondCommitBulkDataDTO());
        }

        private Task<string> GetFirstKeyCharToLower(JObject data)
        {
            var result = new JObject();
            foreach (var item in data)
            {
                result[item.Key.LowerFirst()] = item.Value;
            }
            return Task.FromResult(result.ToString(Newtonsoft.Json.Formatting.None));
        }
    }
}
