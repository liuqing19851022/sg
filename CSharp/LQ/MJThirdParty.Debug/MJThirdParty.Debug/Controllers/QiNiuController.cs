//using Microsoft.AspNetCore.Mvc;

//using Newtonsoft.Json.Linq;

//using Qiniu.CDN;
//using Qiniu.Http;
//using Qiniu.Storage;
//using Qiniu.Util;

//namespace MJThirdParty.Debug.Controllers
//{

//    [ApiController]
//    [Route("[controller]/[action]")]
//    public class QiNiuController : ControllerBase
//    {
//        const string QiniuAK = "zLqj4BIjjAZfAmtqXjbP6YeXaxdqYcL2uIa2B0k7";
//        const string QiniuSK = "fetAiyPHd6ZTB7hU8s2dxhkj7wYIpBUD_Cc5dBQu";
//        const string QiniuBucket = "mjuss";
//        const string Root = @"D:\";
//        const string Theme = @"wxminappimg\theme";
//        const string Domain = "https://img.yjyxt.com";

//        private readonly ILogger<QiNiuController> logger;

//        public QiNiuController(ILogger<QiNiuController> logger)
//        {
//            this.logger = logger;
//        }

//        async Task UploadByQiniu(string filePath, int retryCount = 3, int deleteAfterDays = 0)
//        {

//            var imageName = filePath.Substring(Root.Length).Replace("\\", "/");
//            var imageData = await System.IO.File.ReadAllBytesAsync(filePath);

//            this.logger.LogWarning(imageName);

//            var mac = new Mac(QiniuAK, QiniuSK); // Use AK & SK here
//            var putPolicy = new PutPolicy();

//            putPolicy.Scope = QiniuBucket;// 设置要上传的目标空间
//            // 上传策略的过期时间(单位:秒)
//            putPolicy.SetExpires(3600);
//            // 文件上传完毕后，在多少天后自动被删除
//            if (deleteAfterDays > 0)
//            {
//                putPolicy.DeleteAfterDays = deleteAfterDays;
//            }

//            string jstr = putPolicy.ToJsonString();
//            string token = Auth.CreateUploadToken(mac, jstr);

//            FormUploader fm = new(new Config()
//            {
//                ChunkSize = ChunkUnit.U512K,
//                MaxRetryTimes = retryCount,
//                UseCdnDomains = false,
//                UseHttps = false,
//                Zone = Zone.ZoneCnEast
//            });
//            var putExtra = new PutExtra()
//            {
//                ProgressHandler = (u, p) =>
//                {
//                    Console.Title = $"uploading {imageName} {(u / p) * 100} %";
//                },
//            };
//            var result = await fm.UploadData(imageData, imageName, token, putExtra);
//            if (result.Code != (int)HttpCode.OK)
//            {

//                if (result.Code == 614 && retryCount > 1)
//                {
//                    BucketManager bucketManager = new(mac, new Config()
//                    {
//                        ChunkSize = ChunkUnit.U512K,
//                        MaxRetryTimes = retryCount,
//                        UseCdnDomains = false,
//                        UseHttps = false,
//                        Zone = Zone.ZoneCnEast
//                    });
//                    var result2 = await bucketManager.Delete(QiniuBucket, imageName);

//                    await UploadByQiniu(filePath, 1);

//                    var cdn = new CdnManager(mac);
//                    await cdn.RefreshUrls(
//                    [
//                        $"{Domain}/{imageName}"
//                    ]);
//                }
//                else
//                {
//                    throw new Exception($"{result}");
//                }
//            }
//        }

//        [HttpPost]
//        public async Task UploadTheme(string theme = "Default")
//        {
//            var dir = Path.Combine(Root, Theme, theme);
//            foreach (var item in Directory.GetFiles(dir, "*", SearchOption.AllDirectories))
//            {
//                var fi = new System.IO.FileInfo(item);
//                switch (fi.Extension)
//                {
//                    case ".png":
//                    case ".svg":
//                    case ".jpg":
//                    case ".jpeg":
//                        await UploadByQiniu(item);
//                        break;
//                    default:
//                        this.logger.LogWarning($"skip {item}");
//                        break;
//                }
//            }

//        }

//        [HttpGet]
//        public async Task GetServerTime(CancellationToken cancellationToken)
//        {

//            var msg = "{\"action\":\"update\",\"deviceid\":\"a400013e92\",\"apikey\":\"df48d9c2-e359-43dd-bae9-921918dbb633\",\"userAgent\":\"device\",\"d_seq\":44150,\"params\":{\"switches\":\"on\"}}";

//            var jObj = JObject.Parse(msg);
//            if (jObj.ContainsKey("action"))
//            {
//                var action = jObj["action"];
//                if ("update".Equals(action!.ToString()))
//                {
//                    var apikey = jObj["apikey"]?.ToString();


//                    var deviceid = jObj["deviceid"]?.ToString();
//                    if (string.IsNullOrEmpty(deviceid))
//                        return;


//                    var args = jObj["params"];
//                    if (args == null)
//                        return;
//                    var data = args as JObject;
//                    if (data != null)
//                    {

//                        if ("on".Equals(data["switch"]?.Value<string>()))
//                        {
//                            Console.WriteLine("on");
//                        }
//                    }


//                }



//            }

//        }
//    }
//}
