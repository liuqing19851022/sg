using Orleans.Concurrency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.DTO.Tool.Bulk.Respond
{
    /// <summary>
    /// 响应开始执行批量数据
    /// </summary>
    [DataContract]
    [Immutable]
    [Serializable]
    public class RespondBeginBulkDTO
    {
        /// <summary>
        /// 批量执行编号
        /// </summary>
        [DataMember]
        public string BulkID { get; set; }
    }
}
