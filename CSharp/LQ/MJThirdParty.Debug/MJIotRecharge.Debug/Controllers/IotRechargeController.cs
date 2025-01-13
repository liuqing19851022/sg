using Microsoft.AspNetCore.Mvc;

using MJ.ThirdParty.NBIotCard.Recharge.Client;
using MJ.ThirdParty.NBIotCard.Recharge.Client.VO.Request;
using MJ.ThirdParty.NBIotCard.Recharge.Client.VO.Response;

namespace MJThirdParty.Debug.Controllers
{

    /// <summary>
    /// IOT充值
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class IotRechargeController
    {
        private readonly IIotOmpClient client;
        const string DefaultIcciD = "89860842102480059934";
        public IotRechargeController(IIotOmpClient client)
        {
            this.client = client;

        }

        //[HttpGet]
        //public async Task GetBillingGroupListAsync()
        //{

        //    await this.client.GetBillingGroupListAsync();

        //}

        /// <summary>
        /// 2.1.4. 资产列表 最近N天激活的卡
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseQueryCardListVO> GetCardListAsync(int day = 5)
        {
            return await this.client.GetCardList(new RequestQueryCardListVO { 
                activeDateEnd = DateTime.Now,
                activeDateStart = DateTime.Now.AddDays(day * -1),
            });
        }

        /// <summary>
        ///  2.1.5. 资产详细信息
        /// </summary>
        /// <param name="iccid"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseGetCardInfoVO> GetCardInfo(string iccid = DefaultIcciD)
        {
            return await this.client.GetCardInfo(new RequestGetCardInfoVO
            {
                iccid = iccid
            });
        }

        /// <summary>
        ///  2.1.6. 资产详细信息(批量)
        /// </summary>
        /// <param name="iccid"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseBatchGetCardsInfoVO> GetCardsInfo(string iccid = DefaultIcciD, string iccid2 = "89860842102480059935")
        {
            return await this.client.GetCardsInfo(new RequestBatchGetCardsInfoVO
            {
                iccids = new List<string> { iccid, iccid2 }
            });
        }

        /// <summary>
        /// 2.2.1. 开始生成卡列表文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<int> GetDownLoadCardListTask() { 
            return await this.client.GetDownLoadCardListTask();
        }
        /// <summary>
        /// 2.2.3 卡列表文件下载
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task DownloadCardList(int taskId = 5162) {
            await this.client.DownloadCardList(taskId);
        }

        /// <summary>
        /// 2.5.1. 企业流量包产品列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseGetCompanyFlowPackageVO> GetCompanyFlowPackagesAsync()
        {
            return await this.client.GetCompanyFlowPackagesAsync();
        }

        /// <summary>
        ///  2.5.2. 资产续费套餐产品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<ResponseGetCardSetmealProductVO> GetCardSetmealProductAsync(string iccid = DefaultIcciD)
        {
            return this.client.GetCardSetmealProductAsync(new RequestGetCardSetmealProductVO { 
                iccid = DefaultIcciD,
            });
        }


        /// <summary>
        /// 2.5.3. 资产流量包充值
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<ResponseCardRechargeVO> RechargeCard(RequestCardRechargeVO request)
        {
            return this.client.RechargeCard(request);
        }

        /// <summary>
        /// 2.5.4. 资产套餐续费
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<ResponseCardRenewWalVO> CardRenewAsync(RequestCardRenewWalVO request)
        {
            return this.client.CardRenewAsync(request);
        }
        /// <summary>
        /// 2.5.5. 资产充值续费订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<ResponseQueryRechargeOrderDetailsVO> QueryRechargeOrderDetails(RequestQueryRechargeOrderDetailsVO request)
        {
            return this.client.QueryRechargeOrderDetails(request);
        }

        /// <summary>
        /// 2.5.7. 企业余额及明细查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ReponseGetWalletDetaVO> GetWalletDetaAsync()
        {
            return await this.client.GetWalletDetaAsync();
        }

    }
}
