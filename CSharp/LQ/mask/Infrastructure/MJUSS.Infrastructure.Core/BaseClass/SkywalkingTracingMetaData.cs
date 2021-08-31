
namespace MJUSS.Infrastructure.Core.BaseClass
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public class SkywalkingTracingMetaData
    {
        [DataMember]
        public Guid TraceSegmentId { get; set; }
        /// <summary>
        /// 跟踪编号
        /// </summary>
        [DataMember]
        public Guid TracingID { get; set; }
        /// <summary>
        /// 服务名称
        /// </summary>
        [DataMember]
        public string ServiceName { get; set; }
        /// <summary>
        /// 服务实例
        /// </summary>
        [DataMember]
        public string ServiceInstance { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        [DataMember]
        public Guid ParentTraceSegmentId { get; set; }
        /// <summary>
        /// 父级跟踪编号
        /// </summary>
        [DataMember]
        public Guid ParentTracingID { get; set; }
        /// <summary>
        /// 父级服务名称
        /// </summary>
        [DataMember]
        public string ParentServiceName { get; set; }
        /// <summary>
        /// 父级服务实例
        /// </summary>
        [DataMember]
        public string ParentServiceInstance { get; set; }

    }


}
