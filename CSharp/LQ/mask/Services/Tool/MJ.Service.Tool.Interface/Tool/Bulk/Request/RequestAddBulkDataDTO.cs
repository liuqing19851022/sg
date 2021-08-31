using Orleans.Concurrency;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MJ.Service.Tool.DTO.Tool.Bulk.Request
{
    /// <summary>
    /// 请求增加批量数据
    /// </summary>
    [DataContract]
    [Immutable]
    [Serializable]
    public class RequestAddBulkDataDTO
    {
        /// <summary>
        /// 批量执行编号
        /// </summary>
        [DataMember]
        public string BulkID { get; set; }
        /// <summary>
        /// 批量数据列表
        /// </summary>
        [DataMember]
        public List<BulkIndexData> BulkIndexDataList { get; set; } = new List<BulkIndexData>();
    }
}
