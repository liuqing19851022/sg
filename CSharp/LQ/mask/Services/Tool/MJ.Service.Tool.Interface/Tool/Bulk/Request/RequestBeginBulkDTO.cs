using Orleans.Concurrency;
using System;
using System.Runtime.Serialization;

namespace MJ.Service.Tool.DTO.Tool.Bulk.Request
{
    /// <summary>
    /// 开始执行批量数据
    /// </summary>
    [DataContract]
    [Immutable]
    [Serializable]
    public class RequestBeginBulkDTO
    {
        /// <summary>
        /// 批量执行编号
        /// </summary>
        [DataMember]
        public string BulkID { get; set; }
    }
}
