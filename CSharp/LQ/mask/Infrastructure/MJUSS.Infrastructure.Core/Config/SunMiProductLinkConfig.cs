using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// 商米产品关联编号配置
    /// </summary>
    [Serializable]
    public class SunMiProductLinkConfig
    {
        /// <summary>
        /// 配置列表
        /// </summary>
        public List<SunMiProductLinkConfigItem> ConfigList { get; set; } = new List<SunMiProductLinkConfigItem>();
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SunMiProductLinkConfigItem
    {
        /// <summary>
        /// 商米产品编码
        /// </summary>
        public string SunMiProductCode { get; set; }
        /// <summary>
        /// 茗匠产品编码
        /// </summary>
        public string MjProductCode { get; set; }
    }
}
