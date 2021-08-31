#region C#文件说明
// /**********************************************************************************	
// 	* 类   名 ：SysPredefined.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Core
// 	* 文 件 名：SysPredefined.cs
// 	* 创建时间：2016-06-12 16:18
// 	* 作    者： MJKJ.hermes liu>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion
namespace MJUSS.Infrastructure.Core.Constants
{
    using System;

    public static class SysPredefined
    {
        public const ushort Version = 1;
        public const string MetaTableEndName = "MetaData";
        /// <summary>
        /// 默认时间
        /// </summary>
        public static readonly DateTime DefaultDateTime = new DateTime(2000, 1, 1);

        public static readonly DateTime ForverDateTime = new DateTime(9999, 1, 1);
        /// <summary>
        /// 最小时间
        /// </summary>
        public static readonly DateTime MinDateTime = new DateTime(1900, 1, 1);
        /// <summary>
        /// 免费试用天数
        /// </summary>
        public static readonly int FreeUsedDay = 10;
        /// <summary>
        /// 约麻超时自动取消分钟数
        /// </summary>
        public static readonly int ChessPartyExpiredAutoCancleMinites = 120;

        /// <summary>
        /// 注册显示图形码阀值
        /// </summary>
        public static readonly int RegisterShowImageCodeThreshold = 10;

        /// <summary>
        /// 数据补偿同步到ElasticSeach延迟时间
        /// </summary>
        public static readonly int EsSyncDelaySecond = 300;
        public static int EsPublishTenantID
        {
            get
            {
                return DateTime.Now.Second;
            }
        }

        /// <summary>
        /// 最大查询记录数
        /// </summary>
        public static readonly int MaxQueryTotalCountThreshold = 5000;

        /// <summary>
        /// Silo的主机名，hosts里面定义的名字
        /// </summary>
        public static readonly string OrleansSiloHostName = "MJOrleans";

        /// <summary>
        /// 网站重试连接SiloHost的次数
        /// </summary>
        public static readonly int WebClientRetryNumber = 3;

        /// <summary>
        /// 无人门店提前消费分钟数
        /// </summary>
        public static readonly int UnmannedStoreBeginConsumeBeforeMinutes = 15;
        /// <summary>
        /// 无人门店自动取消未付款消费分钟数
        /// </summary>
        public static readonly int UnmannedStoreAutoCancleNoPayOrderMinutes = 2;
        /// <summary>
        /// ZCL没有图片400_300
        /// </summary>
        public const string NoPic400_300 = "https://zclimg.mjzhcl.com/nopic.jpg";
        /// <summary>
        /// ZCL没有图片750_400
        /// </summary>
        public const string NoPic750_400 = "https://zclimg.mjzhcl.com/nopic754x40.jpg";
        /// <summary>
        /// 无图200x200
        /// </summary>
        public const string NoPic200_200 = "https://zclimg.mjzhcl.com/noimg1x1.png";

        public const string MeiTuanAuthUrl = "https://pc.mjzhcl.com/dzopen/oauth/auth";

    }
}