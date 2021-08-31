using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orleans.Transaction.PostgreSQLTransactionProvider.Storage.IDataAccess
{
    public interface ITransactionStateDataAccess : ITableTool<TransactionStateDataModel> 
    {
        /// <summary>
        /// 获取事务挂起的数据
        /// </summary>
        /// <param name="dataID"></param>
        /// <returns></returns>
        Task<List<TransactionStateDataModel>> GetPendingStateList(string dataID);
    }
}
