using MJUSS.Infrastructure.Core.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Utils.Helper
{
    /// <summary>
    /// SignalRServer配置
    /// </summary>
    public class SignalRServerConfigHelper
    {
        private const string configFilePath = "Config/signalrserver.config";
        public static SignalRServerConfig Instance { get; } = ConfigHandler.GetConfig<SignalRServerConfig>(configFilePath);       
    }
}
