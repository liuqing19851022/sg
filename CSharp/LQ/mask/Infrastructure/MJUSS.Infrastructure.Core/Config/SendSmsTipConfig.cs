using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.Config
{
    [Serializable]
    public class SendSmsTipConfig
    {
        /// <summary>
        /// 第一次启动服务后，默认10秒后执行reminder
        /// </summary>
        public int FristStartDueTime { get; set; } = 10;

        /// <summary>
        /// 避免timer长时间空闲被销毁，默认间隔5分钟后通过reminder再次调用
        /// </summary>
        public int RegisterOrUpdateReminderPeriod { get; set; } = 5;

        /// <summary>
        /// timer执行处理的间隔周期，默认100毫秒
        /// </summary>
        public int RegisterTimerPeriod { get; set; } = 100;

        /// <summary>
        /// 默认执行时间为凌晨2点（24小时制）
        /// </summary>
        public int ExecuteTime { get; set; } = 2;
    }
}
