//using MJUSS.Infrastructure.Core.BaseClass;
//using Newtonsoft.Json.Linq;
//using Orleans;
//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;

//namespace MJUSS.Infrastructure.Utils.Caches.OrleansCache
//{
//    public static class OrleansCacheExtention
//    {
//        public static async Task<TRespond> GetGrainServiceCache<TRequest, TRespond>(this IOreansCacheGrain cacheGrain, string cacheKey, TRequest request, Func<TRequest, Task<TRespond>> grainMothd, TimeSpan expiredTime) where TRequest : RequestDataBase where TRespond : RespondDataBase
//        {

//            var cacheResult = await cacheGrain.GetCache();
//            TRespond result = null;
//            if (string.IsNullOrEmpty(cacheResult))
//            {
//                result = await grainMothd(request);
//                await cacheGrain.SetCache(JObject.FromObject(result).ToString(Newtonsoft.Json.Formatting.None), expiredTime);
//            }
//            else
//            {
//                result = JObject.Parse(cacheResult).ToObject<TRespond>();
//            }

//            return result;
//        }

//        public static Task<TRespond> GetGrainServiceCache<TRequest, TRespond>(this IOreansCacheGrain cacheGrain, string cacheKey, TRequest request, Func<TRequest, Task<TRespond>> grainMothd, int seconds) where TRequest : RequestDataBase where TRespond : RespondDataBase
//        {
//            return GetGrainServiceCache(cacheGrain, cacheKey, request, grainMothd, TimeSpan.FromSeconds(seconds));
//        }

//        public static string GetCacheKey(this RequestDataBase request)
//        {
//            var requestKey = $"{request.GetType().FullName}/{JObject.FromObject(request).ToString(Newtonsoft.Json.Formatting.None)}";
//            if (requestKey.Length > 500)
//            {
//                return MD5RequestKey(requestKey);
//            }
//            return requestKey;
//        }

//        private static string MD5RequestKey(string requestKey)
//        {
//            string md5SourceString = requestKey;
//            byte[] hashBuffer = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(md5SourceString));
//            StringBuilder result = new StringBuilder();
//            foreach (var item in hashBuffer)
//            {
//                result.Append(item.ToString("X"));
//            }
//            return result.ToString();
//        }
//    }
//}
