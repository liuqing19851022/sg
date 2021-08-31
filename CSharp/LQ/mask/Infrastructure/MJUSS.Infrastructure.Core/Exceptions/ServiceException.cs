namespace MJUSS.Infrastructure.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using MJUSS.Infrastructure.Core.Error;

    /// <summary>
    ///     服务异常
    /// </summary>
    [Serializable]
    public class ServiceException : BaseException
    {
        public ServiceException() {

        }
        public ServiceException(string msg,int errorCode) : base(errorCode,msg) {

        }

        public ServiceException(ErrorCodeItem errorCodeItem) : base(errorCodeItem) {

        }
        public ServiceException(string msg) : base(Error.MJErrorCode.Exception.ErrorCode, msg) {

        }

        protected ServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}