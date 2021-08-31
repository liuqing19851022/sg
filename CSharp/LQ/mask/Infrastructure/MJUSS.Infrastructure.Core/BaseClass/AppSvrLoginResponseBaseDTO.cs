using MJUSS.Infrastructure.Core.CustomAttributes;
using System;
using System.Runtime.Serialization;

namespace MJUSS.Infrastructure.Core.BaseClass
{
    /// <summary>
    /// 登录响应基类
    /// </summary>
    [DataContract]
    [Serializable]
    [GenerateTsViewModel]
    public class AppSvrLoginResponseBaseDTO
    {
        [DataMember]
        public string SessionID { get; set; }
    }
}
