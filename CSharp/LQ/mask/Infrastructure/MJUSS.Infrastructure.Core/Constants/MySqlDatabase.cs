#region C#文件说明

// /**********************************************************************************	
// 	* 类   名 ：MySqlDatabase.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Core
// 	* 文 件 名：MySqlDatabase.cs
// 	* 创建时间：2016-05-05 17:53
// 	* 作    者： MJKJ.用户名：>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/

#endregion

using System;

namespace MJUSS.Infrastructure.Core.Constants
{
    /// <summary>
    ///     MySql数据库
    /// </summary>
    public static class MySqlDatabase
    {
        public const string Base = "Base";

        public const string IDGenerate = "IDGenerate";

        public const string DistributedProcesse = "DistributedProcesse";

        public const string Product = "Product";

        public const string WMS = "WMS";


        public const string MemberCard = "MemberCard";

        public const string Account = "Account";

        public const string Tenant = "Tenant";

        public const string SMS = "SMS";

        public const string Message = "Message";

        public const string CRM = "CRM";

        public const string Store = "Store";
        
        public const string Sale = "Sale";

        [Obsolete]
        public const string Sales = Sale;

        public const string Statistic = "Statistic";

        public const string OrleansData = "OrleansData";

        public const string SaasPlatform = "SaasPlatform";

        public const string ImageLibary = "ImageLibary";

        public const string PushMessage = "PushMessage";

        public const string FindTeaHouses = "FindTeaHouses";
    }
}