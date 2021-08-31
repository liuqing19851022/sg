
namespace MJUSS.Infrastructure.Core.BaseClass
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// 请求数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    [DataContract]
    public class RequestData<T> : RequestDataBase
    {
        /// <summary>
        /// 数据
        /// </summary>
        [DataMember]
        public T Data { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public RequestData()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">数据</param>
        public RequestData(T data)
        {
            this.Data = data;
        }
    }
}
