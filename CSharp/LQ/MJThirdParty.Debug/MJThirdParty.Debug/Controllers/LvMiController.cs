//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;

//using MJ.SmartPlug.LvMiV3;
//using MJ.SmartPlug.LvMiV3.Options;
//using MJ.SmartPlug.LvMiV3.Respond;

//namespace MJThirdParty.Debug.Controllers
//{
//    [ApiController]
//    [Route("[controller]/[action]")]
//    public class LvMiController : ControllerBase
//    {
//        private readonly LvMiSmartPlug lvMiPlugclient;
//        private readonly IOptions<LvMiDeceiveTypeMapConfig> lvmiConfig;
//        public LvMiController(LvMiSmartPlug lvMiPlugclient, IOptions<LvMiDeceiveTypeMapConfig> lvmiConfig)
//        {
//            this.lvMiPlugclient = lvMiPlugclient;
//            this.lvmiConfig = lvmiConfig;
//        }


//        [HttpGet]
//        public async Task<RespondGetAuthCodeDTO> GetAuthCode(string account = "18349151043")
//        {
//            return await this.lvMiPlugclient.GetAuthCode(account);
//        }

//        [HttpGet]
//        public async Task<RespondAccessTokenDTO> GetToken(string account = "18349151043", string authCode = "155225")
//        {
//            return await this.lvMiPlugclient.GetToken(account, authCode);
//        }


//        [HttpGet]
//        public async Task<RespondGetAllLvMiDeveivesDTO> GetAllDevice(string token = "9e923b4f5ec8c058c2a8146b9415a1d5")
//        {
//            return await this.lvMiPlugclient.GetDevices(token, 1, 50);
//        }

//        [HttpGet]
//        public async Task<List<LvMiDeceiveItemDTO>> GetUnKnowDevices(string token = "9e923b4f5ec8c058c2a8146b9415a1d5")
//        {
//            var devices = await this.lvMiPlugclient.GetDevices(token, 1, 50);


//            var datas = devices.result.data
//                .Where(p =>
//                    !p.model.Contains("gateway") //网关
//                    && !p.model.Contains("sensor") //传感器
//                    && !p.model.Contains("weather") //传感器
//                    && !p.model.Contains("remote")  // 无线开关
//                    && !p.model.Contains("magnet")  // 门窗传感器
//                    && !p.model.Contains("curtain") // 窗帘电机
//                    && !p.model.Contains("aircondition") //空调
//                    );


//            var deviceTypes = datas.Select(p => p.model).Distinct().ToList();


//            var cfg = this.lvmiConfig.Value;

//            var result = new List<LvMiDeceiveItemDTO>();

//            foreach (var item in deviceTypes)
//            {
//                if (cfg[item] == LuMiModelEnums.未知)
//                {
//                    var data = devices.result.data.FirstOrDefault(p => p.model == item);
//                    if (data != null)
//                        result.Add(data);
//                }
//            }

//            return result;

//        }

//    }
//}
