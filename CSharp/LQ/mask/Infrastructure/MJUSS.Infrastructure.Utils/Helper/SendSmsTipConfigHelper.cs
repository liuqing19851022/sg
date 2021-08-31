using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MJUSS.Infrastructure.Core.Config;

namespace MJUSS.Infrastructure.Utils.Helper
{
    public class SendSmsTipConfigHelper
    {
        private const string ConfigPath = "~/Config/SendSmsTipConfig.config";

        public static SendSmsTipConfig Instance { get; } = ConfigHandler.GetConfig<SendSmsTipConfig>(ConfigPath);

        public static void Save() {
            ConfigHandler.Save(Instance, ConfigPath);
        }
    }
    
}
