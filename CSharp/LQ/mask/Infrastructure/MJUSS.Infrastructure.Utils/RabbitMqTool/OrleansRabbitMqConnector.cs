using Microsoft.Extensions.Logging;
using MJUSS.Infrastructure.Core.Constants;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace MJUSS.Infrastructure.Utils.RabbitMqTool
{
    public class OrleansRabbitMqConnector : IDisposable
    {
        private readonly string QueueName;
        private readonly ILogger Logger;
        private readonly RabbitMqOptions _options;
        private IConnection _connection;
        private IModel _channel;
        private readonly EventHandler<BasicDeliverEventArgs> MsgReceiveEvent = null;
        public IModel Channel
        {
            get
            {
                EnsureConnection();
                return _channel;
            }
        }

        public OrleansRabbitMqConnector(RabbitMqOptions options, string queueName, ILogger logger,EventHandler<BasicDeliverEventArgs> msgReceiveEvent)
        {
            _options = options;
            Logger = logger;
            QueueName = queueName;
            MsgReceiveEvent = msgReceiveEvent;
        }

        private void EnsureConnection()
        {
            if (_connection?.IsOpen != true)
            {
                Logger.LogDebug("打开一个新的 RMQ 连接...");
                var factory = new ConnectionFactory
                {
                    HostName = _options.HostName,
                    VirtualHost = _options.VirtualHost,
                    Port = _options.Port,
                    UserName = _options.UserName,
                    Password = _options.Password,
                    UseBackgroundThreadsForIO = false,
                    AutomaticRecoveryEnabled = false,
                    NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
                };

                _connection = factory.CreateConnection();
                Logger.LogDebug("连接已成功创建.");
                _connection.ConnectionShutdown += OnConnectionShutdown;
                _connection.ConnectionBlocked += OnConnectionBlocked;
                _connection.ConnectionUnblocked += OnConnectionUnblocked;
            }

            if (_channel?.IsOpen != true)
            {
                Logger.LogDebug("创建一个通道.");
                if (MsgReceiveEvent != null)
                {
                    _channel = _connection.CreateModel();
                    _channel.ExchangeDeclare(MqServiceConstants.DefaultExchangeName, MqServiceConstants.DefaultExchangeType, true, false, null);
                    _channel.QueueDeclare(QueueName, true, false, false, null);
                    _channel.QueueBind(QueueName, MqServiceConstants.DefaultExchangeName, QueueName);
                    var consumer = new EventingBasicConsumer(_channel);
                    consumer.Received += MsgReceiveEvent;
                    _channel.BasicConsume(QueueName, false, consumer);
                }
                else
                {
                    throw new Exception("请指定消息订阅事件");
                }
                _channel.ConfirmSelect();   // manual (N)ACK
                Logger.LogDebug("通道已创建.");
            }
        }

        public void Dispose()
        {
            try
            {
                if (_channel?.IsClosed == false)
                {
                    _channel.Close();
                }
                _connection?.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "错误发生在 RMQ 连接关闭期间.");
            }
        }

        private void OnConnectionShutdown(object connection, ShutdownEventArgs reason)
        {
            Logger.LogWarning($"RMQ连接被关闭: [{reason.ReplyText}]");
        }

        private void OnConnectionBlocked(object connection, ConnectionBlockedEventArgs reason)
        {
            Logger.LogWarning($"RMQ连接被阻塞: [{reason.Reason}]");
        }

        private void OnConnectionUnblocked(object connection, EventArgs args)
        {
            Logger.LogWarning("RMQ连接阻塞消除.");
        }
    }
}
