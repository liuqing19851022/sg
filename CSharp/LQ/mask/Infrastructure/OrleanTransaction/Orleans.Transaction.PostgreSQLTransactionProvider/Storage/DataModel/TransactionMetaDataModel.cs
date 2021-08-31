using LinqToDB.Mapping;
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
        [PrimaryKey]
        [Column(Name = nameof(ID)), NotNull]
        public string ID { get; set; }
        /// <summary>
        /// 事务提交执行已序号
        /// </summary>
        [DataMember]
        [Column(Name = nameof(CommittedSequenceId)), NotNull]
        public long CommittedSequenceId { get; set; }
        /// <summary>
        /// meta
        /// </summary>
        [DataMember]
        [Column(Name = nameof(Metadata)), NotNull]
        public string Metadata { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [Column(Name = nameof(CreateTime)), NotNull]
        public DateTime CreateTime { get; internal set; }
        /// <summary>
        /// etag
        /// </summary>
        [DataMember]
        [Column(Name = nameof(ETag)), NotNull]
        public string ETag { get; set; }
        
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [DataMember]
        [Column(Name = nameof(LastUpdateTime)), NotNull]
        public DateTime LastUpdateTime { get; internal set; }
        /// <summary>
        /// 同步状态
        /// </summary>
        [DataMember]
        [Column(Name = nameof(SyncState)), NotNull]
        public int SyncState { get; set; }
    }
}
