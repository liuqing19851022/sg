namespace MJUSS.Infrastructure.Utils.Helper
{
    using MJUSS.Infrastructure.Core.Exceptions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Post数据工具
    /// </summary>
    public class HttpPostTools
    {
        private readonly string url;

        private Uri uri;
        public HttpPostTools(string url)
        {
            this.url = url;
            this.uri = new Uri(url);
        }
        ///// <summary>
        ///// Post数据
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public byte[] PostData(byte[] data)
        //{
        //   var compressData = GetCompressData(data);
        //    var request = (HttpWebRequest)WebRequest.Create(this.url);
        //    request.Method = "Post";
        //    request.ContentType = "text/plain";
        //    request.ContentLength = compressData.Length;
        //    request.Timeout = (int)TimeSpan.FromMinutes(6).TotalMilliseconds;
        //    SendData(compressData, request);
        //    HttpWebResponse respond = null;
        //    try
        //    {
        //        respond = request.GetResponse() as HttpWebResponse;
        //    }
        //    catch (WebException e)
        //    {
        //        respond = e.Response as HttpWebResponse;
        //    }
        //    var result = ReadData(respond);
        //    return GetDeCompressData(result.ToArray());
        //}

        public async Task<byte[]> PostDataAsync(byte[] data)
        {
            //var compressData = GetCompressData(data);
            //var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            using (HttpClient httpClient = new HttpClient())
            {
                
               // httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("GZIP"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
                httpClient.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, this.uri);
                request.Content = new ByteArrayContent(data);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/json");
                
                
                var respond = await httpClient.SendAsync(request); ;
                var result = await respond.Content.ReadAsByteArrayAsync();
                return result;
            }
        }

        /// <summary>
        /// url方式post提交数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<byte[]> PostDataAsync(byte[] data, CookieContainer cookieContainer)
        {
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (HttpClient httpClient = new HttpClient(handler))
            {

                // httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("GZIP"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
                httpClient.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, this.uri);
                request.Content = new ByteArrayContent(data);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/json");
              


                var respond = await httpClient.SendAsync(request); ;
                var result = await respond.Content.ReadAsByteArrayAsync();
                return result;
            }
        }



        /// <summary>
        /// url方式post提交数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<byte[]> PostDataUrlAsync(byte[] data)
        { 
            using (HttpClient httpClient = new HttpClient())
            {              
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                httpClient.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, this.uri);
                request.Content = new ByteArrayContent(data);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");


                var respond = await httpClient.SendAsync(request); ;
                var result = await respond.Content.ReadAsByteArrayAsync();
                return result;
            }
        }

        /// <summary>
        /// url方式post提交数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<byte[]> PostDataApplicationJsonAsync(byte[] data)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, this.uri);
                request.Content = new ByteArrayContent(data);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                var respond = await httpClient.SendAsync(request); ;
                var result = await respond.Content.ReadAsByteArrayAsync();
                return result;
            }
        }


        ///// <summary>
        ///// Post数据
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public byte[] PostDataWithOutGzip(byte[] data)
        //{

        //    var request = (HttpWebRequest)WebRequest.Create(this.url);
        //    request.Method = "Post";
        //    request.ContentType = "text/json";
        //    request.ContentLength = data.Length;
        //    request.Timeout = (int)TimeSpan.FromMinutes(6).TotalMilliseconds;
        //    SendData(data, request);
        //    HttpWebResponse respond = null;
        //    try
        //    {
        //        respond = request.GetResponse() as HttpWebResponse;
        //    }
        //    catch (WebException e)
        //    {
        //        respond = e.Response as HttpWebResponse;
        //    }
        //    var result = ReadData(respond);
        //    return result.ToArray();
        //}

        ///// <summary>
        ///// post 字符串
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public string PostData(string data)
        //{
        //    var beginTime = DateTime.Now;
        //    var sendData = Encoding.UTF8.GetBytes(data);
        //    var receiveData = this.PostData(sendData);
        //    var result = Encoding.UTF8.GetString(receiveData);
        //    Console.WriteLine("请求数据{0}，花费时间：{1}", data, DateTime.Now.Subtract(beginTime).TotalSeconds);
        //    return result;
        //}

        /// <summary>
        /// Get获取URL数据
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetDataAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var result = await httpClient.GetByteArrayAsync(uri);                
                return result;
            }
        }

        public  async Task<T> GetJsonAsync<T>(byte[] data = null)
        {

            var respondDataBuffer = await this.PostDataAsync(data ?? new byte[0]);
            try
            {
                var json = Encoding.UTF8.GetString(respondDataBuffer);
                var respondData = JObject.Parse(json);
                var result = respondData.ToObject<T>();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<string> PostDataWithHeadAsync<T>(T obj,IDictionary<string,string> head, string contentType = "text/json")
        {
            using (HttpClient httpClient = new HttpClient(new HttpClientHandler
            {
                UseCookies = false
            })
            { Timeout = new TimeSpan(0, 0, 30) })
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
                httpClient.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, this.uri);
                foreach (var item in head)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
                var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));

                request.Content = new ByteArrayContent(data);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                var respond = await httpClient.SendAsync(request); ;
                var json = await respond.Content.ReadAsStringAsync();
                return json;
                //return JObject.Parse(json).ToObject<D>();
            }
        }


        public async Task<string> GetDataWithHeadAsync(IDictionary<string, string> heads)
        {

            using (var httpClient = new HttpClient())
            {
                // httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("GZIP"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
                httpClient.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));

                var request = new HttpRequestMessage(HttpMethod.Get, this.uri);

                foreach (var head in heads)
                {
                    request.Headers.Add(head.Key, head.Value);
                }
                var respond = await httpClient.SendAsync(request);

                var result = await respond.Content.ReadAsByteArrayAsync();

                if (respond.StatusCode == HttpStatusCode.OK)
                {

                    var strResult = Encoding.UTF8.GetString(result);

                    return strResult;
                }
                else
                {
                    throw new ServiceException("请求过程中遇到错误",(int)respond.StatusCode );
                }
            }


        }

        #region 私有方法
        private static void SendData(byte[] compressData, HttpWebRequest request)
        {
            var reqeustStream = request.GetRequestStream();
            reqeustStream.Write(compressData, 0, compressData.Length);
            reqeustStream.Close();
        }
        private static MemoryStream ReadData(WebResponse respond)
        {
            var respondStream = respond.GetResponseStream();

            var buffer = new byte[1024];
            var result = new MemoryStream();
            while (true)
            {
               
                var readLength = respondStream.Read(buffer, 0, buffer.Length);
                if (readLength <= 0)
                    break;
                result.Write(buffer, 0, readLength);
            }
            respondStream.Close();
            return result;
        }
        private static byte[] GetCompressData(byte[] data)
        {
            var result = new MemoryStream();
            var buffer = new byte[1024];
            var gzipStream = new GZipStream(result, CompressionMode.Compress);
            gzipStream.Write(data, 0, data.Length);
            gzipStream.Close();
            return result.ToArray();
        }
        private static byte[] GetDeCompressData(byte[] data)
        {
            var gzipStream = new GZipStream(new MemoryStream(data), CompressionMode.Decompress);
            var buffer = new byte[1024];
            var result = new MemoryStream();
            while (true)
            {
                var readLength = gzipStream.Read(buffer, 0, buffer.Length);
                if (readLength <= 0)
                    break;
                result.Write(buffer, 0, readLength);
            }
            gzipStream.Close();
            return result.ToArray();
        }
        #endregion
    }
}
