using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJUSS.Infrastructure.Core.Common
{
    [DataContract]
    [Serializable]
    public class SyncES67DataDTO
    {
        /// <summary>
        /// 数据类型
        /// </summary>
        [DataMember]
        public string DataType { get; set; }
        /// <summary>
        /// 索引名
        /// </summary>
        [DataMember]
        public string IndexName { get; set; } = string.Empty;
        /// <summary>
        /// json数据
        /// </summary>
        [DataMember]
        public string JsonData { get; set; }
        /// <summary>
        /// 消息确认编号
        /// </summary>
        [DataMember]
        public ulong DeliveryTag { get; set; }
    }
}
