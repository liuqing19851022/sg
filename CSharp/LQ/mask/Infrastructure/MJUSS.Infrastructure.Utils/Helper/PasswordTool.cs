using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Helper
{
    /// <summary>
    /// 密码工具
    /// </summary>
    public class PasswordTool : IPasswordTool
    {
        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public Task<string> GetPasswordHash(string password, string salt)
        {
            string md5SourceString = password + salt;
            byte[] hashBuffer = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(md5SourceString));
            StringBuilder result = new StringBuilder();
            foreach (var item in hashBuffer)
            {
                result.Append(item.ToString("X"));
            }
            return Task.FromResult(result.ToString());
        }

        public Task<string> GetPasswordSalt()
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            var result = r.Next(1000, 9999);
            return Task.FromResult(result.ToString());
        }
    }

    /// <summary>
    /// 密码工具
    /// </summary>
    public interface IPasswordTool
    {
        /// <summary>
        /// 获取密码哈希值
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        Task<string> GetPasswordHash(string password, string salt);
        /// <summary>
        /// 获取随机密码盐
        /// </summary>
        /// <returns></returns>
        Task<string> GetPasswordSalt();
    }
}
