
namespace MJUSS.Infrastructure.Utils.Helper
{
    using System.IO;
    using System.IO.Compression;

    /// <summary>
    ///     gzip工具
    /// </summary>
    public class GzipTools
    {
        /// <summary>
        ///     压缩数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] GetCompressData(byte[] data)
        {
            var result = new MemoryStream();
            var buffer = new byte[1024];
            using (var gzipStream = new GZipStream(result, CompressionMode.Compress))
            {
                gzipStream.Write(data, 0, data.Length);
            }
            return result.ToArray();
        }

        /// <summary>
        ///     解压数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] GetDeCompressData(byte[] data)
        {
            var result = new MemoryStream();
            using (var gzipStream = new GZipStream(new MemoryStream(data), CompressionMode.Decompress))
            {
                var buffer = new byte[1024];

                while (true)
                {
                    var readLength = gzipStream.Read(buffer, 0, buffer.Length);
                    if (readLength <= 0)
                    {
                        break;
                    }
                    result.Write(buffer, 0, readLength);
                }
            }
            return result.ToArray();
        }
    }
}