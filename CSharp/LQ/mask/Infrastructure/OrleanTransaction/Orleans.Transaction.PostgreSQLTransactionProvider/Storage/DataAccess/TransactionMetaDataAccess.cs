using LinqToDB.Data;
using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataModel;
using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.IDataAccess;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using MJUSS.Infrastructure.Core.BaseTypes.SyncData;

namespace Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataAccess
{
    public class TransactionMetaDataAccess : TableTool<TransactionMetaDataModel>, ITransactionMetaDataAccess
    {
        public TransactionMetaDataAccess(DataConnection dataConnection, string tableName) : base(dataConnection, tableName)
        {
        }

        public async Task<TransactionMetaDataModel> GetDataByID(string id)
        {
            var result = await dataConnection.QueryToListAsync<TransactionMetaDataModel>($"select * from {GetParamName(tableName)} where {GetParamName(c=>c.ID)}=@ID", new { ID = id });
            return result.FirstOrDefault();
        }

        public override async Task CreateTable()
        {
            await base.CreateTable();
            var createSqlIndex = $"create index {GetParamName($"Index_{tableName}_LastUpdateTime")} on {GetParamName(tableName)}({GetParamName(c=>c.LastUpdateTime)});";
            createSqlIndex += $"create index {GetParamName($"Index_{tableName}_SyncState")} on {GetParamName(tableName)}({GetParamName(c => c.SyncState)});";
            await dataConnection.ExecuteAsync(createSqlIndex);
        }

        public Task<List<TransactionMetaDataModel>> GetTopNDataList(int count, DateTime lessTime)
        {
            var sql = $"select * from { GetParamName(tableName)} where {GetParamName(c=>c.SyncState)}=@SyncState and {GetParamName(c=>c.LastUpdateTime)} < @LastUpdateTime order by {GetParamName(c=>c.LastUpdateTime)} limit {count}";
            return dataConnection.QueryToListAsync<TransactionMetaDataModel>(sql, new
            {
                LastUpdateTime = lessTime,
                SyncState = (int)ESSyncStateEnum.未同步,
            });
        }

        public Task SetSyncSuccess(List<string> dataIDList)
        {
            var whereIDSql = string.Join($" or ", dataIDList.Select(c=> $"{GetParamName(x=>x.ID)}=\'{c}\'"));
            var sql = $"update {GetParamName(tableName)} set {GetParamName(c=>c.SyncState)}=@SyncState, {GetParamName(c=>c.LastUpdateTime)}=@LastUpdateTime where {whereIDSql} ";
            return dataConnection.ExecuteAsync(sql, new
            {
                SyncState = (int)ESSyncStateEnum.已同步,
                LastUpdateTime = DateTime.Now,
            });
        }

        public Task SetLastUpdateTimeSuccess(List<string> dataIDList, DateTime lastUpdateTime)
        {
            var whereIDSql = string.Join($" or ", dataIDList.Select(c => $"{GetParamName(x => x.ID)}=\'{c}\'"));
            var sql = $"update {GetParamName(tableName)} set  {GetParamName(c => c.LastUpdateTime)}=@LastUpdateTime where {whereIDSql} ";
            return dataConnection.ExecuteAsync(sql, new
            {
                LastUpdateTime = lastUpdateTime,
            });
        }
    }
}
