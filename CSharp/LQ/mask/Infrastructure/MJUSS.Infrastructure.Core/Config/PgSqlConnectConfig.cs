using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// pgsql 连接字符串
    /// </summary>
    [Serializable]
    [DataContract]
    public class PgSqlConnectConfig
    {
        /// <summary>
        /// iot 连接字符串
        /// </summary>
        [DataMember]
        public string IotConnctionString { get; set; }
        /// <summary>
        /// 商城连接字符串
        /// </summary>
        [DataMember]
        public string IotMallConnectString { get; set; }
    }
}
