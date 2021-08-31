using MJUSS.Infrastructure.Utils.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class IListExtention
    {
        /// <summary>
        /// 获取集合的hash值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetMD5Hash<T>(this IEnumerable<T> list) where T:class,new()
        {
            if (list == null)
                return string.Empty;
            var jsonString = JsonConvert.SerializeObject(list);
            return HashHelper.GetMd5HashCode(jsonString);
        }

        public static bool RemoveWhere<T>(this IList<T> list, Func<T, bool> predicate,int max = 1) {
            var match = 0;
            for (int i = list.Count - 1; i > 0; i--) {
                if (predicate.Invoke(list[i])) {
                    list.RemoveAt(i);
                    if (max > 0)
                    {
                        match++;
                        if (match >= max)
                            break;
                    }
                }
            }
            return match > 0;
        }

        public static async Task<bool> RemoveWhereAsync<T>(this IList<T> list, Func<T, Task<bool>> predicate, int max = 1) {

            var match = 0;
            for (int i = list.Count - 1; i > 0; i--)
            {
                if (await predicate.Invoke(list[i]))
                {
                    list.RemoveAt(i);
                    match++;
                    if (match >= max)
                        break;
                }
            }
            return match > 0;
        }

    }
}
