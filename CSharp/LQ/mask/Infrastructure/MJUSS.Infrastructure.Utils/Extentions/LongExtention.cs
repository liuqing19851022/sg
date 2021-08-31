using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class LongExtention
    {
        /// <summary>
        /// ES模糊查询的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string WildcardQueryForEs(this long s)
        {
            var maxLen = 16;
            if (s.ToString().Length > maxLen)
            {
                throw new Exception($"模糊查询的字符长度不能超过{maxLen}");
            }
            return $"*{s}*";
        }

        public static DateTime UnixTimestampToLocalTime(this long timestamp)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(timestamp).AddHours(TimeZoneInfo.Local.BaseUtcOffset.Hours);
        }
        ///// <summary>
        ///// 验证ES模糊查询的数字长度
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns></returns>
        //public static long WildcardQueryForEsCheck(this long s)
        //{
        //    var maxLen = 30;
        //    if (s.ToString().Length > maxLen)
        //    {
        //        throw new Exception($"模糊查询的字符长度不能超过{maxLen}");
        //    }
        //    return s;
        //}
        ///// <summary>
        ///// 从读库获取指定ID的数据的名称
        ///// </summary>
        ///// <param name="Id">数据主键编号</param>
        ///// <param name="tenantID">租户编号</param>
        ///// <param name="appID">应用编号</param>
        ///// <param name="func">从读库获取数据的方法，返回类型为string,参数为(租户编号，应用ID,数据主键编号)</param>
        ///// <returns></returns>
        //public static async Task<string> GetNameFromReadDbByID(this long Id, 
        //    long tenantID, int appID, Func<long, int, long, Task<string>> func)
        //{
        //    ConcurrentDictionary<long, string> _dict = new ConcurrentDictionary<long, string>();
        //    var _name = string.Empty;
        //    if (_dict.ContainsKey(Id))
        //    {
        //        _dict.TryGetValue(Id, out _name);
        //    }
        //    else
        //    {
        //        _name = await func(tenantID, appID, Id);
        //        _dict.TryAdd(Id, _name);
        //    }
        //    return _name;
        //}
        ///// <summary>
        ///// 从读库获取指定ID的数据的名称
        ///// </summary>
        ///// <param name="Id">数据主键编号</param>
        ///// <param name="tenantID">租户编号</param>
        ///// <param name="appID">应用编号</param>
        ///// <param name="storeID">门店编号</param>
        ///// <param name="func">从读库获取数据的方法，返回类型为string,参数为(租户编号，应用ID,数据主键编号)</param>
        ///// <returns></returns>
        //public static async Task<string> GetNameFromReadDbByID(this long Id,
        //    long tenantID, int appID, long storeID,Func<long, int, long, long,Task<string>> func)
        //{
        //    ConcurrentDictionary<long, string> _dict = new ConcurrentDictionary<long, string>();
        //    var _name = string.Empty;
        //    if (_dict.ContainsKey(Id))
        //    {
        //        _dict.TryGetValue(Id, out _name);
        //    }
        //    else
        //    {
        //        _name = await func(tenantID, appID, storeID,Id);
        //        _dict.TryAdd(Id, _name);
        //    }
        //    return _name;
        //}
    }
}
