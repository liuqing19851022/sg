

namespace MJUSS.Infrastructure.Core.BaseClass
{
    using Error;
    using System.Runtime.Serialization;

    /// <summary>
    /// 数据响应泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    [DataContract]
    public class RespondData<T> : RespondDataBase
    {
        /// <summary>
        /// 数据
        /// </summary>
        [DataMember]
        public T Data { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMessage">错误消息</param>
        /// <param name="data">数据</param>
        public RespondData(int errorCode, string errorMessage, T data)
            : base(errorCode, errorMessage)
        {
            this.Data = data;
        }

        public RespondData(RespondDataBase respond) :base(respond.ErrorCode,respond.ErrorMessage) {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">数据</param>
        public RespondData(T data)
        {
            this.Data = data;
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public RespondData()
        {
        }

        public RespondData(ErrorCodeItem errInfo)
            : base(errInfo)
        {

        }
    }
}