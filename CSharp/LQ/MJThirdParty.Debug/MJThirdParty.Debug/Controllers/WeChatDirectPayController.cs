//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;

//using MJ.Payment.Core.ViewModel;

//using SKIT.FlurlHttpClient.Wechat.TenpayV3;
//using SKIT.FlurlHttpClient.Wechat.TenpayV3.Models;

//namespace MJThirdParty.Debug.Controllers
//{

//    [ApiController]
//    [Route("[controller]/[action]")]
//    public class WeChatDirectPayController
//    {
//        private readonly MerchantPaymentSetting paymentSetting;
//        private readonly IHttpClientFactory _httpClientFactory;
//        public WeChatDirectPayController(IOptions<MerchantPaymentSetting> merchantPaymentSetting, IHttpClientFactory httpClientFactory)
//        {
//            this.paymentSetting = merchantPaymentSetting.Value;
//            this._httpClientFactory = httpClientFactory;
//        }

//        [HttpPost]
//        public async Task<CreateRefundDomesticRefundResponse> Refund(string ordId)
//        {


//            var options = new WechatTenpayClientOptions()
//            {
//                MerchantId = paymentSetting.MerchantNo,
//                MerchantV3Secret = paymentSetting.PublicKey,
//                MerchantCertificateSerialNumber = paymentSetting.CertificateSerialNumber,
//                MerchantCertificatePrivateKey = paymentSetting.PrivateKey,
//                //PlatformCertificateManager = manager, // 平台证书管理器的具体用法请参阅下文的基础用法与加密、验签有关的章节
//                AutoEncryptRequestSensitiveProperty = false,
//                AutoDecryptResponseSensitiveProperty = false,
//            };
//            var client = new WechatTenpayClient(options);
//            client.Configure((settings) => settings.FlurlHttpClientFactory = new DelegatingFlurlClientFactory(_httpClientFactory));


//            var requestRefund = new CreateRefundDomesticRefundRequest
//            {
//                OutTradeNumber = ordId,
//                OutRefundNumber = Guid.NewGuid().ToString("N"),
//                Amount = new CreateRefundDomesticRefundRequest.Types.Amount
//                {
//                    Total = 1,
//                    Refund = 1,
//                },
//                Reason = "系统退款",
//            };
//            var result = await client.ExecuteCreateRefundDomesticRefundAsync(requestRefund);
//            return result;

//        }
//    }

//    internal class DelegatingFlurlClientFactory : Flurl.Http.Configuration.DefaultHttpClientFactory
//    {
//        private readonly IHttpClientFactory _httpClientFactory;

//        public DelegatingFlurlClientFactory(IHttpClientFactory httpClientFactory)
//        {
//            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
//        }

//        public override HttpClient CreateHttpClient(HttpMessageHandler handler)
//        {
//            return _httpClientFactory.CreateClient();
//        }
//    }
//}
