//#region C#文件说明

//// /**********************************************************************************	
//// 	* 类   名 ：BaseHttpAsyncHandler.cs
//// 	* 功能描述：<简单描述类的作用>
//// 	* 机器名称：MJ-LIUJIANHUA
//// 	* 命名空间：MJUSS.Infrastructure.Core
//// 	* 文 件 名：BaseHttpAsyncHandler.cs
//// 	* 创建时间：2016-05-21 17:29
//// 	* 作    者： MJKJ.hermes liu>
//// 
//// 	* 修 改 人：<修改人名称>
//// 	* 修改描述：<修改内容>
//// 	* 修改时间：YYYY-MM-DD 00:00:00
//// **********************************************************************************/

//#endregion

//namespace MJUSS.Infrastructure.Utils.Common
//{
//    using System;
//    using System.Text;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using System.Web;

//    using MJUSS.Infrastructure.Core.BaseClass;
//    using MJUSS.Infrastructure.Core.Error;
//    using MJUSS.Infrastructure.Core.Exceptions;
//    using MJUSS.Infrastructure.Utils.Extentions;
//    using MJUSS.Infrastructure.Utils.Helper;

//    using Newtonsoft.Json;
//    using Newtonsoft.Json.Linq;

//    public class BaseHttpAsyncHandler : IHttpAsyncHandler
//    {
//        public void ProcessRequest(HttpContext context)
//        {
//            throw new NotImplementedException();
//        }

//        public bool IsReusable => true;

//        public virtual IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
//        {
//            throw new NotImplementedException();
//        }

//        public void EndProcessRequest(IAsyncResult result)
//        {
//        }
//    }

//    public class HttpAsyncHandlerOperation : IAsyncResult
//    {
//        private readonly AsyncCallback _callback;

//        private readonly HttpContext _context;

//        private readonly JObject requestData;

//        private readonly object _state;

//        private bool _completed;

//        public HttpAsyncHandlerOperation(AsyncCallback callback, JObject requestData,HttpContext context, object state)
//        {
//            this._callback = callback;
//            this._context = context;
//            this._state = state;
//            this._completed = false;
//            this.requestData = requestData;
//        }

//        bool IAsyncResult.IsCompleted => this._completed;

//        WaitHandle IAsyncResult.AsyncWaitHandle => null;

//        object IAsyncResult.AsyncState => this._state;

//        bool IAsyncResult.CompletedSynchronously => false;

//        public async Task StartAsyncTask(Func<JObject, Task<JObject>> func)
//        {
//            this._context.Response.ContentType = "application/json";
//            this._context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
//            var commandName = string.Empty;
//            try
//            {
//                commandName = this.requestData["CommandName"].Value<string>();
//                if (string.IsNullOrEmpty(commandName))
//                {
//                    throw new ServiceException(MJErrorCode.UnrecognizedCommandException);
//                }
//                var respondJObject = await func(this.requestData);
//                this._context.Response.ContentType = "application/json";
//                this._context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
//                var result = GzipTools.GetCompressData(Encoding.UTF8.GetBytes(respondJObject.ToString(Formatting.None)));
//                this._context.Response.BinaryWrite(result);
//            }
//            catch (ServiceException)
//            {
//                throw;
//            }
//            catch (Exception ex)
//            {
//                var errorRespond = new RespondDataBase(MJErrorCode.Exception.ErrorCode, ex.Message)
//                                       {
//                                           CommandName =
//                                               commandName
//                                       };
//                this._context.Response.Write(JObject.FromObject(errorRespond).ToString(Formatting.None));
//            }
//            this._completed = true;
//            this._callback(this);
//        }
//    }
//}