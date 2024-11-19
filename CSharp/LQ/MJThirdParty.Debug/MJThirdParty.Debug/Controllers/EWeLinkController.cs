//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;

//using MJ.SmartPlug.EWeLink;
//using MJ.SmartPlug.EWeLink.Options;
//using MJ.SmartPlug.EWeLink.Respond;

//namespace MJThirdParty.Debug.Controllers
//{
//    [ApiController]
//    [Route("[controller]/[action]")]
//    public class EWeLinkController
//    {
//        private readonly EWeLinkSmartPlugHttpClient client;
//        private readonly EWeLinkDeviceTypeMapConfig DeviceMap;
//        private readonly ILogger<EWeLinkController> logger;
//        public EWeLinkController(EWeLinkSmartPlugHttpClient client, IOptions<EWeLinkDeviceTypeMapConfig> deviceMapOption, ILogger<EWeLinkController> logger)
//        {
//            this.client = client;
//            this.DeviceMap = deviceMapOption.Value;
//            this.logger = logger;
//        }


//        [HttpPost]

//        public async Task<RespondEWeLinkData<RespondEWeLinkGetDevices>> GetAllDevices(string account, string password, string token = "5a3681e4cb223e8c1d2abca9a31402132b31f316")
//        {

//            if (string.IsNullOrEmpty(token))
//            {

//                var login = await this.client.Login(account, password);

//                if (login.error != 0)
//                {

//                    return new RespondEWeLinkData<RespondEWeLinkGetDevices> { error = login.error, msg = login.msg, data = null };
//                }
//                token = login.data.AccessToken;
//            }


//            var devices = await this.client.GetDevices(token);


//            foreach (var item in devices.data.thingList)
//            {

//                var model = this.DeviceMap[item.itemData.extra.uiid];
//                if (model == EWeLinkModelEnums.未知)
//                {

//                    if (item.itemData.extra.ui.Contains("开关") || item.itemData.extra.ui.Contains("通道"))
//                    {
//                        this.logger.LogWarning($"{item.itemData.extra.ui} {item.itemData.extra.uiid} 未知类型");
//                    }
//                }
//            }

//            return devices;


//        }

//    }
//}
