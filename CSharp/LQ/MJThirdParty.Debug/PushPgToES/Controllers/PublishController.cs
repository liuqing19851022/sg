using Microsoft.AspNetCore.Mvc;

using PushPgToES.Interfaces;

namespace PushPgToES.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PublishController : ControllerBase
    {

        private readonly ILogger<PublishController> _logger;
        private readonly IPushDbToEs client;

        public PublishController(ILogger<PublishController> logger, IPushDbToEs client)
        {
            _logger = logger;
            this.client = client;
        }

        [HttpPost]
        public async Task PublishAll()
        {
            await this.client.PublishAllDataBase("mj_wechat");

        }


    }
}
