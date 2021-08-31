using System;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    public class AdNavigationPositionPageAttribute : Attribute
    {
        /// <summary>
        /// 目标页面
        /// </summary>
        public string TargetPage { get; set; }
        public AdNavigationPositionPageAttribute(string targetPage)
        {
            this.TargetPage = targetPage;
        }
    }
}
