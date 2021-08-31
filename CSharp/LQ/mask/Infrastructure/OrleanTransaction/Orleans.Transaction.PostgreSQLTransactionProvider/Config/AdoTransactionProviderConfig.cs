using System;
using System.Runtime.Serialization;

namespace Orleans.Transaction.PostgreSQLTransactionProvider.Config
{
    /// <summary>
    /// 配置
    /// </summary>
    [Serializable]
    [DataContract]
    public class AdoTransactionProviderConfig
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        [DataMember]
        public string ConnectionString { get; set; }

        [DataMember]
        public string DbType { get; set; } = "MySql";//PostgreSQL

    }

  }
