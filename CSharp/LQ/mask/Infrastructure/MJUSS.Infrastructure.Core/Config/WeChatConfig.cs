using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// 微信配置
    /// </summary>
    public class WeChatConfig
    {
        /// <summary>
        /// 商户端微信App编号
        /// </summary>
        public string WeixinAppId_B { get; set; }
        /// <summary>
        /// 用户端微信App编号
        /// </summary>
        public string WeixinAppId_C { get; set; }
    }
}
