//#region C#文件说明
//// /**********************************************************************************	
//// 	* 类   名 ：HttpContextExtention.cs
//// 	* 功能描述：<简单描述类的作用>
//// 	* 机器名称：MJ-LIUJIANHUA
//// 	* 命名空间：MJUSS.Infrastructure.Utils
//// 	* 文 件 名：HttpContextExtention.cs
//// 	* 创建时间：2016-05-20 17:08
//// 	* 作    者： MJKJ.hermes liu>
//// 
//// 	* 修 改 人：<修改人名称>
//// 	* 修改描述：<修改内容>
//// 	* 修改时间：YYYY-MM-DD 00:00:00
//// **********************************************************************************/
//#endregion
//namespace MJUSS.Infrastructure.Utils.Extentions
//{
//    using System.IO;
//    using System.Web;

//    public static class HttpContextExtention
//    {
//        /// <summary>
//        /// 获取请求数据Byte数组
//        /// </summary>
//        /// <param name="context"></param>
//        /// <returns></returns>
//        public static byte[] GetRequestBytes(this HttpContext context)
//        {
//            const int bufferSize = 1024;
//            var buffer = new byte[bufferSize];
//            var stream = new MemoryStream();
//            while (true)
//            {
//                var readLength = context.Request.InputStream.Read(buffer, 0, buffer.Length);
//                if (readLength <= 0)
//                    break;
//                stream.Write(buffer, 0, readLength);
//            }
//            return stream.ToArray();
//        }
//    }
//}