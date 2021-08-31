namespace MJUSS.Infrastructure.Core.Config
{
    using System;
    using System.Collections.Concurrent;

    [Serializable]
    public class RabbitMqConfig
    {
        public string RabbitMqIp { get; set; }

        public ushort RabbitMqPort { get; set; }

        public string RabbitMqUser { get; set; }

        public string RabbitMqPassword { get; set; }

        public string RabbitMqVirtualHost { get; set; }

        public RabbitMqItem[] Items { get; set; }

        private ConcurrentDictionary<string, RabbitMqItem> dicItems;

        public RabbitMqItem FindRabbitMqItemByKey(string key)
        {
            if (this.dicItems != null)
            {
                return this.dicItems[key];
            }
            this.dicItems = new ConcurrentDictionary<string, RabbitMqItem>();
            foreach (var item in this.Items)
                {
                this.dicItems.TryAdd(item.Key, item);
            }
            return this.dicItems[key];
        }

        public RabbitMqItem this[string key] => this.FindRabbitMqItemByKey(key);
    }

    [Serializable]
    public class RabbitMqItem
    {
        public string Key { get; set; }
        public string QueueName { get; set; }

        public string ExchangeName { get; set; }

        public string ArgumentsKey { get; set; }

        public string ArgumentsValue { get; set; }

        
    }
}
