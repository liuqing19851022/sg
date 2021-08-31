#region C#文件说明

// /**********************************************************************************	
// 	* 类   名 ：SiloHostWebAPIFactory.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Utils
// 	* 文 件 名：SiloHostWebAPIFactory.cs
// 	* 创建时间：2016-05-13 10:00
// 	* 作    者： MJKJ.hermes liu>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/

#endregion

namespace MJUSS.Infrastructure.Utils.Orlelans
{
    using System;

    using MJUSS.Infrastructure.Core.Config;
    using MJUSS.Infrastructure.Utils.Helper;

    /// <summary>
    /// SiloHost WebApi服务地址
    /// </summary>
    public class SiloHostWebAPIFactory
    {
        private const string siloHostWebAPIConfigFilePath = "~/Config/SiloHostWebAPIConfig.config";

        /// <summary>
        /// 根据服务名获取服务地址
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static string GetSiloHostWebApiUrl(string serviceName)
        {
            //升级后不再需要使用webapi
            return string.Empty;
            //try
            //{
            //   var siloHostWebAPIConfig = ConfigHandler.GetConfig<SiloHostsConfig>(siloHostWebAPIConfigFilePath);
            //    return siloHostWebAPIConfig[serviceName];
            //}
            //catch 
            //{
            //    throw new Exception(serviceName+" SiloHostWebAPIConfig错误.");
            //}
            
        }
    }
}