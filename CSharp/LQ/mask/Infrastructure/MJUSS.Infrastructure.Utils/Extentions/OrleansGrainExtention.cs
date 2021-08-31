using Microsoft.Extensions.Logging;
using MJUSS.Infrastructure.Core.Error;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orleans
{
    public static class OrleansGrainExtention
    {
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="grain"></param>
        /// <param name="loggerFactory"></param>
        /// <returns></returns>
        public static Task WriteErrorLog(this Grain grain, ILoggerFactory loggerFactory,Exception ex)
        {
            loggerFactory.CreateLogger(grain.GetType().FullName).Error(MJErrorCode.Exception.ErrorCode, ex.ToString(), ex);
            return Task.CompletedTask;
        }
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="grain"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Task WriteErrorLog(this Grain grain, ILoggerFactory loggerFactory,string ErrorMessage, Exception ex = null)
        {
            loggerFactory.CreateLogger(grain.GetType().FullName).Error(MJErrorCode.Exception.ErrorCode, ErrorMessage, ex);
            return Task.CompletedTask;
        }



    }
}
