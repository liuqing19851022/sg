using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

using Photonicat.VO.Cat;
using Photonicat.VO.Cat.Respond;

namespace Photonicat.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class apiController : ControllerBase
    {


        private readonly ILogger<apiController> _logger;
        private readonly IHttpClientFactory httpClientFactory;

        public apiController(ILogger<apiController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 获取Dashboard
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<Dashboard> GetDashBoard()
        {
            var result = await this.httpClientFactory.CreateClient().GetFromJsonAsync<Dashboard>("api/v1/dashboard.json");
            return result!;
        }

        /// <summary>
        /// 获取短信
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<TxtMessages> GetTxtMessage()
        {
            var result = await this.httpClientFactory.CreateClient().GetFromJsonAsync<TxtMessages>("api/v1/modem/basic.json");
            var msgs = new List<TxtMessageItem>();

            foreach (var item in result!.messages)
            {
                var last = msgs.LastOrDefault();
                if (last != null && item.from == last.from && item.send_at_i == last.send_at_i)
                {
                    last.id += $",{item.id}";
                    last.msg += item.msg;

                }
                else
                {
                    msgs.Add(item);
                }
            }

            result.messages = msgs;

            return result!;
        }


        /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task SendTxtMessage(RequestSendTxtMessage request)
        {
            var content = new StringContent(JsonSerializer.Serialize(request));
            await this.httpClientFactory.CreateClient().PostAsync("api/v1/modem/sms/send.json", content);

        }

        [HttpDelete]
        public async Task DeleteTxtMessage(List<string> IDs)
        {
            foreach (var id in IDs)
            {
                var content = new StringContent(JsonSerializer.Serialize(new RequestDelTxtMessage
                {
                    msg_id = id
                }));
                await this.httpClientFactory.CreateClient().PostAsync("api/v1/modem/sms/delete.json", content);
            }
        }

        public async Task<RespondNetWorkData> GetNewWorkData()
        {

        }
    }
}