using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orleans.Transaction.PostgreSQLTransactionProvider.Storage
{
    /// <summary>
    /// 表工具
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITableTool<T> where T : class, new()
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task Insert(T data);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task Update(T data);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task Delete(T data);
        /// <summary>
        /// 创建表
        /// </summary>
        /// <returns></returns>
        Task CreateTable();
        /// <summary>
        /// 批量拷贝
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns></returns>
        Task BulkCopy(IEnumerable<T> dataList);
    }
}
