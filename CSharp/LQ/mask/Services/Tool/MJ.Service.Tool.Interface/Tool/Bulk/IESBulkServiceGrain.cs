using MJ.Service.Tool.DTO.Tool.Bulk.Request;
using MJ.Service.Tool.DTO.Tool.Bulk.Respond;
using MJUSS.Infrastructure.Core.BaseClass;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Interface.Tool
{
    public interface IESBulkServiceGrain : IGrainWithStringKey
    {
        /// <summary>
        /// 开始批量数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RespondData<RespondBeginBulkDTO>> BeginBulk(RequestData<RequestBeginBulkDTO> request);
        /// <summary>
        /// 增加批量数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RespondData<RespondAddBulkDataDTO>> AddBulkData(RequestData<RequestAddBulkDataDTO> request);
        /// <summary>
        /// 提交批量数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RespondData<RespondCommitBulkDataDTO>> CommitBulkData(RequestData<RequestCommitBulkDataDTO> request);
    }
}
