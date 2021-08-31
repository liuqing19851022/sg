namespace MJUSS.Infrastructure.Core.BaseInterface
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    using MJUSS.Infrastructure.Core.Common;

    /// <summary>
    ///     数据访问层接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataAccess<T>
        where T : class
    {
        /// <summary>
        ///     增加数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<int> Add(T data, IDbTransaction transaction = null);

        /// <summary>
        ///     修改数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="transaction"></param>
        Task Update(T data, IDbTransaction transaction = null);

        /// <summary>
        ///     删除数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="transaction"></param>
        Task Delete(T data, IDbTransaction transaction = null);

        /// <summary>
        ///     分页数据
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="pageSort"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<PageData<T>> GetPageData(
            string condition,
            string pageSort,
            int pageIndex,
            int pageSize,
            Dictionary<string, object> param);

        /// <summary>
        /// 获取首页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetTopData(string where = "1 = 1", string orderBy = "ID asc", int pageSize = 10, object param = null);
    }
}