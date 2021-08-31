using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataModel
{
    /// <summary>
    /// 事务信息表
    /// </summary>
    [DataContract]
    [Serializable]
    public class TransactionMetaDataModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public string ID { get; set; }
        /// <summary>
        /// 事务提交执行已序号
        /// </summary>
        [DataMember]
        public long CommittedSequenceId { get; set; }
        /// <summary>
        /// meta
        /// </summary>
        [DataMember]
        public string Metadata { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; internal set; }
        /// <summary>
        /// etag
        /// </summary>
        [DataMember]
        public string ETag { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [DataMember]
        public DateTime LastUpdateTime { get; internal set; }
    }
}
