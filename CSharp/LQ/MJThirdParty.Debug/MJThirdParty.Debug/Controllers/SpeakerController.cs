//using Microsoft.AspNetCore.Mvc;

//using MJSaas.ThirdParty.SmartSpeaker.XinBoRui;
//using MJSaas.ThirdParty.SmartSpeaker.XinBoRui.Respond;
//namespace MJThirdParty.Debug.Controllers
//{
//    /// <summary>
//    /// ¿Æ∞»
//    /// </summary>
//    [ApiController]
//    [Route("[controller]/[action]")]
//    public class SpeackerController : ControllerBase
//    {
//        private readonly ILogger<TongTongController> logger;
//        private readonly XinBoRuiSpeaker speaker;

//        public SpeackerController(ILogger<TongTongController> logger, XinBoRuiSpeaker speaker)
//        {
//            this.logger = logger;
//            this.speaker = speaker;
//        }

//        /// <summary>
//        /// ªÒ»°token
//        /// </summary>
//        /// <param name="username"></param>
//        /// <param name="password"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public async Task<RespondXinBoRuiGetTokenDTO> GetToken()
//        {
//            var token = await speaker.GetToken("", "");

//            return token;
//        }


//    }
//}