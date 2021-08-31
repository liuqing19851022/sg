namespace MJUSS.Infrastructure.Utils.RabbitMqTool
{
    using System;

    /// <summary>
    /// 消息队列的一些定义
    /// </summary>
    public class RabbitMqDefineConfig
    {
        /// <summary>
        /// 交换器名称
        /// </summary>
        public static string ExchangeName { get; private set; }
        /// <summary>
        /// 服务器端队列名称
        /// </summary>
        public static string ServerQueueName { get; private set; }
        /// <summary>
        /// 服务器名称
        /// </summary>
        public static string ServerName  { get; private set; }
        /// <summary>
        /// 服务器名称key
        /// </summary>
        public static string ServerNameKey { get; private set; }
        /// <summary>
        /// 人员编号key
        /// </summary>
        public static string PersonIdKey { get; private set; }
        /// <summary>
        /// 广播交换器
        /// </summary>
        public static string BroadcastingExchange { get; private set; }
        /// <summary>
        /// 同步数据平台类型key
        /// </summary>
        public static string SyncPlatformTypeDataKey { get; private set; }
        /// <summary>
        /// 同步出错Key
        /// </summary>
        public static string SyncErrorDataKey { get; private set; }
        /// <summary>
        /// 同步天地网队列名
        /// </summary>
        public static string SyncZyctdQueueName { get; private set; }
        /// <summary>
        /// 同步买卖通队列名
        /// </summary>
        public static string SyncZycmmtQueueName { get; private set; }
        /// <summary>
        /// 同步支付队列名
        /// </summary>
        public static string SyncCTSQueueName { get; private set; }
        /// <summary>
        /// 同步通联支付队列名
        /// </summary>
        public static string SyncAllinpayQueueName { get; private set; }
        /// <summary>
        /// 同步Epay队列名
        /// </summary>
        public static string SyncEpayQueueName { get; private set; }

        /// <summary>
        /// 同步交换器名称
        /// </summary>
        public static string SyncExchangeName { get; private set; }
        /// <summary>
        /// 同步客户端队列名称
        /// </summary>
        public static string SyncClientQueueName { get; private set; }

        /// <summary>
        /// 同步队列名称
        /// </summary>
        public static string SyncDataCenterQueueName { get; private set; }
        /// <summary>
        /// 全文索引买卖通队列名
        /// </summary>
        public static string FullTextIndexZycmmtQueueName { get; private set; }
        /// <summary>
        /// 全文索引的队列键
        /// </summary>
        public static string FullTextIndexValueKey { get; private set; }
        /// <summary>
        /// 全文索引的队列值
        /// </summary>
        public static string FullTextIndexValue { get; private set; }
        /// <summary>
        /// 全文索引的交换器
        /// </summary>
        public static string FullTextIndexExchangeName { get; private set; }
        /// <summary>
        /// 同时处理全文索引队列数量
        /// </summary>
        public static int FullTextIndexUpdateQuqueCount { get; private set; }
        /// <summary>
        /// 推送服务交换器名称
        /// </summary>
        public static string PushServerExchangeName { get; private set; }
        /// <summary>
        /// 管易oms队列名称
        /// </summary>
        public static string GuanyiOMSQueueName { get; private set; }

        static RabbitMqDefineConfig()
        {
            
        }
    }
}