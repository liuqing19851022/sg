using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MJUSS.Infrastructure.Utils.Helper
{
    /// <summary>
    /// 哈希辅助
    /// </summary>
    public class HashHelper
    {
        /// <summary>
        /// 获取Md5 HashCode（大写）32位
        /// </summary>
        /// <param name="md5SourceString"></param>
        /// <returns></returns>
        public static string GetMd5HashCode(string md5SourceString)
        {
            byte[] hashBuffer = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(md5SourceString));
            StringBuilder result = new StringBuilder();
            foreach (var item in hashBuffer)
            {
                result.Append(item.ToString("X2"));
            }
            return result.ToString();
        }
    }
}
