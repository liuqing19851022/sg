using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using MJ.Payment.Core.Extentions;
using MJ.Payment.Core.ViewModel;
using MJ.Payment.Core.ViewModel.Request;
using MJ.Payment.Core.ViewModel.Respond;

using Newtonsoft.Json.Linq;

namespace MJThirdParty.Debug.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentFactory paymentFactory;
        private readonly MerchantPaymentSetting merchantPaymentSetting;
        const string DefOrderID = "202411191405";
        public PaymentController(PaymentFactory paymentFactory,
                                 IOptions<MerchantPaymentSetting> cfg)
        {
            this.paymentFactory = paymentFactory;
            this.merchantPaymentSetting = cfg.Value;
        }

        /// <summary>
        /// 测试扫码收款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<PaymentRespond<RespondPayResultViewModel>> F2FPay(string authCode = "131343241241241242314")
        {

            return await this.paymentFactory.GetPayProvider(merchantPaymentSetting.ChannelId)
                .F2FPay(new RequestF2FPayViewModel
                {
                    AuthCode = authCode,
                    IsPreAuthPay = false,
                    BusinessTypeId = 1,
                    Ext = "110",
                    Money = 1,
                    OrdId = DefOrderID,

                    ProductName = "商品内容"
                }, this.merchantPaymentSetting);
        }

        /// <summary>
        /// 小程序 & 公众号支付
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="openCode"></param>
        /// <param name="orderId"></param>
        /// <param name="isH5"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> H5Pay(
            string orderId = DefOrderID,
            bool isH5 = false)
        {
            var result = await this.paymentFactory.GetPayProvider(merchantPaymentSetting.ChannelId)
                .Pay(new RequestH5PayViewModel
                {
                    AppId = "",
                    IsPreAuthPay = false,
                    BusinessTypeId = 1,
                    Code = "",
                    Ext = "1",
                    IsH5 = isH5,
                    IsWeChatBrowser = true,
                    Money = 1,
                    OrdId = orderId,
                    ProductName = "测试",
                    ReturnUrl = "",
                }, this.merchantPaymentSetting);

            if (result.ErrorCode > 0)
                return result.ErrorMessage;

            return $"wx.requestPayment({JObject.FromObject(result.Data)})";

        }
        [HttpPost]
        public async Task<RespondPayResultViewModel> QueryOrder(string orderId = DefOrderID)
        {
            return await this.paymentFactory.GetPayProvider(merchantPaymentSetting.ChannelId)
                .QueryOrder(new RequestQueryOrderViewModel
                {
                    OrderId = orderId
                }, this.merchantPaymentSetting);
        }

        [HttpDelete]
        public async Task<bool> Refund(string orderId = DefOrderID)
        {

            return await this.paymentFactory.GetPayProvider(merchantPaymentSetting.ChannelId)
                .Refund(new RequestRefundViewModel
                {
                    RefundAmt = 1,
                    TotalAmt = 1,
                    OrdId = orderId,
                    RefundOrderId = DateTime.Now.Ticks.ToString()
                }, this.merchantPaymentSetting);
        }

    }

}
