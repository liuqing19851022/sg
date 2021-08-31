#region C#文件说明
// /**********************************************************************************	
// 	* 类   名 ：SiloHostsConfig.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Core
// 	* 文 件 名：SiloHostsConfig.cs
// 	* 创建时间：2016-05-13 9:55
// 	* 作    者： MJKJ.hermes liu>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion
namespace MJUSS.Infrastructure.Core.Config
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    /// <summary>
    /// 服务器端配置
    /// </summary>
    [Serializable]
    public class SiloHostServerConfig
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP{ get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int SiloPort { get; set; }
        /// <summary>
        /// 网关端口
        /// </summary>
        public int GatewayPort { get; set; }
        /// <summary>
        /// 部署编号
        /// </summary>
        public string ClusterId { get; set; }
        /// <summary>
        /// 服务编号
        /// </summary>
        public string ServiceId { get; set; }
        /// <summary>
        /// 记录最低日志级别
        /// Information = 2, Warning = 3,Error = 4,None = 6
        /// </summary>
        public int MinLogLevel { get; set; }
        /// <summary>
        /// ado.net 驱动
        /// </summary>
        public string AdoNetClusteringInvariant { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string AdoNetClusteringConnectionString { get; set; }
        /// <summary>
        /// ado.net 驱动
        /// </summary>
        public string AdoNetReminderServiceInvariant { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string AdoNetReminderServiceConnectionString { get; set; }
        /// <summary>
        /// PubSubStorage ado.net 驱动
        /// </summary>
        public string AdoNetPuSubStorageInvariant { get; set; }
        /// <summary>
        /// PubSubStorage连接字符串
        /// </summary>
        public string AdoNetPuSubStorageConnectionString { get; set; }
        /// <summary>
        /// DefaultStorage ado.net 驱动
        /// </summary>
        public string AdoNetDefaultStorageInvariant { get; set; }
        /// <summary>
        /// DefaultStorage连接字符串
        /// </summary>
        public string AdoNetDefaultStorageConnectionString { get; set; }
        /// <summary>
        /// 是否使用队列
        /// </summary>
        public bool IsUseMq { get; set; }
        /// <summary>
        /// 队列数
        /// </summary>
        public int MqQueueNumber { get; set; } = 4;

        /// <summary>
        /// Grain垃圾回收时间
        /// </summary>
        public int GrainCollectionMinutes { get; set; } = 10;

        /// <summary>
        /// 秒数
        /// </summary>
        public int ResponseTimeoutSeconds { get; set; } = 30;

        /// <summary>
        /// OrleansDashboard端口
        /// </summary>
        public int OrleansDashboardPort { get; set; } = 0;

        /// <summary>
        /// 是否启用日志过滤器,默认关闭
        /// </summary>
        public bool EnableLoggingCallFilter { get; set; } = false;
        /// <summary>
        /// 是否启用 skywalking
        /// </summary>
        public bool EnableSkywalking { get; set; } = false;
        /// <summary>
        /// 静态部署的Silo名称(Stream使用)
        /// </summary>
        public string StaticClusterDeploymentSiloNames { get; set; } = string.Empty;
    }
 

    //[Serializable]
    //public class SiloHostsConfig
    //{
    //    private ConcurrentDictionary<string, string> _dictionary;
    //    public string this[string key] => this.GetSettingValue(key);

    //    /// <summary>
    //    /// 获取服务地址
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <returns></returns>
    //    public string GetSettingValue(string key)
    //    {
    //        if (this._dictionary != null)
    //        {
    //            return this._dictionary[key];
    //        }
    //        this._dictionary = new ConcurrentDictionary<string, string>();
    //        foreach (var item in this.Items)
    //        {
    //            this._dictionary.TryAdd(item.ServiceName, item);
    //        }
    //        return this._dictionary[key];
    //    }

    //    /// <summary>
    //    /// 获取服务配置
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <returns></returns>
    //    public SiloHostServer GetItem(string key)
    //    {
    //        return this.Items.FirstOrDefault(item => item.ServiceName == key);
    //    }

    //    public SiloHostServer[] Items { get; set; }

    //    public int PlatformType { get; set; }
    //}
}