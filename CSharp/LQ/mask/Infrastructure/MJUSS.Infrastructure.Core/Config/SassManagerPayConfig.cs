using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// 支付配置
    /// </summary>
    [Serializable]
    [DataContract]
    public class SassManagerPayConfig
    {
        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public long THMSStoreID { get; set; }
        /// <summary>
        /// 微信 app 编号
        /// </summary>
        [DataMember]
        public string WeiXinAppID { get; set; }
    }
}
