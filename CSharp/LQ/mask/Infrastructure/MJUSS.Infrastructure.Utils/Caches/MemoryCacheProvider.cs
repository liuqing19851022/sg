using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Caches
{
    public class MemoryCacheProvider
    {
        /// <summary>
        ///     缓存实例
        /// </summary>
        private static readonly MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        ///     得到缓存实例
        /// </summary>
        /// <param name="key">缓存实例名称</param>
        /// <returns>返回缓存实例</returns>
        public static object GetCache(string key)
        {
            return memoryCache.Get(key);
        }

        /// <summary>
        /// 获取配置文件数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static T GetOrInsert<T>(string key, string filepath) where T : class
        {
            //if (!memoryCache.TryGetValue(key, out T cacheData))
            //{
            //    using (var streamReader = new StreamReader(filepath))
            //    {
            //        var fileProvider = new PhysicalFileProvider(Path.GetDirectoryName(filepath));
            //        var fileName = Path.GetFileName(filepath);
            //        var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            //        cacheData = xmlSerializer.Deserialize(streamReader) as T;
            //        memoryCache.Set(key, cacheData, new MemoryCacheEntryOptions()
            //             .AddExpirationToken(fileProvider.Watch(fileName))
            //             .RegisterPostEvictionCallback(
            //             (echoKey, value, reason, substate) =>
            //             {
            //                 Console.WriteLine($"{echoKey} : {value} 失效，因为： {reason}");
            //             }));                    
            //        Console.WriteLine($"{key} 缓存已更新.");                    
            //    }
            //}
            //else
            //{
            //    Console.WriteLine($"{key} 从缓存读取.");                
            //}
            //return cacheData;
                       
            return memoryCache.GetOrCreate(key, entry =>
            {
                //var fileProvider = new PhysicalFileProvider(Path.GetDirectoryName(filepath));
                //var fileName = Path.GetFileName(filepath);
                entry.SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddSeconds(600));
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (var streamReader = new StreamReader(filepath))
                {
                    return xmlSerializer.Deserialize(streamReader) as T;
                }
            });
        }

        public async static  Task<TItem> GetOrCreateAsync<TItem>(string key, Func<ICacheEntry, Task<TItem>> factory) {
            var result = await memoryCache.GetOrCreateAsync(key, factory);
            return result;
        }

        /// <summary>
        ///     缓存实例插入（永久）
        /// </summary>
        /// <param name="key">缓存实例名称</param>
        /// <param name="obj">要缓存的对象</param>
        public static void Insert(string key, object obj)
        {
            memoryCache.Set(key, obj, new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.NeverRemove));
        }

        /// <summary>
        ///     缓存实例插入
        /// </summary>
        /// <param name="key">缓存实例名称</param>
        /// <param name="obj">要缓存的对象</param>
        /// <param name="seconds">缓存的时间</param>
        public static void Insert(string key, object obj, int seconds)
        {
            memoryCache.Set(key, obj, new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddSeconds(seconds)));
        }

        ///// <summary>
        /////     缓存实例插入
        ///// </summary>
        ///// <param name="key">缓存实例名称</param>
        ///// <param name="obj">要缓存的对象</param>
        ///// <param name="xmlPath">缓存文件的路径（绝对路径）</param>
        //public static void Insert(string key, object obj, string filepath)
        //{
        //    var fileProvider = new PhysicalFileProvider(Path.GetDirectoryName(filepath));
        //    var fileName = Path.GetFileName(filepath);
        //    memoryCache.Set(key, obj, fileProvider.Watch(fileName));
        //}

    }
}
