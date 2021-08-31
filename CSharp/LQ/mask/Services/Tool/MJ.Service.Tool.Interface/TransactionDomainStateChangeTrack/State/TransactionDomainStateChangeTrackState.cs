using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJ.Service.Tool.Interface.TransactionDomainStateChangeTrack.State
{
    /// <summary>
    /// 事务数据变更
    /// </summary>
    [Serializable]
    [DataContract]
    public class TransactionDomainStateChangeTrackState
    {
        /// <summary>
        /// 事务编号
        /// </summary>
        [DataMember]
        public string TransactionID { get; set; }
        /// <summary>
        /// 事务数据列表
        /// </summary>
        [DataMember]
        public List<StateChangeTrackingData> StateChangeTrackingDataList { get; set; } = new List<StateChangeTrackingData>();
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [DataMember]
        public DateTime LastUpdateTime { get; set; }
    }

    [Serializable]
    [DataContract]
    public class StateChangeTrackingData
    {
        /// <summary>
        /// 数据编号
        /// </summary>
        [DataMember]
        public string DataID { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string StateName { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        [DataMember]
        public string ModuleName { get; set; }
        /// <summary>
        /// 数据内容
        /// </summary>
        [DataMember]
        public string Data { get; set; }
    }
}
