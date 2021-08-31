namespace MJUSS.Infrastructure.Core.Exceptions
{
    using MJUSS.Infrastructure.Core.Error;
    using Orleans.Concurrency;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [Immutable]
    public class BaseValidationException : BaseException
    {
        public BaseValidationException() {
        }
        public BaseValidationException(int errorCode, string errorMessage)
            : base(errorCode, errorMessage)
        {

        }
        public BaseValidationException(ErrorCodeItem errorCodeItem)
            : base(errorCodeItem)
        {

        }

        protected BaseValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }

        
}