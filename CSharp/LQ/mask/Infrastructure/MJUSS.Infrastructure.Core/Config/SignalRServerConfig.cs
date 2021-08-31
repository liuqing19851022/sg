using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// SignalR服务器配置
    /// </summary>
    [Serializable]
    public class SignalRServerConfig
    {
        public List<SignalRServerUri> Servers { get; set; }
    }

    [Serializable]
    public class SignalRServerUri
    {
        public string Uri { get; set; }
    }

    [Serializable]
    public class SignalRConfig
    {
        public string Url { get; set; }
    }

}
