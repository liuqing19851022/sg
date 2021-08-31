using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJUSS.Infrastructure.Core.Config
{
    /// <summary>
    /// grpc服务配置
    /// </summary>
    [Serializable]
    [DataContract]
    public class IotMerchantGrpcConfig
    {
        [DataMember]
        public string gRpcUrl { get; set; }
    }
}
