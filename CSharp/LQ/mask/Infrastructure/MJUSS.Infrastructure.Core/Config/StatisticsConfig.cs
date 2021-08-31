using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// 统计数据配置
    /// </summary>
    [Serializable]
    public class StatisticsConfig
    {
        /// <summary>
        /// 同步数据延迟时间
        /// </summary>
        public int SyncDataDelayTime { get; set; } = 1000;
        /// <summary>
        /// 同步清理数据延迟时间
        /// </summary>
        public int SyncClearDataDelayTime { get; set; } = 2000;
        /// <summary>
        /// Reminder定时周期
        /// </summary>
        public int ReminderTimerMinute { get; set; }
        /// <summary>
        /// 修复数据时间
        /// </summary>
        public int FixDataDelayTime { get; set; } = 100;
        /// <summary>
        /// Reminder定时周期
        /// </summary>
        public int FixDataReminderTimerMinute { get; set; } = 5;
        /// <summary>
        /// 数据修复启动小时
        /// </summary>
        public string FixDataStartTime { get; set; } = "02:00:00";
        /// <summary>
        /// 数据修复是否明天
        /// </summary>
        public bool FixDataIsTomorrow { get; set; } = true;
        /// <summary>
        /// 同步库存数据延迟时间
        /// </summary>
        public int SyncStockDataDelayTime { get; set; } = 1000;
    }
}
