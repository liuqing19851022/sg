using MJUSS.Infrastructure.Core.Error;
using Orleans.Concurrency;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJUSS.Infrastructure.Core.Exceptions
{
    [Serializable]
    [Immutable]
    public class ElasticSearchServerException : BaseException
    {
        public ElasticSearchServerException(int errorCode, string errorMessage) : base(errorCode,errorMessage) {

        }
        public ElasticSearchServerException()
        {

        }

        protected ElasticSearchServerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
