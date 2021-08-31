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

    [Serializable]
    public class SiloHostServer
    {
        public string ServiceName { get; set; }

        public string ServiceUrl { get; set; }
    }

    [Serializable]
    public class SiloHostsConfig
    {
        private ConcurrentDictionary<string, string> _dictionary;
        public string this[string key] => this.GetSettingValue(key);

        /// <summary>
        /// 获取服务地址
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetSettingValue(string key)
        {
            if (this._dictionary != null)
            {
                return this._dictionary[key];
            }
            this._dictionary = new ConcurrentDictionary<string, string>();
            foreach (var item in this.Items)
            {
                this._dictionary.TryAdd(item.ServiceName, item.ServiceUrl);
            }
            return this._dictionary[key];
        }

        /// <summary>
        /// 获取服务配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SiloHostServer GetItem(string key)
        {
            return this.Items.FirstOrDefault(item => item.ServiceName == key);
        }

        public SiloHostServer[] Items { get; set; }

        public int PlatformType { get; set; }
    }
}