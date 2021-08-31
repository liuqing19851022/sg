#region C#文件说明
// /**********************************************************************************	
// 	* 类   名 ：ByteExtention.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Utils
// 	* 文 件 名：ByteExtention.cs
// 	* 创建时间：2016-05-20 17:04
// 	* 作    者： MJKJ.hermes liu>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion
namespace MJUSS.Infrastructure.Utils.Extentions
{
    using MJUSS.Infrastructure.Utils.Helper;

    public static class ByteExtention
    {
        /// <summary>
        /// Gzip解压
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static byte[] DeCompress(this byte[] buffer)
        {
            return GzipTools.GetDeCompressData(buffer);
        }
    }
}