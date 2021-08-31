//using Microsoft.Extensions.Options;
//using Orleans;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace MJUSS.Infrastructure.Utils.Caches.OrleansCache
//{
//    /// <summary>
//    /// orleans缓存
//    /// </summary>
//    public interface IOreansCacheGrain : IGrainWithStringKey
//    {
//        /// <summary>
//        /// 设置缓存
//        /// </summary>
//        /// <param name="value"></param>
//        /// <param name="absoluteExpirationRelativeToNow"></param>
//        /// <returns></returns>
//        Task SetCache(string value, TimeSpan absoluteExpirationRelativeToNow);
//        /// <summary>
//        /// 获取缓存
//        /// </summary>
//        /// <returns></returns>
//        Task<string> GetCache();
//    }
//}
