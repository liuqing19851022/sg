using MJUSS.Infrastructure.Core.Config;
using MJUSS.Infrastructure.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Statistics
{
    public class StatisticsConfigHelper
    {
        private const string ConfigPath = "~/Config/StatisticsConfig.config";

        public static StatisticsConfig Instance { get; } = ConfigHandler.GetConfig<StatisticsConfig>(ConfigPath);
    }
}
