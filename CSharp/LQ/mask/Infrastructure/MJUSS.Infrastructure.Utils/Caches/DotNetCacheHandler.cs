//namespace MJUSS.Infrastructure.Utils.Caches
//{
//    using System;
//    using System.Collections;
//    using System.Web;
//    using System.Web.Caching;

//    /// <summary>
//    ///     .net缓存处理程序
//    /// </summary>
//    public class DotNetCacheHandler
//    {
//        #region Static Fields

//        /// <summary>
//        ///     缓存实例
//        /// </summary>
//        private static readonly Cache _cache;

//        /// <summary>
//        ///     小时(秒)
//        /// </summary>
//        private static readonly int hourfactor;

//        #endregion

//        #region Constructors and Destructors

//        static DotNetCacheHandler()
//        {
//            hourfactor = 3600;
//            _cache = HttpRuntime.Cache;
//        }

//        private DotNetCacheHandler()
//        {
//        }

//        #endregion

//        #region Public Methods and Operators

//        /// <summary>
//        ///     清除所有缓存
//        /// </summary>
//        public static void Clear()
//        {
//            //要循环访问 Cache 对象的枚举数
//            var enumerator = _cache.GetEnumerator(); //检索用于循环访问包含在缓存中的键设置及其值的字典枚举数
//            while (enumerator.MoveNext())
//            {
//                _cache.Remove(enumerator.Key.ToString());
//            }
//        }

//        /// <summary>
//        ///     得到所有使用的Cache键值
//        /// </summary>
//        /// <returns>返回所有的Cache键值</returns>
//        public static ArrayList GetAllCacheKey()
//        {
//            var arrList = new ArrayList();
//            var enumerator = _cache.GetEnumerator();
//            while (enumerator.MoveNext())
//            {
//                arrList.Add(enumerator.Key);
//            }
//            return arrList;
//        }

//        /// <summary>
//        ///     得到缓存实例
//        /// </summary>
//        /// <param name="key">缓存实例名称</param>
//        /// <returns>返回缓存实例</returns>
//        public static object GetCache(string key)
//        {
//            return _cache[key];
//        }

//        /// <summary>
//        ///     缓存实例插入（永久）
//        /// </summary>
//        /// <param name="key">缓存实例名称</param>
//        /// <param name="obj">要缓存的对象</param>
//        public static void Insert(string key, object obj)
//        {
//            Insert(key, obj, (CacheDependency)null);
//        }

//        /// <summary>
//        ///     缓存实例插入
//        /// </summary>
//        /// <param name="key">缓存实例名称</param>
//        /// <param name="obj">要缓存的对象</param>
//        /// <param name="seconds">缓存的时间</param>
//        public static void Insert(string key, object obj, int seconds)
//        {
//            Insert(key, obj, (CacheDependency)null, seconds);
//        }

//        /// <summary>
//        ///     缓存实例插入(缓存过期时间是一天)
//        /// </summary>
//        /// <param name="key">缓存实例名称</param>
//        /// <param name="obj">要缓存的对象</param>
//        /// <param name="dep">缓存的依赖项</param>
//        public static void Insert(string key, object obj, CacheDependency dep)
//        {
//            Insert(key, obj, dep, hourfactor * 12);
//        }

//        /// <summary>
//        ///     缓存实例插入(缓存过期时间是一天)
//        /// </summary>
//        /// <param name="key">缓存实例名称</param>
//        /// <param name="obj">要缓存的对象</param>
//        /// <param name="xmlPath">缓存的依赖项xml文件的路径（绝对路径）</param>
//        public static void Insert(string key, object obj, string xmlPath)
//        {
//            var dep = new CacheDependency(xmlPath);
//            Insert(key, obj, dep, hourfactor * 12);
//        }

//        /// <summary>
//        ///     缓存实例插入
//        /// </summary>
//        /// <param name="key">缓存实例名称</param>
//        /// <param name="obj">
//        ///     要缓存的对象<</param>
//        /// <param name="seconds">缓存时间</param>
//        /// <param name="priority">该对象相对于缓存中存储的其他项的成本</param>
//        public static void Insert(string key, object obj, int seconds, CacheItemPriority priority)
//        {
//            Insert(key, obj, null, seconds, priority);
//        }

//        /// <summary>
//        ///     缓存实例插入
//        /// </summary>
//        /// <param name="key">用于引用该对象的缓存键</param>
//        /// <param name="obj">要插入缓存中的对象</param>
//        /// <param name="dep">该项的文件依赖项或缓存键依赖项。当任何依赖项更改时，该对象即无效，并从缓存中移除。如果没有依赖项，则此参数包含空引用（Visual Basic 中为 Nothing）</param>
//        /// <param name="seconds">所插入对象将过期并被从缓存中移除的时间。</param>
//        public static void Insert(string key, object obj, CacheDependency dep, int seconds)
//        {
//            Insert(key, obj, dep, seconds, CacheItemPriority.Normal);
//        }

//        /// <summary>
//        ///     缓存实例插入
//        /// </summary>
//        /// <param name="key">用于引用该对象的缓存键</param>
//        /// <param name="obj">要插入缓存中的对象</param>
//        /// <param name="xmlPath">缓存的依赖项xml文件的路径（绝对路径）</param>
//        /// <param name="seconds">所插入对象将过期并被从缓存中移除的时间。</param>
//        public static void Insert(string key, object obj, string xmlPath, int seconds)
//        {
//            var dep = new CacheDependency(xmlPath);
//            Insert(key, obj, dep, seconds, CacheItemPriority.Normal);
//        }

//        /// <summary>
//        ///     缓存实例插入
//        /// </summary>
//        /// <param name="key">用于引用该对象的缓存键</param>
//        /// <param name="obj">要插入缓存中的对象</param>
//        /// <param name="dep">该项的文件依赖项或缓存键依赖项。当任何依赖项更改时，该对象即无效，并从缓存中移除。如果没有依赖项，则此参数包含空引用（Visual Basic 中为 Nothing）。</param>
//        /// <param name="seconds">所插入对象将过期并被从缓存中移除的时间。</param>
//        /// <param name="priority">该对象相对于缓存中存储的其他项的成本，由 CacheItemPriority 枚举表示。该值由缓存在退出对象时使用；具有较低成本的对象在具有较高成本的对象之前被从缓存移除。 </param>
//        public static void Insert(string key, object obj, CacheDependency dep, int seconds, CacheItemPriority priority)
//        {
//            if (obj != null)
//            {
//                _cache.Insert(key, obj, dep, DateTime.Now.AddSeconds(seconds), TimeSpan.Zero, priority, null);
//            }
//        }

//        /// <summary>
//        ///     缓存实例插入(依赖于配置文件，如配置文件变化则缓存失效)
//        /// </summary>
//        /// <param name="key">用于引用该对象的缓存键</param>
//        /// <param name="obj">要插入缓存中的对象</param>
//        /// <param name="configPath"></param>
//        public static void InsertConfigCache(string key, object obj, string configPath)
//        {
//            if (obj == null)
//            {
//                return;
//            }
//            var dep = new CacheDependency(configPath);
//            _cache.Insert(key, obj, dep);
//        }

//        /// <summary>
//        ///     移出单个缓存
//        /// </summary>
//        /// <param name="key">缓存实例名称</param>
//        public static void Remove(string key)
//        {
//            _cache.Remove(key);
//        }

//        #endregion
//    }
//}