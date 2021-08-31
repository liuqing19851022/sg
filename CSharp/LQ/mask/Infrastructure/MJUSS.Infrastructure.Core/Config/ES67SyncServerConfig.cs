using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// ES67配置
    /// </summary>
    [Serializable]
    public class ES67SyncConfig
    {

        /// <summary>
        /// 同步数据量
        /// </summary>
        public int SyncDataCount { get; set; } = 100;
        /// <summary>
        /// 是否启用同步
        /// </summary>
        public bool IsEnableSync { get; set; } = true;
        public string RabbitMqIp { get; set; }

        public ushort RabbitMqPort { get; set; }

        public string RabbitMqUser { get; set; }

        public string RabbitMqPassword { get; set; }

        public string RabbitMqVirtualHost { get; set; }
    }
}
