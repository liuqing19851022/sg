namespace MJUSS.Infrastructure.Utils.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Dapper;

    using MJUSS.Infrastructure.Core.Common;

    /// <summary>
    ///     数据库事务扩展工具
    /// </summary>
    public static class DbConnectionExtention
    {
        /// <summary>
        ///     执行事务
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="action"></param>
        public static async Task ExecuteTranstransaction(
            this IDbConnection dbConnection,
            Func<IDbTransaction, Task> action)
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }

            var transaction = dbConnection.BeginTransaction();
            try
            {
                await action(transaction);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                dbConnection.Close();
            }
        }


        public static async Task<int> CountAsync<T>(this IDbConnection dbConnection, string where, object param = null, IDbTransaction trans = null) {
            var result = await dbConnection.ExecuteScalarAsync<int>($"SELECT COUNT(1) FROM {typeof(T).Name} WHERE {where}", param, trans);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sql">条件需要参数化:ID=@ID</param>
        /// <param name="orderby"></param>
        /// <param name="param">示例代码：var param=new DynamicParameters();param.Add("ID",123);</param>
        /// <returns></returns>
        public static async Task<PageData<T>> GetPageData<T>(
            this IDbConnection dbConnection,
            int pageIndex,
            int pageSize,
            string sql,
            string orderby,
            Dictionary<string,object> param)
        {
            var countSQL= $@"select count(0) as Total from ({sql}) as T;";
            var sbSQL = new StringBuilder();
            
            sbSQL.AppendFormat(@"select * from ({0}) as T order by {1} limit @StartDataIndex, @PageSize ", sql, orderby);
            var dapperParam = new DynamicParameters();
            if (param != null)
            {
                foreach (var item in param)
                {
                    dapperParam.Add(item.Key,item.Value);
                }
            }
            var totalCount = await dbConnection.QueryAsync<long>(countSQL, dapperParam);
            dapperParam.Add("StartDataIndex", (pageIndex - 1) * pageSize);
            dapperParam.Add("PageSize", pageSize);
            var pageList =await dbConnection.QueryAsync<T>(sbSQL.ToString(), dapperParam);
            return new PageData<T>(pageList.ToList(), totalCount.FirstOrDefault(), pageSize, pageIndex);
        }

        public static async Task<IEnumerable<T>> GetTopData<T>(
            this IDbConnection dbConnection,
            string tableName,
            string where ="1 = 1",
            string orderby = "ID ASC",
            int pageSize = 20,
            object param = null)
        {

            var sbSQL = new StringBuilder();

            sbSQL.AppendFormat($"select * from {tableName} where {where} order by {orderby} limit {pageSize} ");

            return await dbConnection.QueryAsync<T>(sbSQL.ToString(), param);
           
        }
    }
}