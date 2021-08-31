using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    /// <summary>
    /// es刷新时间
    /// </summary>
    public class EsRefreshAttribute : Attribute
    {
        /// <summary>
        /// 刷新时间 单位：秒
        /// </summary>
        public int RefreshTime { get; set; }
        public EsRefreshAttribute(int refreshTime = 1)
        {
            this.RefreshTime = refreshTime;
        }
    }
}
