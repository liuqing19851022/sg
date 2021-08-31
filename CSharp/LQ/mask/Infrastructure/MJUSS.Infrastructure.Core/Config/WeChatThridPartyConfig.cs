using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// 微信三方平台配置
    /// </summary>
    public class WeChatThridPartyConfig
    {
        /// <summary>
        /// 公众平台上，开发者设置的Token
        /// </summary>
        public string ThridPartyToken { get; set; } 
        /// <summary>
        /// 公众平台上，开发者设置的EncodingAESKey
        /// </summary>
        public string EncodingAESKey { get; set; }
        /// <summary>
        /// appID
        /// </summary>
        public string ThridPartyAppID { get; set; }
        /// <summary>
        /// app 秘钥
        /// </summary>
        public string ThridPartyAppSecret { get; set; }
        
        /// <summary>
        /// request 合法域名
        /// </summary>
        public List<string> ThridPartyRequestDomain { get; set; } = new List<string>();
        /// <summary>
        /// socket 合法域名
        /// </summary>
        public List<string> ThridPartySocketRequestDomain { get; set; } = new List<string>();
        /// <summary>
        /// uploadFile 合法域名
        /// </summary>
        public List<string> ThridPartyUploadDomain { get; set; } = new List<string>();
        /// <summary>
        /// downloadFile 合法域名
        /// </summary>
        public List<string> ThridPartyDownloadFileDomain { get; set; } = new List<string>();
        /// <summary>
        /// 小程序业务域名
        /// </summary>
        public List<string> ThridPartyWebViewDomain { get; set; } = new List<string>();
        /// <summary>
        /// 授权成功跳转地址
        /// </summary>
        public string AuthRedirectUri { get; set; } = string.Empty;
        /// <summary>
        /// 授权二维码地址
        /// </summary>
        public string AuthQrCodeUri { get; set; } = string.Empty;

        ///// <summary>
        ///// 商家端小程序审核代码备注
        ///// </summary>
        //public string MerchantAppAuditCodeRemark { get; set; } = string.Empty;
        ///// <summary>
        ///// <summary>
        ///// 用户小程序预订端审核代码备注
        ///// </summary>
        //public string BookingAppAuditCodeRemark { get; set; } = string.Empty;

        /// <summary>
        ///// 授权成功跳转地址
        ///// </summary>
        //public string MerchantAuthRedirectUri { get; set; } = string.Empty;


        ///// <summary>
        ///// 公众平台上，开发者设置的Token
        ///// </summary>
        //public string MerchantThridPartyToken { get; set; }
        ///// <summary>
        ///// 公众平台上，开发者设置的EncodingAESKey
        ///// </summary>
        //public string MerchantEncodingAESKey { get; set; }
        ///// <summary>
        ///// appID
        ///// </summary>
        //public string MerchantThridPartyAppID { get; set; }
        ///// <summary>
        ///// app 秘钥
        ///// </summary>
        //public string MerchantThridPartyAppSecret { get; set; }

        ///// <summary>
        ///// request 合法域名
        ///// </summary>
        //public List<string> MerchantThridPartyRequestDomain { get; set; } = new List<string>();
        ///// <summary>
        ///// socket 合法域名
        ///// </summary>
        //public List<string> MerchantThridPartySocketRequestDomain { get; set; } = new List<string>();
        ///// <summary>
        ///// uploadFile 合法域名
        ///// </summary>
        //public List<string> MerchantThridPartyUploadDomain { get; set; } = new List<string>();
        ///// <summary>
        ///// downloadFile 合法域名
        ///// </summary>
        //public List<string> MerchantThridPartyDownloadFileDomain { get; set; } = new List<string>();
        ///// <summary>
        ///// 小程序业务域名
        ///// </summary>
        //public List<string> MerchantThridPartyWebViewDomain { get; set; } = new List<string>();
    }
}
