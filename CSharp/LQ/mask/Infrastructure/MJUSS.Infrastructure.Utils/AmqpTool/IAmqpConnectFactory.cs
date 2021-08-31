using Amqp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.AmqpTool
{
    /// <summary>
    /// amqp 连接工厂
    /// </summary>
    public interface IAmqpConnectFactory
    {
        Task<Connection> GetConnection(string amqpConsumerGroupId);
    }
}
