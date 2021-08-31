//namespace MJUSS.Infrastructure.Utils.Caches
//{
//    using System;
//    using System.Text;

//    using Enyim.Caching;
//    using Enyim.Caching.Memcached;

//    using Newtonsoft.Json;

//    /// <summary>
//    ///     Memcached缓存操作类
//    /// </summary>
//    public class MemcachedCacheHelper
//    {
//        private static readonly DateTime NotExpirersTime = DateTime.Now.AddYears(50);
//        private static readonly MemcachedClient EnyimMemcachedClient = new MemcachedClient("EnyimMemcached/memcached");

//        /// <summary>
//        ///     移除缓存键
//        /// </summary>
//        /// <param name="cacheKey"></param>
//        /// <param name="keys"></param>
//        public static void RemoveTagGBL(string cacheKey, params object[] keys)
//        {
//            cacheKey = GetRealCacheKey(cacheKey, keys);
//            RemoveCache(cacheKey);
//        }

//        /// <summary>
//        ///     获取缓存
//        /// </summary>
//        /// <param name="callBack">如果缓存未命中取数据的方法</param>
//        /// <param name="cacheKey"></param>
//        /// <param name="expiresAt"></param>
//        /// <param name="keys"></param>
//        /// <typeparam name="T"></typeparam>
//        /// <returns></returns>
//        public static T GetTagGBL<T>(Func<T> callBack, string cacheKey, DateTime expiresAt, params object[] keys)
//        {
//            cacheKey = GetRealCacheKey(cacheKey, keys);
//            var cacheddata = GetCache(cacheKey);
//            if (cacheddata != null)
//            {
//                return (T)cacheddata;
//            }
//            lock (GetLockObject(cacheKey))
//            {
//                cacheddata = GetCache(cacheKey);
//                if (cacheddata != null)
//                {
//                    return (T)cacheddata;
//                }
//                var value = callBack();
//                if (value != null)
//                {
//                    SetCache(cacheKey, value, expiresAt);
//                }
//                return value;
//            }
//        }

//        /// <summary>
//        ///     获取缓存(缓存键为Json)
//        /// </summary>
//        /// <param name="callBack">如果缓存未命中取数据的方法</param>
//        /// <param name="funcName">函数名</param>
//        /// <param name="expiresAt">过期时间(默认为一分钟)</param>
//        /// <param name="nameSpace">名称空间</param>
//        /// <param name="toJsonObj">转为json的key</param>
//        /// <typeparam name="T"></typeparam>
//        /// <returns></returns>
//        public static T GetTagGBLCacheJsonKey<T>(
//            Func<T> callBack,
//            string nameSpace,
//            string funcName,
//            DateTime expiresAt,
//            object toJsonObj)
//        {
//            var cacheKey = GetRealCacheKey(
//                string.Concat(nameSpace, funcName),
//                JsonConvert.SerializeObject(toJsonObj, Formatting.None));
//            var cacheddata = GetCache(cacheKey);
//            if (cacheddata != null)
//            {
//                return (T)cacheddata;
//            }
//            lock (GetLockObject(cacheKey))
//            {
//                cacheddata = GetCache(cacheKey);
//                if (cacheddata != null)
//                {
//                    return (T)cacheddata;
//                }
//                var value = callBack();
//                if (value != null)
//                {
//                    SetCache(cacheKey, value, expiresAt);
//                }
//                return value;
//            }
//        }

//        /// <summary>
//        ///     更新缓存
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="callBack"></param>
//        /// <param name="cacheKey"></param>
//        /// <param name="expiresAt"></param>
//        /// <param name="IsNotExpired">是否永不过期</param>
//        /// <param name="keys"></param>
//        public static T UpdateTagGBL<T>(
//            Func<T> callBack,
//            string cacheKey,
//            DateTime expiresAt,
//            bool IsNotExpired,
//            params object[] keys)
//        {
//            cacheKey = GetRealCacheKey(cacheKey, keys);
//            var value = callBack();
//            if (value == null)
//            {
//                return value;
//            }
//            SetCache(cacheKey, value, IsNotExpired ? NotExpirersTime : expiresAt, StoreMode.Set);
//            return value;
//        }

//        /// <summary>
//        ///     获取缓存
//        /// </summary>
//        /// <param name="cacheKey">缓存键</param>
//        /// <param name="keys">参数</param>
//        /// <returns></returns>
//        public static object GetTagGBL(string cacheKey, params object[] keys)
//        {
//            cacheKey = GetRealCacheKey(cacheKey, keys);
//            var cacheddata = GetCache(cacheKey);
//            if (cacheddata != null)
//            {
//                return cacheddata;
//            }
//            lock (GetLockObject(cacheKey))
//            {
//                cacheddata = GetCache(cacheKey);
//            }

//            return cacheddata;
//        }

//        #region 私有方法

//        private static object GetCache(string cacheKey)
//        {
//            return EnyimMemcachedClient.Get(cacheKey);
//        }

//        private static void RemoveCache(string cacheKey)
//        {
//            EnyimMemcachedClient.Remove(cacheKey);
//        }

//        private static void SetCache(string cacheKey, object value, DateTime expiresAt, StoreMode mode = StoreMode.Add)
//        {
//            EnyimMemcachedClient.Store(mode, cacheKey, value, expiresAt);
//        }

//        /// <summary>
//        ///     缓存锁
//        /// </summary>
//        /// <param name="key">缓存键</param>
//        /// <returns></returns>
//        private static object GetLockObject(string key)
//        {
//            var cacheKey = $"$MemcachedCacheHelperLockObject${key}";
//            var result = GetCache(cacheKey);
//            if (result != null)
//            {
//                return result;
//            }
//            result = new CacheLockObject(new Object().GetHashCode());
//            SetCache(cacheKey, result, NotExpirersTime);
//            return result;
//        }

//        private static string GetRealCacheKey(string cacheKey, params object[] keys)
//        {
//            var sb = new StringBuilder();
//            foreach (var t in keys)
//            {
//                if (t == null || String.IsNullOrEmpty(t.ToString()))
//                {
//                    sb.Append("/");
//                }
//                else
//                {
//                    sb.Append("/").Append(t);
//                }
//            }
//            var cacheKeyParm = sb.ToString();
//            cacheKey = cacheKeyParm.Length + cacheKey.Length > 50
//                           ? CacheKeyHandler.CreateCacheKeyWithMD5(cacheKey + cacheKeyParm, true)
//                           : $"#{cacheKey}/{cacheKeyParm}";
//            return cacheKey;
//        }

//        #endregion 私有方法
//    }

//    [Serializable]
//    public class CacheLockObject
//    {
//        public CacheLockObject(int hashCode)
//        {
//            this.HashCode = hashCode;
//        }

//        public int HashCode { get; }

//        public override int GetHashCode()
//        {
//            return this.HashCode;
//        }
//    }
//}