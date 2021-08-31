#region C#文件说明
// /**********************************************************************************
// 	* CLR版本 ：4.0.30319.17929
// 	* 类   名 ：MySqlConnectionFactory.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Utils
// 	* 文 件 名：MySqlConnectionFactory.cs
// 	* 创建时间：2016-05-04 9:17
// 	* 作    者： MJKJ.用户名：>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/
#endregion
namespace MJUSS.Infrastructure.Utils.DataAccess
{
    using System;

    using MJUSS.Infrastructure.Core.Config;
    using MJUSS.Infrastructure.Core.Constants;
    using MJUSS.Infrastructure.Utils.Helper;

    using MySql.Data.MySqlClient;

    /// <summary>
    /// MySql数据库连接工厂
    /// </summary>
    public static class MySqlConnectionFactory
    {
        private const string mysqlConfigFilePath = "~/Config/MysqlConnect.config";

        /// <summary>
        /// 创建数据库连接（SslMode=none）
        /// </summary>
        /// <param name="database">数据库</param>
        /// <returns></returns>
        public static MySqlConnection CreateMySqlConnectionByDbName(string database)
        {
            try
            {
                var mysqlConnectConfig = ConfigHandler.GetConfig<MySQLConnectConfig>(mysqlConfigFilePath);
                var mysqlServer = mysqlConnectConfig[database];

                var mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder
                {
                    Server = mysqlServer.Server,
                    Database = mysqlServer.DataBase,
                    UserID = mysqlServer.UserID,
                    Password = mysqlServer.Password,
                    CharacterSet = mysqlServer.Charset,
                    Port = mysqlServer.Port,
                    SslMode = MySqlSslMode.None
                };
                return new MySqlConnection(mySqlConnectionStringBuilder.ConnectionString);
            }
            catch
            {

                throw new Exception("DbConfig 错误.");
            }

        }
    }
}