using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DictionaryExtention
    {
        public static TValue TryToGetValue<TValue, TKey>(this IDictionary<TKey, TValue> dic, TKey key, Func<TValue> fnGet) {

            TValue result;
            if (dic.TryGetValue(key, out result))
                return result;

            result = fnGet.Invoke();
            dic[key] = result;
            return result;

        }

        public static async Task<TValue> TryToGetValue<TValue, TKey>(this IDictionary<TKey, TValue> dic, TKey key, Func<Task<TValue>> fnGet)
        {

            TValue result;
            if (dic.TryGetValue(key, out result))
                return result;

            result = await fnGet.Invoke();
            dic[key] = result;
            return result;

        }

        public static TValue TryToGetValue<TValue, TKey>(this IDictionary<TKey, Tuple<long, TValue>> dic, TKey key, Func<TValue> fnGet, int expireSenconds)
        {
            var reslut = dic.TryToGetValue(key, () => {
                var data = fnGet.Invoke();
                return new Tuple<long, TValue>(DateTime.Now.AddSeconds(expireSenconds).Ticks, data);

            });


            if (reslut.Item1 > DateTime.Now.Ticks)
            {
                return reslut.Item2;
            }

            //过期
            var data2 = fnGet.Invoke();
            reslut = new Tuple<long, TValue>(DateTime.Now.AddSeconds(expireSenconds).Ticks, data2);
            dic[key] = reslut;

            return reslut.Item2;

        }

        public static async Task<TValue> TryToGetValue<TValue, TKey>(this IDictionary<TKey, Tuple<long, TValue>> dic, TKey key, Func<Task<TValue>> fnGet, int expireSenconds) {
            var reslut = await dic.TryToGetValue(key,async () => {
                var data = await fnGet.Invoke();
                return new Tuple<long, TValue>(DateTime.Now.AddSeconds(expireSenconds).Ticks, data);

            });

            
            if (reslut.Item1 > DateTime.Now.Ticks) {
                return reslut.Item2;
            }

            //过期
            var data2 = await fnGet.Invoke();
            reslut = new Tuple<long, TValue>(DateTime.Now.AddSeconds(expireSenconds).Ticks, data2);
            dic[key] = reslut;

            return reslut.Item2;

        }

    }
}