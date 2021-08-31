using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Helper
{
    public class HttpGetTools
    {

        public static async Task<T> GetJsonAsync<T>(string url)
        {

            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true
            };
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            }

            using (HttpClient httpClient = new HttpClient(httpClientHandler)){
                var response = await httpClient.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                try
                {
                    var respondData = JObject.Parse(json);
                    var result = respondData.ToObject<T>();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task<byte[]> GetBytesAsync(string url)
        {

            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true
            };
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            }

            using (HttpClient httpClient = new HttpClient(httpClientHandler))
            {
                var response = await httpClient.GetAsync(url);
                var result = await response.Content.ReadAsByteArrayAsync();
                return result;
            }
        }

    }
}
