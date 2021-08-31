using LinqToDB.Data;
using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataModel;
using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.IDataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataAccess
{
    public class TransactionStateDataAccess : TableTool<TransactionStateDataModel>, ITransactionStateDataAccess
    {
        public TransactionStateDataAccess(DataConnection dataConnection, string tableName) : base(dataConnection, tableName)
        {
        }

        
        public async Task<List<TransactionStateDataModel>> GetPendingStateList(string dataID)
        {
            var result = await dataConnection.QueryToListAsync<TransactionStateDataModel>($"select * from {GetParamName(tableName)} where {GetParamName(c => c.DataID)}=@DataID order by {GetParamName(c=>c.SequenceId)} asc", new { DataID = dataID });
            return result;
        }
    }
}
