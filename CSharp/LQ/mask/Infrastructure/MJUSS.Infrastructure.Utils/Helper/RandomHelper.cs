using System;

namespace MJUSS.Infrastructure.Utils.Helper
{
    public static class RandomHelper
    {
        /// <summary>  
        /// 生成随机GrainKey数
        /// </summary>  
        /// <returns>随机的数值</returns>  
        public static int GetRandomGrainKey()
        {
            var min = 0;
            var max = 4;
            Random ro = new Random(DateTime.Now.Millisecond);
            return ro.Next(min, max);
        }

        /// <summary>  
        /// 生成使用TeanantID做为GrainKey的随机数(用于基础服务)
        /// </summary>  
        /// <returns>随机的数值</returns>  
        public static long GetTenantIDRandomGrainKeyForBasicService(long tenantID)
        {
            var min = 0;
            var max = 4;
            Random ro = new Random(DateTime.Now.Millisecond);
            return tenantID + ro.Next(min, max);
        }

        /// <summary>  
        /// 生成使用TeanantID做为GrainKey的随机数(用于ES)
        /// </summary>  
        /// <returns>随机的数值</returns>  
        public static long GetTenantIDRandomGrainKey(long tenantID)
        {
            var min = 0;
            var max = 4;
            Random ro = new Random(DateTime.Now.Millisecond);
            return tenantID + ro.Next(min, max);
        }
    }
}
