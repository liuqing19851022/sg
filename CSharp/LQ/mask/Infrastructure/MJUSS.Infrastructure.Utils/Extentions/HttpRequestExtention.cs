
//namespace MJUSS.Infrastructure.Utils.Extentions
//{
//    using System.Web;

//    /// <summary>
//    /// 请求扩展
//    /// </summary>
//    public static class HttpRequestExtention
//    {
//        /// <summary>
//        /// 完整的原始路径
//        /// </summary>
//        /// <param name="request">请求</param>
//        /// <returns></returns>
//        public static string FullRawUrl(this HttpRequest request)
//        {
//            return string.Format(
//                request.IsSecureConnection ? "https://{0}{1}" : "http://{0}{1}",
//                request.Url.Host,
//                request.RawUrl);
//        }
//    }
//}