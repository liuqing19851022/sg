using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class Int32Extention
    {
        /// <summary>
        /// 格式化分钟数为2位
        /// </summary>
        /// <param name="mins"></param>
        /// <returns></returns>
        public static string MinFormat(this int mins)
        {
            if (mins < 10) return $"0{mins}";
            return mins.ToString();
        }
        public static string ToDisplayHour(this int hour)
        {
            if (hour >= 24) return $"次日{hour - 24}";
            return hour.ToString();
        }

        /// <summary>
        /// 分钟转为小十分钟
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static string ToDisplayHourMinutes(this int minutes)
        {
            var hour = 0;
            var min=0;
            if (minutes > 0)
            {
                hour = minutes / 60;
                min = minutes % 60;
            }
            return $"{hour}小时{min}分钟";
        }
        public static List<int> ToDayOfWeek(this int dow)
        {

            var result = new List<int>(7);
            for (var i = 0; i < 7; i++)
            {
                if ((dow & (1 << i)) > 0)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public static IEnumerable<string> ToDayOfWeekCN(this int dow)
        {
            var lst = dow.ToDayOfWeek();
            var arr = new string[] { "一", "二", "三", "四", "五", "六", "日" };
            return from item in lst select string.Join("星期", arr[item]);

        }
    }
}
