using MJUSS.Infrastructure.Core.Error;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJUSS.Infrastructure.Core.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        /// <summary>
        ///     错误码
        /// </summary>
        public int ErrorCode
        {
            get
            {
                if (!this.Data.Contains("ErrorCode"))
                {
                    return 0;
                }
                return (int)this.Data["ErrorCode"];
            }
            set
            {
                this.Data["ErrorCode"] = value;
            }
        }

        public BaseException()
        {
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="errorCode"></param>
        public BaseException(int errorCode)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        public BaseException(int errorCode, string errorMessage)
            : base(errorMessage)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="errorCodeItem"></param>
        public BaseException(ErrorCodeItem errorCodeItem)
            : base(errorCodeItem.ErrorMessage)
        {
            this.ErrorCode = errorCodeItem.ErrorCode;
        }

    }


}
