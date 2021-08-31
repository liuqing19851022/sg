using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJ.Service.Tool.Interface.TransactionDomainStateChangeTrack.Param
{
    /// <summary>
    /// 领域模型数据变更参数
    /// </summary>
    [Serializable]
    [DataContract]
    public class RequestDomainStateChangeParam
    {
        /// <summary>
        /// 事务编号
        /// </summary>
        [DataMember]
        public string TransactionID { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        [DataMember]
        public string DomainStateName { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        [DataMember]
        public string ModuleName { get; set; }
        /// <summary>
        /// 数据编号
        /// </summary>
        [DataMember]
        public string DataID { get; set; }
        /// <summary>
        /// 数据内容
        /// </summary>
        [DataMember]
        public string Data { get; set; }
    }
}
