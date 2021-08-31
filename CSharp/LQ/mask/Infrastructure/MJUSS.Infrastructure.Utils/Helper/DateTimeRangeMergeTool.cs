using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Helper
{
    /// <summary>
    /// 时间区间合并工具
    /// </summary>
    public class DateTimeRangeMergeTool
    {
        private static Task<(DateTime BeginTime, DateTime EndTime)> GetMergeTimeRangeEndTime(List<(DateTime OrderedBeginTime, DateTime OrderedEndTime)> TimeList, DateTime beginTime, DateTime endTime)
        {
            (DateTime BeginTime, DateTime EndTime) result = (beginTime, endTime);
            var isEnd = false;
            var _endTime = endTime;
            while (!isEnd)
            {
                var _item = TimeList.Find(t => t.OrderedBeginTime == _endTime);
                if (_item != default)
                {
                    _endTime = _item.OrderedEndTime;
                }
                else
                {
                    isEnd = true;
                }
            }
            result.EndTime = _endTime;
            return Task.FromResult(result);
        }

        /// <summary>
        /// 获取合并后的时间区间
        /// </summary>
        /// <param name="TimeList"></param>
        /// <returns></returns>
        public static async Task<List<(DateTime BeginTime, DateTime EndTime)>> GetMergeTimeRange(List<(DateTime BeginTime, DateTime EndTime)> TimeList)
        {
            var selectedTimeRanges = TimeList.OrderBy(t => t.BeginTime).ToList();
            var beginTime = selectedTimeRanges.First().BeginTime;
            var endTime = selectedTimeRanges.First().EndTime;
            List<(DateTime BeginTime, DateTime EndTime)> orderedTimeList = new List<(DateTime BeginTime, DateTime EndTime)>();
            for (var i = 0; i < selectedTimeRanges.Count; i++)
            {
                var timeAgg = await GetMergeTimeRangeEndTime(selectedTimeRanges, beginTime, endTime);
                if (!orderedTimeList.Any(t => t.BeginTime == timeAgg.BeginTime || t.EndTime == timeAgg.EndTime))
                {
                    orderedTimeList.Add(timeAgg);
                }
                if (i < (selectedTimeRanges.Count - 1))
                {
                    beginTime = selectedTimeRanges[i + 1].BeginTime;
                    endTime = selectedTimeRanges[i + 1].EndTime;
                }
            }
            return orderedTimeList;
        }

    }
}
