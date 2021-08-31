using System.ComponentModel;

namespace MJUSS.Infrastructure.Core.BaseTypes
{
    /// <summary>
    /// 应用程序ID
    /// </summary>
    public enum AppIDEnum
    {
        [Description("管理后台")]
        SaasManage = 1000,

        [Description("自助门店系统PC端")]
        UssPC = 2000,

        [Description("自助门店系统用户端")]
        UssUser = 2010,

        [Description("自助门店系统商家端")]
        UssMerchant = 2020,
       
    }
}
