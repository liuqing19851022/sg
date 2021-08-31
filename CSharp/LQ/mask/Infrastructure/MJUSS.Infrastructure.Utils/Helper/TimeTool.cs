using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Helper
{
    public static class TimeTool
    {
        public static string ToFormatTimeSpan(this long ticks)
        {
            var timeSpan = TimeSpan.FromTicks(ticks);
            return $"{(int)timeSpan.TotalHours}小时{timeSpan.Minutes}分钟 ";
        }
        public static DateTime GetDayBeginTime(DateTime time, TimeSpan storeDayEndTimeRange)
        {
            if (new TimeSpan(time.Hour, time.Minute, time.Second) < storeDayEndTimeRange)
            {
                return time.Date.AddDays(-1);
            }
            return time.Date;
        }

        public static DateTime GetDayEndTime(DateTime time, TimeSpan storeDayEndTimeRange)
        {
            if (new TimeSpan(time.Hour, time.Minute, time.Second) < storeDayEndTimeRange)
            {
                return time.Date.AddDays(-1);
            }
            return time.Date;
        }

        public static DateTime GetWeekBeginTime(DateTime time, TimeSpan storeDayEndTimeRange)
        {
            time = GetDayBeginTime(time, storeDayEndTimeRange);
            if (time.DayOfWeek == DayOfWeek.Sunday)
            {
                return time.AddDays(-6).Date;
            }
            return time.AddDays(((int)time.DayOfWeek - 1) * -1).Date;
        }

        public static DateTime GetWeekEndTime(DateTime time, TimeSpan storeDayEndTimeRange)
        {
            time = GetDayBeginTime(time, storeDayEndTimeRange);
            if (time.DayOfWeek == DayOfWeek.Sunday)
            {
                return time.Date;
            }
            return time.AddDays(7 - (int)time.DayOfWeek).Date;
        }

        public static DateTime GetMonthBeginTime(DateTime time, TimeSpan storeDayEndTimeRange)
        {
            time = GetDayBeginTime(time, storeDayEndTimeRange);
            return new DateTime(time.Year, time.Month, 1);
        }

        public static DateTime GetMonthEndTime(DateTime time, TimeSpan storeDayEndTimeRange)
        {
            time = GetDayBeginTime(time, storeDayEndTimeRange);
            return new DateTime(time.Year, time.Month, 1).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 获取季度开始时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetQuarterBeginTime(DateTime time, TimeSpan storeDayEndTimeRange)
        {
            if (time.Month >= 1 && time.Month <= 3)
            {
                return new DateTime(time.Year, 1, 1);
            }
            else if (time.Month >= 4 && time.Month <= 6)
            {
                return new DateTime(time.Year, 4, 1);
            }
            else if (time.Month >= 7 && time.Month <= 9)
            {
                return new DateTime(time.Year, 7, 1);
            }
            return new DateTime(time.Year, 10, 1);
        }
        /// <summary>
        /// 获取每季度结束时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetQuarterEndTime(DateTime time, TimeSpan storeDayEndTimeRange)
        {
            if (time.Month >= 1 && time.Month <= 3)
            {
                return new DateTime(time.Year, 3, 31);
            }
            else if (time.Month >= 4 && time.Month <= 6)
            {
                return new DateTime(time.Year, 6, 30);
            }
            else if (time.Month >= 7 && time.Month <= 9)
            {
                return new DateTime(time.Year, 9, 30);
            }
            return new DateTime(time.Year, 12, 31);
        }

        public static DateTime GetYearBeginTime(DateTime time, TimeSpan storeDayEndTimeRange)
        {
            return new DateTime(time.Year, 1, 1);
        }

        public static DateTime GetYearEndTime(DateTime time, TimeSpan storeDayEndTimeRange)
        {
            return new DateTime(time.Year, 1, 1).AddYears(1).AddDays(-1);
        }

        /// <summary>
        /// 判断查询日期是否超过了限制天数
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static bool QueryDateIsOutOfDayRange(DateTime beginTime,DateTime endTime)
        {
            var result = false;
            if (endTime.Subtract(beginTime).TotalDays > 90)
            {
                result = true;
            }
            return result;
        }
    }
}
