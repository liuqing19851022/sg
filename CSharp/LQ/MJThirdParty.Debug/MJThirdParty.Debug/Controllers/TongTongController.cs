//using Microsoft.AspNetCore.Mvc;

//using MJSaas.ThirdParty.SmartLock.TongTong;
//using MJSaas.ThirdParty.SmartLock.TongTong.Request;
//using MJSaas.ThirdParty.SmartLock.TongTong.Respond;

//namespace MJThirdParty.Debug.Controllers
//{
//    /// <summary>
//    /// ͨͨ��
//    /// </summary>
//    [ApiController]
//    [Route("[controller]/[action]")]
//    public class TongTongController : ControllerBase
//    {
//        private readonly ILogger<TongTongController> logger;
//        private readonly TongTongLock tongtongLock;

//        public TongTongController(ILogger<TongTongController> logger, TongTongLock tongtongLock)
//        {
//            this.logger = logger;
//            this.tongtongLock = tongtongLock;
//        }

//        /// <summary>
//        /// ��ȡtoken
//        /// </summary>
//        /// <param name="username"></param>
//        /// <param name="password"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public async Task<RespondGetToken> GetToken(string username = "15570070836", string password = "tl123456")
//        {
//            var token = await tongtongLock.GetToken(new RequestGetToken
//            {
//                username = username,
//                password = password
//            });

//            return token;
//        }

//        /// <summary>
//        /// ��ȡ�豸�б�
//        /// </summary>
//        /// <param name="token"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public async Task<RespondGetAllDevices> GetAllDevices(string token)
//        {
//            return await tongtongLock.GetAllDevices(new RequestGetAllDevices()
//            {
//                accessToken = token
//            });
//        }
//    }
//}