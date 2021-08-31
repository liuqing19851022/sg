
namespace MJUSS.Infrastructure.Core.BaseClass
{
    using Error;
    using System.Runtime.Serialization;

    /// <summary>
    /// 数据响应基类
    /// </summary>
    [System.Serializable]
    [DataContract]
    public class RespondDataBase
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [DataMember]
        public int ErrorCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 命令名称
        /// </summary>
        [DataMember]
        public string CommandName { get; set; }
        /// <summary>
        /// 加密TripleDes密钥Key(rsa加过密)
        /// </summary>
        [DataMember]
        public byte[] TripleDesKey { get; set; }
        /// <summary>
        /// 加密TripleDes密钥IV(rsa加过密)
        /// </summary>
        [DataMember]
        public byte[] TripleDesIV { get; set; }
        /// <summary>
        /// 加密数据
        /// </summary>
        [DataMember]
        public byte[] EncryptData { get; set; }
        /// <summary>
        /// 是否是重复执行
        /// </summary>
        [DataMember]
        public bool IsDuplicateExecute { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorCode">错误码</param>
        public RespondDataBase(int errorCode)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMessage">错误消息</param>
        public RespondDataBase(int errorCode, string errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }


        public RespondDataBase(ErrorCodeItem errInfo) 
            :this(errInfo.ErrorCode, errInfo.ErrorMessage) {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public RespondDataBase()
        {
            this.ErrorCode = Error.MJErrorCode.Success.ErrorCode;
        }
    }
}
