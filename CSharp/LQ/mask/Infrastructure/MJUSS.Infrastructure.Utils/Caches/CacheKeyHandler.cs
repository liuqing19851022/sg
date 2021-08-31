
namespace MJUSS.Infrastructure.Utils.Caches
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    ///     缓存键处理
    /// </summary>
    public static class CacheKeyHandler
    {
        #region Public Methods and Operators

        /// <summary>
        ///     创建缓存key
        ///     如果isMD5为true或者长度超过阀值长度则进行Md5处理,如果都不满足则不进行处理
        /// </summary>
        /// <param name="sourceKey">CacheKey字符串</param>
        /// <param name="isMD5">是否执行Md5处理</param>
        /// <param name="lengthThreshold">长度阀值</param>
        /// <returns>缓存key</returns>
        public static string CreateCacheKeyWithMD5(string sourceKey, bool isMD5, int lengthThreshold)
        {
            var returnCacheKey = sourceKey;
            if (isMD5)
            {
                returnCacheKey = GetMD5String(sourceKey);
            }
            else
            {
                if (sourceKey.Length > lengthThreshold)
                {
                    returnCacheKey = GetMD5String(sourceKey);
                }
            }
            return returnCacheKey;
        }

        /// <summary>
        ///     创建缓存key
        ///     如果isMD5为true或者长度超过50则进行Md5处理,如果都不满足则不进行处理
        /// </summary>
        /// <param name="sourceKey">CacheKey字符串</param>
        /// <param name="isMD5">是否执行Md5处理</param>
        /// <returns>缓存key</returns>
        public static string CreateCacheKeyWithMD5(string sourceKey, bool isMD5)
        {
            return CreateCacheKeyWithMD5(sourceKey, isMD5, 50);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     获取MD5加密字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>加密字符串</returns>
        private static string GetMD5String(string str)
        {
            var md5 = MD5.Create();
            var b = Encoding.UTF8.GetBytes(str);
            var md5b = md5.ComputeHash(b);
            md5.Clear();
            var sb = new StringBuilder();
            foreach (var item in md5b)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }

        #endregion
    }
}