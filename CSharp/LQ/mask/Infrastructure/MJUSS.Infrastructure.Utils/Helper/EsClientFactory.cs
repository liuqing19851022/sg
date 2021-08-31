#region C#文件说明
// /**********************************************************************************	
// 	* 类   名 ：EsClientFactory.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJSaas.Infrastructure.Utils
// 	* 文 件 名：EsClientFactory.cs
// 	* 创建时间：2016-05-18 17:02
// 	* 作    者： MJKJ.hermes liu>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion
namespace MJUSS.Infrastructure.Utils.Helper
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Elasticsearch.Net;
    using Microsoft.Extensions.Options;
    using MJUSS.Infrastructure.Core.Config;
    using MJUSS.Infrastructure.Core.Exceptions;
    using MJUSS.Infrastructure.Utils.Helper;
    using Nest;

    public class EsClientFactory : IEsClientFactory
    {
        //private const string esConnectionsConfigFilePath = "Config/ESConnections.config";       

        ///// <summary>
        ///// ElasticClient实例
        ///// </summary>
        //public static readonly ElasticClient Client = CreateElasticClient();



        private ElasticClient client;
        private IOptions<ESConnectionsConfig> configOption;

        public EsClientFactory(IOptions<ESConnectionsConfig> configOption)
        {
            this.configOption = configOption;
        }

        ///// <summary>
        ///// 创建ElasticClient
        ///// </summary>
        ///// <returns></returns>
        //private static ElasticClient CreateElasticClient()
        //{
        //    if (Client == null)
        //    {
        //        try
        //        {
        //            var esConnectionsConnectConfig = ConfigHandler.GetConfig<ESConnectionsConfig>(esConnectionsConfigFilePath);
        //            if (esConnectionsConnectConfig == null)
        //            {
        //                throw new Exception("ESConnections.config配置错误.");
        //            }
        //            if (esConnectionsConnectConfig != null && esConnectionsConnectConfig.EsUris.Count <= 0)
        //            {
        //                throw new Exception("请配置ESConnections.config的Uri信息.");
        //            }
        //            var uris = esConnectionsConnectConfig.EsUris.Select(t => new Uri(t.EsUri));
        //            var uri = uris.FirstOrDefault();               
        //            var pool = new SingleNodeConnectionPool(uri);
        //            var settings = new ConnectionSettings(pool);
        //            if (!string.IsNullOrEmpty(esConnectionsConnectConfig.UserName) && !string.IsNullOrEmpty(esConnectionsConnectConfig.PassWord))
        //            {
        //                settings.BasicAuthentication(esConnectionsConnectConfig.UserName, esConnectionsConnectConfig.PassWord);
        //            }
        //            return new ElasticClient(settings);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("ESConnections.config配置错误.异常信息：" + ex.Message);
        //        }
        //    }
        //    return Client;
        //}

        public Task<ElasticClient> CreateElasticClientAsync()
        {
            var result = CreateElasticClient();
            return Task.FromResult(result);
        }

        public ElasticClient CreateElasticClient()
        {
            if (client == null)
            {
                try
                {
                    var esConnectionsConnectConfig = configOption.Value;
                    if (esConnectionsConnectConfig != null && esConnectionsConnectConfig.EsUris.Count <= 0)
                    {
                        throw new Exception("请配置ESConnections.config的Uri信息.");
                    }
                    var uris = esConnectionsConnectConfig.EsUris.Select(t => new Uri(t.EsUri));
                    var uri = uris.FirstOrDefault();
                    var pool = new SingleNodeConnectionPool(uri);
                    var settings = new ConnectionSettings(pool);
                    if (!string.IsNullOrEmpty(esConnectionsConnectConfig.UserName) && !string.IsNullOrEmpty(esConnectionsConnectConfig.PassWord))
                    {
                        settings.BasicAuthentication(esConnectionsConnectConfig.UserName, esConnectionsConnectConfig.PassWord);
                    }
                    client = new ElasticClient(settings);
                }
                catch (Exception ex)
                {
                    throw new ServiceException("ESConnections.config配置错误.异常信息：" + ex.Message);
                }
            }
            return client;
        }
    }


    public interface IEsClientFactory
    {
        /// <summary>
        /// 创建ElasticClient
        /// </summary>
        /// <returns></returns>
        Task<ElasticClient> CreateElasticClientAsync();
        /// <summary>
        /// 创建ElasticClient
        /// </summary>
        /// <returns></returns>
        ElasticClient CreateElasticClient();
    }
}