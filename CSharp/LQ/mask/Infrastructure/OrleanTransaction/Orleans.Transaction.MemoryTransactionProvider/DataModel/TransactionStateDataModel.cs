using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataModel
{
    /// <summary>
    /// state数据表
    /// </summary>
    [DataContract]
    [Serializable]
    public class TransactionStateDataModel
    {
        /// <summary>
        /// 数据编号
        /// </summary>
        [DataMember]
        public string DataID { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public long SequenceId { get; set; }

        /// <summary>
        /// 事务编号
        /// </summary>
        [DataMember]
        public string TransactionId { get; set; }
        /// <summary>
        /// 事务执行时间
        /// </summary>
        [DataMember]
        public DateTime TransactionTimestamp { get; set; }
        /// <summary>
        /// 事务管理器
        /// </summary>
        [DataMember]
        public string TransactionManager { get; set; }
        /// <summary>
        /// state数据
        /// </summary>
        [DataMember]
        public string StateJson { get; set; }
        [DataMember]
        public DateTimeOffset Timestamp { get; set; }
        [DataMember]
        public string ETag { get; set; }

    }
}
