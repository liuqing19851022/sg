using System.Data;

using MJUSS.Infrastructure.Core.Config;
using MJUSS.Infrastructure.Utils.Helper;

using MySql.Data.MySqlClient;

namespace MJUSS.Infrastructure.Utils.DataAccess
{
    public class OwnMySqlConnection : IDbConnection
    {
        private const string mysqlConfigFilePath = "~/Config/MysqlConnect.config";

        private readonly IDbConnection sqlDbConnection;

        public OwnMySqlConnection(string database)
        {
            var mysqlConnectConfig = ConfigHandler.GetConfig<MySQLConnectConfig>(mysqlConfigFilePath);
            var dbConnectConfig = mysqlConnectConfig[database];
            var mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = dbConnectConfig.Server,
                Database = dbConnectConfig.DataBase,
                UserID = dbConnectConfig.UserID,
                Password = dbConnectConfig.Password,
                CharacterSet = dbConnectConfig.Charset,
                Port = dbConnectConfig.Port
            };
            this.sqlDbConnection = new MySqlConnection(mySqlConnectionStringBuilder.ConnectionString);
        }

        public void Dispose()
        {
            this.sqlDbConnection.Dispose();
        }

        public IDbTransaction BeginTransaction()
        {
            return this.sqlDbConnection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return this.sqlDbConnection.BeginTransaction(il);
        }

        public void Close()
        {
            this.sqlDbConnection.Close();
        }

        public void ChangeDatabase(string databaseName)
        {
            this.sqlDbConnection.ChangeDatabase(databaseName);
        }

        public IDbCommand CreateCommand()
        {
            return this.sqlDbConnection.CreateCommand();
        }

        public void Open()
        {
            this.sqlDbConnection.Open();
        }

        public string ConnectionString
        {
            get
            {
                return this.sqlDbConnection.ConnectionString;
            }
            set
            {
                this.sqlDbConnection.ConnectionString = value;
            }
        }

        public int ConnectionTimeout => this.sqlDbConnection.ConnectionTimeout;

        public string Database => this.sqlDbConnection.Database;

        public ConnectionState State => this.sqlDbConnection.State;
    }
}