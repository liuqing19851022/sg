using MJUSS.Infrastructure.Core.BaseClass;
using MJUSS.Infrastructure.Core.Constants;
using MJUSS.Infrastructure.Core.Error;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Helper
{

    public class PostToMJConfig {
        public string Url { get; set; }

        public string SessionKey { get; set; } = "MJSessionID";
    }

    public class HttpPostToMJHelper
    {
        PostToMJConfig postCfg;
        private HttpPostTools httpPostHelper;
        private HttpPostToMJHelper() {

            postCfg = ConfigHandler.GetConfig<PostToMJConfig>();

            httpPostHelper = new HttpPostTools(postCfg.Url);
        }

        public static Lazy<HttpPostToMJHelper> Instance => new Lazy<HttpPostToMJHelper>(() => { return new HttpPostToMJHelper(); });


        public async Task<RespondData<T>> PostToPC<T, R>(RequestData<R> request) {

            try
            {
                //byte[] requestDataBuffer = null;

                //var requestData = JObject.FromObject(request);
                //requestDataBuffer = Encoding.UTF8.GetBytes(requestData.ToString(Formatting.None));
                
                var header = new Dictionary<string, string>();
                
                header["AppVersion"] = AppVersion.PC;
                header["Cookie"] = $"{postCfg.SessionKey}={request.SessionID}";

                var json = await httpPostHelper.PostDataWithHeadAsync(request, header);

                var respondData = JObject.Parse(json);

                return respondData.ToObject<RespondData<T>>();


            }
            catch(Exception ex)
            {
                return new RespondData<T>(MJErrorCode.Exception.ErrorCode, ex.Message, default(T));
            }
        }

    }
}
