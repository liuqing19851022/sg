using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using MJ.Payment.Core.Enums;
using MJ.Payment.Core.Extentions;
using MJ.Payment.Core.ViewModel;

using Newtonsoft.Json.Linq;

namespace MJThirdParty.Debug.Controllers
{

    [ApiController]
    public class PayResultNotifyController : ControllerBase
    {
        readonly ILogger<PayResultNotifyController> logger;
        private readonly PaymentFactory paymentFactory;
        private readonly MerchantPaymentSetting merchantPaymentSetting;

        public PayResultNotifyController(ILogger<PayResultNotifyController> logger, PaymentFactory paymentFactory, IOptions<MerchantPaymentSetting> cfg)
        {
            this.logger = logger;
            this.paymentFactory = paymentFactory;
            this.merchantPaymentSetting = cfg.Value;
        }



        /// <summary>
        /// 获取请求参数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<string> GetString(HttpRequest request)
        {
            SortedDictionary<string, string> GetSortedDictionaryFromForm(IFormCollection frm)
            {
                SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
                foreach (var item in frm)
                {
                    dic[item.Key] = item.Value;
                    this.logger.LogWarning($"{item.Key}={item.Value}");
                }

                return dic;
            }

            SortedDictionary<string, string> dicForm = null;
            switch (request.Method.ToUpper())
            {
                case "POST":

                    if (request.ContentType!.Contains("/json") || request.ContentType.Contains("/xml"))
                    {
                        using (var stream = new MemoryStream())
                        {
                            await request.Body.CopyToAsync(stream);
                            var strRequest = Encoding.UTF8.GetString(stream.ToArray());
                            return strRequest;
                        }
                    }
                    else
                    {
                        dicForm = GetSortedDictionaryFromForm(request.Form);
                    }
                    break;

                case "GET":
                    var query = request.QueryString.ToString();
                    if (string.IsNullOrEmpty(query))
                        return string.Empty;
                    dicForm = JObject.Parse(request.QueryString.ToString()).ToObject<SortedDictionary<string, string>>();
                    break;
            }
            if (dicForm != null)
            {
                return JObject.FromObject(dicForm).ToString();
            }
            return string.Empty;
        }
        //{PayChannel}/{BusinessTypeId}/{OrderId}/{Money}

        [Route("{payWay:int}/{BusinessTypeId:int}/{OrderId}/{Money:int}/")]
        [HttpPost]
        [HttpGet]
        public async Task<ActionResult> CallBack(int payWay, int BusinessTypeId, string OrderId, int Money)
        {
            if (payWay == 0)
            {
                return Content("payway is not validate");
            }

            if (OrderId.Length < 5 || OrderId.Length > 20)
            {
                return Content("OrderId is not validate");
            }

            if (Money == 0)
            {
                return Content("Money is not validate");
            }

            if (BusinessTypeId == 0)
            {
                return Content("BusinessTypeId is not validate");
            }
            var msg = string.Empty;
            var dicHead = new Dictionary<string, string>();
            try
            {
                msg = await GetString(this.Request);
                foreach (var item in Request.Headers)
                {
                    dicHead[item.Key] = item.Value;
                }
            }
            catch (Exception ex)
            {
                return Content("bye");
            }


            var imp = paymentFactory.GetPayProvider(payWay);

            var result = await imp.ProcessNotice(null, (_) =>
            {
                return Task.FromResult(this.merchantPaymentSetting);
            }, msg, dicHead);

            if (result != null && result.OrderState == (int)TradeStateEnum.TRADE_SUCCESS)
            {

                //返回成功通知消息
                return Content(imp.SuccessMessage);
            }
            return Content("Failed");
        }
    }
}

