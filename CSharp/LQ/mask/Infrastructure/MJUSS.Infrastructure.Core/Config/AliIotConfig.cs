using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// 阿里物联网平台配置
    /// </summary>
    [Serializable]
    [DataContract]
    public class AliIotConfig
    {
        /// <summary>
        /// 阿里云颁发给用户的访问服务所用的密钥ID。
        /// </summary>
        [DataMember]
        public string AccessKeyId { get; set; }
        /// <summary>
        /// 阿里云颁发给用户的访问服务所用的密钥。
        /// </summary>
        [DataMember]
        public string AcessKeySecret { get; set; }
        /// <summary>
        /// 访问地质
        /// </summary>
        [DataMember]
        public string Url { get; set; }
        /// <summary>
        /// 设备所在地域（与控制台上的地域对应），如cn-shanghai。
        /// </summary>
        [DataMember]
        public string RegionId { get; set; }
        /// <summary>
        /// 实例ID。公共实例不传此参数，企业版实例需传入。
        /// </summary>
        [DataMember]
        public string IotInstanceId { get; set; }
        /// <summary>
        /// mqtt 的qos
        /// </summary>
        [DataMember]
        public int Qos { get; set; }

        /// <summary>
        /// 订阅url
        /// </summary>
        [DataMember]
        public string AmqpUrl { get; set; }
        /// <summary>
        /// 订阅端口
        /// </summary>
        [DataMember]
        public int AmqpPort { get; set; }
        /// <summary>
        /// 订阅消费组编号(多个以逗号分隔)
        /// </summary>
        [DataMember]
        public string AmqpConsumerGroupId { get; set; }
    }
}
