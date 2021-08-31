using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.RabbitMqTool
{
    public class OrleansRabbitMqConnectorFactory : IDisposable
    {
        public static readonly OrleansRabbitMqConnectorFactory Instance = new OrleansRabbitMqConnectorFactory();

        private OrleansRabbitMqConnector RMQConnector = null;
        private ILogger Logger=null;

        /// <summary>
        ///     构造函数
        /// </summary>
        private OrleansRabbitMqConnectorFactory()
        {
        }
        public Task<OrleansRabbitMqConnector> CreateRMQConnector(string queueName, ILogger logger, EventHandler<BasicDeliverEventArgs> msgReceiveEvent)
        {
            Logger = logger;
            if (RMQConnector == null)
            {
                RMQConnector = new OrleansRabbitMqConnector(new RabbitMqOptions()
                {
                    HostName = RabbitMqConfigHelper.Instance.RabbitMqIp,
                    VirtualHost = RabbitMqConfigHelper.Instance.RabbitMqVirtualHost,
                    Port = RabbitMqConfigHelper.Instance.RabbitMqPort,
                    UserName = RabbitMqConfigHelper.Instance.RabbitMqUser,
                    Password = RabbitMqConfigHelper.Instance.RabbitMqPassword,
                }, queueName, Logger, msgReceiveEvent);
            }
            return Task.FromResult(RMQConnector);
        }

        public void Dispose()
        {
            try
            {
                RMQConnector.Dispose();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "OrleansRabbitMqConnector Dispose 发生异常");
            }
        }
    }
}
