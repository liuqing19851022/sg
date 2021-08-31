using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// ElasticSearch的Uri地址配置
    /// </summary>
    [Serializable]
    public class ESConnectionsConfig
    {
        /// <summary>
        /// ElasticSearch的Uri地址
        /// </summary>
        public List<ESUriOption> EsUris { get; set; } = new List<ESUriOption>() { 
            new ESUriOption{ 
                EsUri = "http://localhost:9200"
            }
        };
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; } = string.Empty;
    }

    /// <summary>
    /// ElasticSearch的Uri配置项
    /// </summary>
    [Serializable]
    public class ESUriOption
    {
        public string EsUri { get; set; } = string.Empty;
    }
}
