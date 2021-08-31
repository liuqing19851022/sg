
namespace MJUSS.Infrastructure.Utils.RabbitMqTool
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    /// <summary>
    /// 消息接收器
    /// </summary>
    public class RabbitMqMessageReceiver : IDisposable
    {
        private readonly string receiveQueueName;
        private readonly string exchangeName;
        private readonly IConnection connection;
        public Dictionary<string, object> HeaderDictionary { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="receiveQueueName"></param>
        /// <param name="headerDictionary"></param>
        /// <param name="exchangeName"></param>
        public RabbitMqMessageReceiver(string receiveQueueName, Dictionary<string, object> headerDictionary, string exchangeName)
        {
            this.receiveQueueName = receiveQueueName;
            this.exchangeName = exchangeName;
            this.HeaderDictionary = headerDictionary;
            this.connection = RabbitMqConnectonManager.Instance.GetConnection();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="receiveQueueName"></param>
        /// <param name="headerDictionary"></param>
        /// <param name="exchangeName"></param>
        /// <param name="connection"></param>
        public RabbitMqMessageReceiver(string receiveQueueName, Dictionary<string, object> headerDictionary, string exchangeName, IConnection connection)
        {
            this.receiveQueueName = receiveQueueName;
            this.exchangeName = exchangeName;
            this.HeaderDictionary = headerDictionary;
            this.connection = connection;
        }
        
        private IModel receiveChannel;
        private EventingBasicConsumer receiveConsumer;
        public IModel ReceiveChannel
        {
            get
            {
                if (this.receiveChannel != null)
                {
                    return this.receiveChannel;
                }
                this.receiveChannel = this.GetChannel();
                this.receiveConsumer = new EventingBasicConsumer(this.receiveChannel);
                this.receiveChannel.BasicConsume(this.receiveQueueName, false, this.receiveConsumer);
                return this.receiveChannel;
            }
        }
     
        /// <summary>
        /// 接收
        /// </summary>
        /// <returns></returns>
        public Task<object> Receive()
        {
            this.BindMessageQueue(this.receiveQueueName, this.ReceiveChannel);
            BasicDeliverEventArgs result = null;
            this.receiveConsumer.Received += (model, ea) =>
                {result = ea;};
            return Task.FromResult((object)result);
        }
        /// <summary>
        /// 接收
        /// </summary>
        /// <returns></returns>
        public Task<object> Receive(int millisecondsTimeout)
        {
            BasicDeliverEventArgs result = null;
            this.BindMessageQueue(this.receiveQueueName, this.ReceiveChannel);
            this.receiveConsumer.Received += (model, ea) =>
            { result = ea; };
            return Task.FromResult((object)result);
        }

       
        /// <summary>
        /// 确认消息已经处理
        /// </summary>
        /// <param name="deliveryTag"></param>
        public Task AckMessage(ulong deliveryTag)
        {
            this.ReceiveChannel.BasicAck(deliveryTag, false);
            return Task.FromResult(1);
        }

        /// <summary>
        /// 确认消息已经处理
        /// </summary>
        /// <param name="deliveryTag"></param>
        /// <param name="multiple"></param>
        public Task AckMessage(ulong deliveryTag, bool multiple)
        {
            this.ReceiveChannel.BasicAck(deliveryTag, multiple);
            return Task.FromResult(1);
        }

        /// <summary>
        /// 重新加入队列
        /// </summary>
        /// <param name="deliveryTag"></param>
        public void RequeueMessage(ulong deliveryTag)
        {
            this.ReceiveChannel.BasicReject(deliveryTag, true);
        }


        public IModel GetChannel()
        {
            var channel = this.connection.CreateModel();
            channel.ExchangeDeclare(this.exchangeName, ExchangeType.Headers, true);
            return channel;
        }

        private void BindMessageQueue(string queueName, IModel channel)
        {
            channel.QueueDeclare(queueName, true, false, false, null);
            channel.QueueBind(queueName, this.exchangeName, "", this.HeaderDictionary);
        }

        public void Dispose()
        {
            if (this.receiveChannel != null) this.receiveChannel.Close();
        }
    }
}
