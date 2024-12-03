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
        const string DefOrderID = "202411261502";
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
            string appId = "wx31591ceff441a423",
            string openId = "ofzt369o9SOAVHp4tH6qf4XMq-ec",
            bool isH5 = false)
        {
            var result = await this.paymentFactory.GetPayProvider(merchantPaymentSetting.ChannelId)
                .Pay(new RequestH5PayViewModel
                {
                    AppId = appId,
                    IsPreAuthPay = false,
                    BusinessTypeId = 1,
                    Code = openId,
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

        [HttpPut]

        public async Task<RespondPayResultViewModel> SignCheck() {

            var msg = "{\"BANK_CODE\":\"1\",\"CARD_TYPE\":\"01\",\"CUST_FEE\":\"0\",\"CUST_ID\":\"809391013041939\",\"MERCID\":\"60000001836919\",\"NETR_AMT\":\"1\",\"OPEN_ID\":\"oBY7i5VbvJA4NQnyCV8TcvV7b-Jg\",\"ORDER_NO\":\"20241120809391013041939147691608\",\"ORDER_STATUS\":\"1\",\"ORDER_TIME\":\"20241120110024\",\"PAY_CHANNEL\":\"2\",\"PAY_WAY\":\"8\",\"THREE_ORDER_NO\":\"MJY-202411201056\",\"TRADING_IP\":\"127.0.0.1\",\"TXAMT\":\"1\",\"T_ORDER_NO\":\"A0241120110015196768\",\"T_PAY_NO\":\"4200002498202411201337714901\",\"USTLDAT\":\"20241120\",\"sign\":\"fxuBOASZcXX/Vr2C0KgdfnNmTLiC30sd0uCdB6M1AMMNy5ksF7JkZNKtKeEsgSrVW15+n7uZHz6gkcwv9vT97a2Sk7gEspWeDLa+9mi4Pdc/VUlDu2+2NyPs1Ygvwm3g90keIQra7t8GTBWJFahjCu5UJoRsrRkg1se4gWylf0abdCnyU6lpljEAjLQsFa7chnIBmgfn6iwHKdsGRdFztxGOMLVehrqBJ1eDqu/LIiqIkqCUmPY7zBUhVQ3o3OahgUjNSsKS4FyemrSXpTA//bczBM5SrsDMYCwRa0Hn15jXNlAKFc4f/7cp9zYQ+QUTvxTfYrY63dFspnOEKxEPulUA2RM5mzqyc6L2ZJu3D5hd1T+yQlZai5em6tV98dlcM+RID3bxiqqSkP/08gcx4YqRyv1BkW+qRhp/riQpUGcPH8vnJz474DrsFhcXphYOOBr5y716eh8W09alk0HE1nPjIrKT3PaONiw0MeHrUwFMPkKHqzg6UFfEsQt987+0EQ2uezYmsoWj5CNzyelNBF6yqxnGtRArJJfQicqqlv1K1cDW0oezuS7DrIADuHIq+MlXte40S0dZkZTUeH2zzHcUNaUFrwM+z/rL9OuGYwHtSpr+pCLSzJ/gQ2eRzXo1OnSKNMRp+GeQh0DiRZRIBuMJA+m4Kg/IlJ3tp/e6wA11fNvEdL153PcnyLDBwN3NB/O9ri6Ef+WDok9KIrGTmDF1YOxGgd1hVzMOXFSoLj1uVHWWKrHhs9sQpMDlNVOOOVb7VRGCfD694JYmAmwJTJAN9/dunYoXPxY9vqnuI5ka1AIEI0Fr7anP1atbEdI70I2b1qP0uo66+LPGTRgbgrTv+4tDSuYU9XydTJ7K/Rlx9nOSfMiN8VdZ0mpGBMdwQYwLQ/2n6x8UIKVTvWwVsrAgMF1CqTVs+nPhGgX0XNCDOva6gssds12rWl4yxtlFfCLltdG21WQZZCcNMJ3T9II5WSZUjPR56ixXJfQQjdAMbdv1pTogym7yIX/xbGUrEgejv4Q2GbD2MUyRa7714A8Q5TYo60eVav2Y00i8lNv1quI4UZNy5JWw+AYN5xxcoSuoWAEt44y1rwP1HbrsBXMQ8aAC5uHPvkbZ9yN5nCG2WCvccRPwAt9YA669XthISKJGyAFdvR66g8zHa2CrDQuhMo4yAqdFHSsiUbG8A+AYzP5QJ5DpVB2zcZl/LeKCxODlMD0HjOVwIogxjAg2XZftXnMqJcDjPfPKZY3xGSmZ08OzhRiRQNrNG816uJ+O6Tf7vxmDGcCWg870bAtFE1cSqFZJE3qIOY3JrWCLDn3kIFPMMFCFIZK9k+OR86PGNaC8Ib5ahFB8feWAVh112w==\"}";

            return await this.paymentFactory.GetPayProvider(merchantPaymentSetting.ChannelId).ProcessNotice(null, null, msg, null);
        }
    }

}
