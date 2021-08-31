
namespace MJUSS.Infrastructure.Utils.RabbitMqTool
{
    using System.Collections.Generic;

    using RabbitMQ.Client;

    public class RabbitMqQueueCreator
    {
        private readonly string receiveQueueName;
        private readonly string exchangeName;
        public Dictionary<string, object> HeaderDictionary { get; }

        public RabbitMqQueueCreator(string receiveQueueName, string exchangeName, Dictionary<string, object> headerDictionary)
        {
            this.receiveQueueName = receiveQueueName;
            this.exchangeName = exchangeName;
            this.HeaderDictionary = headerDictionary;
        }

        /// <summary>
        /// 创建消息队列
        /// </summary>        
        /// <returns></returns>
        public QueueDeclareOk CreateMessageQueue(bool durable, bool exclusive, bool autoDelete)
        {
            using (var channel = this.GetChannel())
            {
                return this.BindMessageQueue(this.receiveQueueName, channel, durable, exclusive, autoDelete);
            }
        }

        /// <summary>
        /// 创建消息队列
        /// </summary>        
        /// <returns></returns>
        public QueueDeclareOk CreateMessageQueue()
        {
            using (var channel = this.GetChannel())
            {
                return this.BindMessageQueue(this.receiveQueueName, channel);
            }
        }


        private IModel GetChannel()
        {
            var channel = RabbitMqConnectonManager.Instance.GetConnection().CreateModel();
            channel.ExchangeDeclare(this.exchangeName, ExchangeType.Headers, true);
            return channel;
        }

        private QueueDeclareOk BindMessageQueue(string queueName, IModel channel)
        {
            var messageQueue = channel.QueueDeclare(queueName, true, false, false, null);
            channel.QueueBind(queueName, this.exchangeName, "", this.HeaderDictionary);
            return messageQueue;
        }

        private QueueDeclareOk BindMessageQueue(string queueName, IModel channel, bool durable, bool exclusive, bool autoDelete)
        {
            var messageQueue = channel.QueueDeclare(queueName, durable, exclusive, autoDelete, this.HeaderDictionary);
            channel.QueueBind(queueName, this.exchangeName, "", this.HeaderDictionary);
            return messageQueue;
        }
    }
}