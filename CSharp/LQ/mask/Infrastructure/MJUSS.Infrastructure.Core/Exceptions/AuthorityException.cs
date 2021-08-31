namespace MJUSS.Infrastructure.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NoAuthorityException : BaseException
    {
        public NoAuthorityException()
            : base(Error.MJErrorCode.NoActionPermission.ErrorCode, "你没有权限进行此操作！")
        {
        }

        public NoAuthorityException(string message)
            : base(Error.MJErrorCode.ValidationError.ErrorCode, message)
        {
        }

        protected NoAuthorityException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}