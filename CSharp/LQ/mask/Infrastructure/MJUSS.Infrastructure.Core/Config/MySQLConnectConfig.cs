
namespace MJUSS.Infrastructure.Core.Config
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// MySQL数据库连接配置
    /// </summary>
    [Serializable]
    public class MySQLConnectConfig
    {
        /// <summary>
        /// 服务器组
        /// </summary>
        public MySqlServer[] Servers { get; set; }

        private ConcurrentDictionary<string, MySqlServer> dicItems;

        public MySqlServer FindRabbitMqItemByKey(string key)
        {
            if (this.dicItems != null)
            {
                return this.dicItems[key];
            }
            this.dicItems = new ConcurrentDictionary<string, MySqlServer>();
            foreach (var item in this.Servers)
            {
                this.dicItems.TryAdd(item.DataBase, item);
            }
            return this.dicItems[key];
        }

        public MySqlServer this[string key] => this.FindRabbitMqItemByKey(key);
    }

    [Serializable]
    public class MySqlServer
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 数据库
        /// </summary>

        public string DataBase { get; set; }
        /// <summary>
        /// 帐号
        /// </summary>

        public string UserID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>

        public string Password { get; set; }
        /// <summary>
        /// 字符集，默认utf8
        /// </summary>
        public string Charset { get; set; } = "utf8";
        public uint Port { get; set; } = 3306;

    }
}