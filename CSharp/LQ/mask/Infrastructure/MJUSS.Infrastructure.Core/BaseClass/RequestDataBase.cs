
namespace MJUSS.Infrastructure.Core.BaseClass
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// 请求基类
    /// </summary>
    [System.Serializable]
    [DataContract]
    public class RequestDataBase
    {
        /// <summary>
        /// 认证码
        /// </summary>
        [DataMember]
        public string Token { get; set; }
        /// <summary>
        /// 命令名称
        /// </summary>
        [DataMember]
        public string CommandName { get; set; }
        /// <summary>
        /// 客户端的地址
        /// </summary>
        [DataMember]
        public string UserHostAddress { get; set; }
        /// <summary>
        /// 应用ID
        /// </summary>
        [DataMember]
        public int AppID { get; set; }
        /// <summary>
        /// 加密TripleDes密钥Key(rsa加过密)
        /// </summary>
        [DataMember]
        public byte[] TripleDesKey { get; set; }
        /// <summary>
        /// 加密TripleDes密钥IV(rsa加过密)
        /// </summary>
        [DataMember]
        public byte[] TripleDesIV { get; set; }
        /// <summary>
        /// 加密数据
        /// </summary>
        [DataMember]
        public byte[] EncryptData { get; set; }
        /// <summary>
        /// 租户编号
        /// </summary>
        [DataMember]
        public long TenantID { get; set; }
        /// <summary>
        /// 流程消息编号
        /// </summary>
        [DataMember]
        public long ProcessMessageID { get; set; }
        /// <summary>
        /// 流程消息类型
        /// </summary>
        [DataMember]
        public string ProcessMessageType { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        [DataMember]
        public DateTime RequestTime { get; set; }

        /// <summary>
        /// 会话编号
        /// </summary>
        [DataMember]
        public string SessionID { get; set; }
        /// <summary>
        /// 微信小程序编号
        /// </summary>
        [DataMember]
        public string WeixinAppID { get; set; }
        /// <summary>
        /// 数据跟踪使用
        /// </summary>
        [DataMember]
        public SkywalkingTracingMetaData TracingData { get; set; }
    }


}
