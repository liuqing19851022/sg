using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJ.Service.Tool.Interface.DataChange.Param
{
    /// <summary>
    /// 发布变更数据
    /// </summary>
    [DataContract]
    [Serializable]
    public class RequestPublishChangeDataParam
    {
        /// <summary>
        /// 变更数据列表
        /// </summary>
        [DataMember]
        public List<ChangeDataDTO> ChangeDataList { get; set; } = new List<ChangeDataDTO>();
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string StateName { get; set; }
    }

    [DataContract]
    [Serializable]
    public class ChangeDataDTO
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
    }

}
