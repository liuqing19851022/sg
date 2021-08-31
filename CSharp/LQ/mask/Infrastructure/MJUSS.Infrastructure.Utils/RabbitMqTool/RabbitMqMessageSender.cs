namespace MJUSS.Infrastructure.Utils.RabbitMqTool
{
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MJUSS.Infrastructure.Core.BaseClass;

    using Newtonsoft.Json.Linq;

    using RabbitMQ.Client;

    /// <summary>
    /// mq消息发送器
    /// </summary>
    public class RabbitMqMessageSender
    {
        private readonly string exchangeName;
        private readonly IConnection connection;
        private readonly Dictionary<string, object> headerProperty;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connection">连接器</param>
        /// <param name="headerProperty">头属性(消息路由使用)</param>
        /// <param name="exchangeName">交换队列名称</param>
        public RabbitMqMessageSender(IConnection connection, Dictionary<string, object> headerProperty, string exchangeName)
        {
            this.connection = connection;
            this.exchangeName = exchangeName;
            this.headerProperty = headerProperty;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="headerProperty">头属性(消息路由使用)</param>
        /// <param name="exchangeName">交换器名称</param>
        public RabbitMqMessageSender(Dictionary<string, object> headerProperty,string exchangeName)
        {
            this.connection = RabbitMqConnectonManager.Instance.GetConnection();
            this.exchangeName = exchangeName;
            this.headerProperty = headerProperty;
        }
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="data"></param>
        /// <param name="durable">持久化</param>
        public Task Send(byte[] data, bool durable = true)
        {
            var channel = this.connection.CreateModel();
            try
            {
                channel.ExchangeDeclare(this.exchangeName, ExchangeType.Headers, true);
                var channelProperty = channel.CreateBasicProperties();
                channelProperty.Headers = this.headerProperty;
                channelProperty.DeliveryMode = (byte)(durable ? 2 : 1);
                channel.BasicPublish(this.exchangeName, "", false,channelProperty,data);
                return Task.FromResult(1);
            }
            finally
            {
                channel.Close();
            }
        }
        
        public async Task Send(RespondDataBase data, bool durable = true)
        {
           await this.Send(Encoding.UTF8.GetBytes(JObject.FromObject(data).ToString(Newtonsoft.Json.Formatting.None)), durable);
        }
    }
}