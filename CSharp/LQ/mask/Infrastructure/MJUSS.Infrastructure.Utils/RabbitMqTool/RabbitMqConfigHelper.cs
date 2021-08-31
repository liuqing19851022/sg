
namespace MJUSS.Infrastructure.Utils.RabbitMqTool
{
    using Core.Config;
    using Helper;

    public class RabbitMqConfigHelper
    {
        private RabbitMqConfigHelper()
        {}
        private const string ConfigPath = "~/Config/RabbitMqConfig.config";

        public static RabbitMqConfig Instance { get; } = ConfigHandler.GetConfig<RabbitMqConfig>(ConfigPath);
    }
}
