using MJUSS.Infrastructure.Core.Error;
using MJUSS.Infrastructure.Core.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Orleans;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Orlelans
{
    public class LoggingCallFilter : IIncomingGrainCallFilter
    {
        private readonly Microsoft.Extensions.Logging.ILoggerFactory loggerFactory;
        private readonly string errorCatgoryName = "MjSaasException";
        public LoggingCallFilter(Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public async Task Invoke(IIncomingGrainCallContext context)
        {
            try
            {
                await context.Invoke();
            }
            catch (ElasticSearchServerException esex)
            {
                var jsonRequestArray = new JArray();
                var logContent = new StringBuilder();
                if (context.Arguments != null)
                {
                    foreach (var item in context.Arguments)
                    {
                        jsonRequestArray.Add(JsonConvert.SerializeObject(item));
                    }
                }
                logContent.AppendLine("---------------------------------------------------------");
                logContent.AppendLine("请求参数：");
                logContent.AppendLine(jsonRequestArray.ToString());
                logContent.AppendLine("异常：");
                logContent.AppendLine(esex.GetBaseException().ToString());
                logContent.AppendLine("Ealsticsearch异常：");
                logContent.AppendLine(esex.Message);
                logContent.AppendLine("---------------------------------------------------------");
                loggerFactory.CreateLogger(errorCatgoryName).Error(MJErrorCode.Exception.ErrorCode, logContent.ToString(), esex);
                throw new ServiceException("读取数据库服务器异常！", MJErrorCode.Exception.ErrorCode); 
            }            
            //catch (ValidationException)
            //{
            //    throw;
            //}
            //catch (BaseValidationException)
            //{
            //    throw;
            //}
            //catch (ServiceException)
            //{
            //    throw;
            //}
            catch (Exception ex)
            {
                var jsonRequestArray = new JArray();
                var logContent = new StringBuilder();
                if (context.Arguments != null)
                {
                    foreach (var item in context.Arguments)
                    {
                        jsonRequestArray.Add(JsonConvert.SerializeObject(item));
                    }
                }
                logContent.AppendLine("---------------------------------------------------------");
                logContent.AppendLine("请求参数：");
                logContent.AppendLine(jsonRequestArray.ToString());
                logContent.AppendLine("异常：");
                logContent.AppendLine(ex.GetBaseException().ToString());
                logContent.AppendLine("---------------------------------------------------------");
                loggerFactory.CreateLogger(errorCatgoryName).Error(MJErrorCode.Exception.ErrorCode, logContent.ToString(), ex);
                throw;
            }
        }
    }
}
