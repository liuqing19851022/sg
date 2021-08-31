#region C#文件说明
// /**********************************************************************************	
// 	* 类   名 ：ServiceRequestFactory.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Utils
// 	* 文 件 名：ServiceRequestFactory.cs
// 	* 创建时间：2016-05-05 16:38
// 	* 作    者： MJKJ.用户名：>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion
namespace MJUSS.Infrastructure.Utils.Helper
{
    using System;
    using MJUSS.Infrastructure.Core.BaseClass;
    using Newtonsoft.Json.Linq;
    using Org.BouncyCastle.Ocsp;

    public class ServiceRequestFactory
    {
        /// <summary>
        /// 创建请求
        /// </summary>
        /// <typeparam name="T">请求数据</typeparam>
        /// <param name="tenantID">租户编号</param>
        /// <param name="appID">应用编号</param>
        /// <returns>请求包</returns>
        public static RequestData<T> Create<T>(long tenantID, int appID) where T : class, new()
        {
            return new RequestData<T>
            {
                TenantID = tenantID,
                AppID = appID,
                RequestTime = DateTime.Now,
                ProcessMessageType = typeof(T).FullName,
                Data = new T()
            };
        }

        /// <summary>
        /// 创建请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static RequestData<T> Create<T>(RequestDataBase request) where T : new()
        {
            return new RequestData<T>
            {
                TenantID = request.TenantID,
                AppID = request.AppID,
                RequestTime = DateTime.Now,
                SessionID = request.SessionID,
                ProcessMessageType = typeof(T).FullName,
                ProcessMessageID = request.ProcessMessageID,
                Data = new T(),
                TracingData = GetMetaData(request),
            };
        }

        private static SkywalkingTracingMetaData GetMetaData(RequestDataBase request)
        {
            var metaData = new SkywalkingTracingMetaData()
            {
                TracingID = Guid.NewGuid(),
                TraceSegmentId = Guid.NewGuid(),
            };
            if (request.TracingData != null)
            {
                metaData.ParentTracingID = request.TracingData.ParentTracingID;
                metaData.ParentTraceSegmentId = request.TracingData.ParentTraceSegmentId;
                metaData.ParentServiceName = request.TracingData.ParentServiceName;
                metaData.ParentServiceInstance = request.TracingData.ParentServiceInstance;
            }

            return metaData;
        }


        /// <summary>
        /// 创建请求（用于应用层）
        /// </summary>
        /// <typeparam name="T">请求数据</typeparam>
        /// <param name="tenantID">租户编号</param>
        /// <param name="appID">应用编号</param>
        /// <param name="sessionID">会话编号</param>
        /// <returns>请求包</returns>
        public static RequestData<T> Create<T>(long tenantID, int appID, string sessionID) where T : class, new()
        {
            return new RequestData<T>
            {
                TenantID = tenantID,
                AppID = appID,
                SessionID = sessionID,
                RequestTime = DateTime.Now,
                ProcessMessageType = typeof(T).FullName,
                Data = new T(),
            };
        }

        /// <summary>
        /// 创建请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static RequestData<T> CreateRequest<T>(RequestDataBase request) where T : class, new()
        {
            return new RequestData<T>
            {
                TenantID = request.TenantID,
                AppID = request.AppID,
                SessionID = request.SessionID,
                ProcessMessageID = request.ProcessMessageID,
                ProcessMessageType = typeof(T).FullName,
                RequestTime = DateTime.Now,
                Data = new T(),
                TracingData = GetMetaData(request),
            };
        }

        /// <summary>
        /// 创建Saga请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static RequestData<T> CreateSagaRequest<T>(RequestDataBase request) where T : class, new()
        {
            return new RequestData<T>
            {
                TenantID = request.TenantID,
                AppID = request.AppID,
                SessionID = request.SessionID,
                ProcessMessageID = request.ProcessMessageID,
                ProcessMessageType = typeof(T).FullName,
                RequestTime = DateTime.Now,
                Data = new T(),
                TracingData = GetMetaData(request),
            };
        }

        /// <summary>
        /// 创建请求
        /// </summary>
        /// <typeparam name="T">请求数据</typeparam>
        /// <param name="tenantID">租户编号</param>
        /// <param name="appID">应用编号</param>
        /// <param name="processMessageID">流程消息编号</param>
        /// <returns></returns>
        public static RequestData<T> Create<T>(long tenantID, int appID, long processMessageID) where T : class, new()
        {
            return new RequestData<T>
            {
                TenantID = tenantID,
                AppID = appID,
                ProcessMessageID = processMessageID,
                ProcessMessageType = typeof(T).FullName,
                RequestTime = DateTime.Now,
                Data = new T()
            };
        }
    }
}