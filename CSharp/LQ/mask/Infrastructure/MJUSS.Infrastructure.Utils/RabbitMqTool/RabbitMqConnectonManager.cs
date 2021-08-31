namespace MJUSS.Infrastructure.Utils.RabbitMqTool
{
    using System;

    using RabbitMQ.Client;

    /// <summary>
    ///     mq连接管理器
    /// </summary>
    public class RabbitMqConnectonManager : IDisposable
    {
        /// <summary>
        ///     实例
        /// </summary>
        public static readonly RabbitMqConnectonManager Instance = new RabbitMqConnectonManager();

        private IConnection connection;

        /// <summary>
        ///     构造函数
        /// </summary>
        private RabbitMqConnectonManager()
        {
        }

        public void Dispose()
        {
            if (this.connection != null)
            {
                this.connection.Close();
            }
        }

        /// <summary>
        ///     获取连接
        /// </summary>
        /// <returns></returns>
        public IConnection GetConnection()
        {
            if (this.connection == null || !this.connection.IsOpen)
            {
                this.connection = this.GetConnectionFactory().CreateConnection();
            }
            return this.connection;
        }

        /// <summary>
        ///     获取连接工厂
        /// </summary>
        /// <returns></returns>
        public ConnectionFactory GetConnectionFactory()
        {
            var factory = new ConnectionFactory
            {
                UserName = RabbitMqConfigHelper.Instance.RabbitMqUser,
                Password = RabbitMqConfigHelper.Instance.RabbitMqPassword,
                VirtualHost = RabbitMqConfigHelper.Instance.RabbitMqVirtualHost,
                Port = RabbitMqConfigHelper.Instance.RabbitMqPort,
                HostName = RabbitMqConfigHelper.Instance.RabbitMqIp,
                AutomaticRecoveryEnabled = true
            };
            return factory;
        }

        /// <summary>
        ///     获取连接工厂
        /// </summary>
        /// <returns></returns>
        public IConnection GetConnection(string hostName, int port, string userName, string password, string virtualHost = "/")
        {
            if (this.connection == null || !this.connection.IsOpen)
            {
                this.connection = new ConnectionFactory
                {
                    UserName = userName,
                    Password = password,
                    VirtualHost = virtualHost,
                    Port = port,
                    HostName = hostName,
                    AutomaticRecoveryEnabled = true
                }.CreateConnection();
            }
            return this.connection;
        }
    }
}