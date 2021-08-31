using LinqToDB.Mapping;
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
        [PrimaryKey]
        [Column(Name = nameof(DataID)), NotNull]
        public string DataID { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        [PrimaryKey]
        [Column(Name = nameof(SequenceId)), NotNull]
        public long SequenceId { get; set; }

        /// <summary>
        /// 事务编号
        /// </summary>
        [DataMember]
        [Column(Name = nameof(TransactionId)), NotNull]
        public string TransactionId { get; set; }
        /// <summary>
        /// 事务执行时间
        /// </summary>
        [DataMember]
        [Column(Name = nameof(TransactionTimestamp)), NotNull]
        public DateTime TransactionTimestamp { get; set; }
        /// <summary>
        /// 事务管理器
        /// </summary>
        [DataMember]
        [Column(Name = nameof(TransactionManager)), NotNull]
        public string TransactionManager { get; set; }
        /// <summary>
        /// state数据
        /// </summary>
        [DataMember]
        [Column(Name = nameof(StateJson)), NotNull]
        public string StateJson { get; set; }
        [DataMember]
        [Column(Name = nameof(Timestamp)), NotNull]
        public DateTimeOffset Timestamp { get; set; }
        [DataMember]
        [Column(Name = nameof(ETag)), NotNull]
        public string ETag { get; set; }

    }
}
