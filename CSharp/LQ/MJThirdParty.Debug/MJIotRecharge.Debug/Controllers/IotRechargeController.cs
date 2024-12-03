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
        public IotRechargeController(IIotOmpClient client)
        {
            this.client = client;

        }

        //[HttpGet]
        //public async Task GetBillingGroupListAsync()
        //{

        //    await this.client.GetBillingGroupListAsync();

        //}

        //[HttpGet]
        //public async Task GetCardListAsync()
        //{
        //    await this.client.GetCardListAsync();
        //}

        /// <summary>
        /// 2.2.1. 开始生成卡列表文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<int> GetDownLoadCardListTask() { 
            return await this.client.GetDownLoadCardListTask();
        }

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
        public Task<ResponseGetCardSetmealProductVO> GetCardSetmealProductAsync(RequestGetCardSetmealProductVO request)
        {
            return this.client.GetCardSetmealProductAsync(request);
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
