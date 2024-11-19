
//using EWeLinkGrpc;

//using Microsoft.AspNetCore.Mvc;

//using MJ.SmartPlug.EWeLink.Grpc;

//namespace MJThirdParty.Debug.Controllers
//{
//    [ApiController]
//    [Route("[controller]/[action]")]
//    public class EWeLinkGrpcController : ControllerBase
//    {
//        private readonly EWeLinkGrpcClient grpcClient;
//        const string account = "18349151043";
//        const string accessToken = "4a6f57de7b4df96fe3500a03acf09b5230addb52";
//        const string apiKey = "baba6744-6619-41df-bec0-5914648ff55d";


//        //private readonly SetTokenRequest token = new SetTokenRequest
//        //{
//        //    AccessToken = accessToken,
//        //    ApiKey = apiKey,
//        //    Account = account,
//        //    ExpireAt = DateTime.Now.AddDays(1).Ticks,
//        //    RefrehToken = "abe448cca31d03a6fa1f5e808a88a849eba429c3",
//        //};

//        public EWeLinkGrpcController(EWeLinkGrpcClient grpcClient)
//        {
//            this.grpcClient = grpcClient;
//        }

//        //[HttpPost]
//        //public async Task Login(string pwd = "yezidzn1314520")
//        //{
//        //    await this.grpcClient.LoginAsync(new LoginRequest
//        //    {
//        //        Account = account,
//        //        PassWord = pwd,
//        //    });
//        //}


//        /// <summary>
//        /// 开关设备
//        /// </summary>
//        /// <param name="deviceid"></param>
//        /// <param name="model"></param>
//        /// <param name="on"></param>
//        /// <param name="ports"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public async Task Switch(string deviceid = "a400013d13", int model = 3, bool on = true, int ports = 15)
//        {

//            var request = new SwitchPlugRequest
//            {
//                Account = account,
//                On = on,

//            };

//            var item = new SwitchPlugItemRequest
//            {
//                Model = model,
//                Sn = deviceid,
//            };
//            for (var i = 0; i < 4; i++)
//            {
//                var val = 1 << i;
//                if ((ports & val) == val)
//                    item.Ports.Add(i);
//            }
//            request.Items.Add(item);

//            await this.grpcClient.SwitchPlugAsync(request);
//        }

//        [HttpGet]
//        public async Task<GetPlugListReply> GetPlugList()
//        {
//            return await this.grpcClient.GetPlugListAsync(new GetPlugListRequest { Account = account, AccessToken = accessToken });
//        }

//        //[HttpPost]
//        //public async Task<SmsPreLoginReply> SmsPreLogin()
//        //{
//        //    return await this.grpcClient.SmsPreLoginAsync(new SmsPreLoginRequest
//        //    {
//        //        Account = account,
//        //    });
//        //}




//        //[HttpPost]
//        //public async Task<LoginReply> SmsLogin(string code)
//        //{

//        //    return await this.grpcClient.SmsLoginAsync(new LoginRequest
//        //    {
//        //        Account = account,
//        //        PassWord = code
//        //    });
//        //}

//        [HttpPost]
//        public async Task<HeartBeatReply> HeartBeart()
//        {
//            return await this.grpcClient.HeartBeatAsync(new HeartBeatRequest
//            {
//                AccessToken = account,
//                Account = account,
//                ApiKey = apiKey,
//                AccessTokenExpire = DateTime.Now.AddDays(1).Ticks,
//                RefrehToken = "",
//            });
//        }
//    }
//}
