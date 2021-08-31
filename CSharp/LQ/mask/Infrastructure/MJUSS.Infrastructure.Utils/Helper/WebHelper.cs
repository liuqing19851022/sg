using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MJUSS.Infrastructure.Utils.Helper
{
    public class WebHelper
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettingsByKey(string key)
        {
            var result = string.Empty;
            try
            {
                result = ConfigurationManager.AppSettings[key];
            }
            catch
            { }
            return result;
        }
    }
}