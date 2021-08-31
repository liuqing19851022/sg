using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJUSS.Infrastructure.Core.Common
{

    [Serializable]
    [DataContract]
    public class RequestPageDataBase {
        /// <summary>
        /// 页数
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页大小
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RequestPageData<T> : RequestPageDataBase
    {
        

        [DataMember]
        public T Filter { get; set; }
    }
}
