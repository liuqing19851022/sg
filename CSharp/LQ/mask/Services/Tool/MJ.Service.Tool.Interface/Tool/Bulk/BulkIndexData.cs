using MJ.Service.Tool.Interface.Tool;
using Orleans.Concurrency;
using System;
using System.Runtime.Serialization;

namespace MJ.Service.Tool.DTO.Tool.Bulk
{
    /// <summary>
    /// 批量数据
    /// </summary>
    [DataContract]
    [Immutable]
    [Serializable]
    public class BulkIndexData
    {
        /// <summary>
        /// 索引名称
        /// </summary>
        [DataMember]
        public string IndexName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public string TypeName { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        [DataMember]
        public string Data { get; set; }
        /// <summary>
        /// 数据编号
        /// </summary>
        [DataMember]
        public string DataID { get; set; }
        /// <summary>
        /// ES索引数据接口
        /// </summary>
        [DataMember]
        public IIndexDataGrainBase IndexDataGrain { get; set; }

    }
}
