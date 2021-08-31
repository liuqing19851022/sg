using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class DateTimeExtention
    {
        /// <summary>
        /// 返回DateTime加1天的0点，如2000-01-01 03:13:12 返回 2000-01-02 00:00:00
        /// </summary>
        /// <returns></returns>
        public static DateTime ToCeilingDate(this DateTime date)
        {
            if (date.Hour > 0 || date.Minute > 0 || date.Second > 0)
            {
                var newdate = date.AddDays(1);
                date = new DateTime(newdate.Year, newdate.Month, newdate.Day, 0, 0, 0);
            }
            return date;
        }

        /// <summary>
        /// 返回yyyy-MM-dd HH:mm:ss 格式
        /// </summary>
        /// <returns></returns>
        public static string ToyyyyMMddHHmmss(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static string ToyyyyMMddHHmm(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm");
        }
        public static string ToyyyyMMdd(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        public static string ToMMdd(this DateTime date)
        {
            return date.ToString("MM-dd");
        }
        public static string ToHHmm(this DateTime date)
        {
            return date.ToString("HH:mm");
        }
        public static string ToyyyyMMddOrForever(this DateTime date)
        {
            return date.Year > 9000 ? "永久有效" : date.ToString("yyyy-MM-dd");
        }

        ///// <summary>
        ///// 返回yyyy-MM-dd HH:mm:ss 格式
        ///// </summary>
        ///// <returns></returns>
        //public static string ToReportTimeFormat(this DateTime date, int statisticTypeID = (int)StatisticsTypeEnum.每日)
        //{
        //    switch ((StatisticsTypeEnum)statisticTypeID)
        //    {
        //        case StatisticsTypeEnum.每日:
        //            return date.ToString("yyyy-MM-dd");
        //        case StatisticsTypeEnum.每月:
        //            return date.ToString("yyyy-MM");
        //        case StatisticsTypeEnum.每年:
        //            return date.ToString("yyyy");
        //    }
        //    return date.ToString("yyyy-MM-dd HH:mm:ss");
        //}

        /// <summary>
        /// 返回yyyy-MM-dd HH:mm:ss 格式
        /// </summary>
        /// <returns></returns>
        public static string ToShowTime(this DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return "暂无更新时间";
            }
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 获取星期名
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetWeekDay(this DateTime date)
        {
            var weekdays = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            return weekdays[(int)date.DayOfWeek];
        }
        /// <summary>
        /// 获取星期简称
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetShortWeekDay(this DateTime date)
        {
            var weekdays = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
            return weekdays[(int)date.DayOfWeek];
        }
        /// <summary>
        /// 获取月的第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToMonthFirstDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        /// <summary>
        /// 获取月的最后一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToMonthLastDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
        }
        /// <summary>
        /// 获取年的第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToYearFirstDate(this DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }
        /// <summary>
        /// 获取年的最后一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToYearLastDate(this DateTime date)
        {
            return new DateTime(date.Year, 12, 31);
        }

        /// <summary>
        /// 获取天的最后1毫秒
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToDayLastTime(this DateTime date)
        {
            return date.Date.AddDays(1).AddMilliseconds(-1);
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long ToUnixTimestampSecond(this DateTime date)
        {

            var baseTime = new DateTime(1970, 1, 1);
            if (date < baseTime)
            {
                return 0;
            }
            return (long)date.ToUniversalTime().Subtract(baseTime).TotalSeconds;

        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long ToUnixTimestampMillisecond(this DateTime date)
        {

            var baseTime = new DateTime(1970, 1, 1);
            if (date < baseTime)
            {
                return 0;
            }
            return (long)date.ToUniversalTime().Subtract(baseTime).TotalMilliseconds;

        }

        /// <summary>
        /// 获取时间相差的小时分钟
        /// </summary>
        /// <param name="endTime">结束时间</param>
        /// <param name="beginTime">开始i时间</param>
        /// <returns></returns>
        public static string GetTimeSubtractHourMinutes(this DateTime endTime, DateTime beginTime)
        {
            var time = endTime.Subtract(beginTime);
            return $"{(int)time.TotalHours}小时{time.Minutes}分钟";
        }

    }
}
