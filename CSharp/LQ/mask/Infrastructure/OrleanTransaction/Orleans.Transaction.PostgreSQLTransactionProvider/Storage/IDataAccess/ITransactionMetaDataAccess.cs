using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.Transaction.PostgreSQLTransactionProvider.Storage.IDataAccess
{
    public interface ITransactionMetaDataAccess: ITableTool<TransactionMetaDataModel>
    {
        /// <summary>
        /// 根据编号获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TransactionMetaDataModel> GetDataByID(string id);

        /// <summary>
        /// 获取前N条数据
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<TransactionMetaDataModel>> GetTopNDataList(int count, DateTime lessTime);

        /// <summary>
        /// 设置同步成功
        /// </summary>
        /// <param name="dataIDList"></param>
        /// <returns></returns>
        Task SetSyncSuccess(List<string> dataIDList);

        /// <summary>
        /// 设置同步成功
        /// </summary>
        /// <param name="dataIDList"></param>
        /// <returns></returns>
        Task SetLastUpdateTimeSuccess(List<string> dataIDList, DateTime lastUpdateTime);
    }
}
