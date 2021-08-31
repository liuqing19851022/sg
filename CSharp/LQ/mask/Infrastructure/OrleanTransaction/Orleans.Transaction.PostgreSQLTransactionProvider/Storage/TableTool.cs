using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.Transaction.PostgreSQLTransactionProvider.Storage
{
    public class TableTool<T> : ITableTool<T> where T : class, new()
    {
        protected DataConnection dataConnection;
        protected string tableName;

        public TableTool(DataConnection dataConnection, string tableName = null)
        {
            this.dataConnection = dataConnection;
            this.tableName = tableName;
        }
        public virtual Task Insert(T data)
        {
            return dataConnection.InsertAsync(data, tableName);
        }

        public virtual Task Update(T data)
        {
            return dataConnection.UpdateAsync(data, tableName);
        }

        public virtual Task Delete(T data)
        {
            return dataConnection.DeleteAsync(data, tableName);
        }

        public virtual Task CreateTable()
        {
            return dataConnection.CreateTableAsync<T>(tableName);
        }

        public virtual Task BulkCopy(IEnumerable<T> dataList)
        {
            return dataConnection.BulkCopyAsync(dataList);
        }

        protected string GetParamName(string name)
        {
            return $"\"{name}\"";
        }

        protected string GetParamName<TProperty>(System.Linq.Expressions.Expression<System.Func<T, TProperty>> express)
        {
            var memberName = ((System.Linq.Expressions.MemberExpression)express.Body).Member.Name;
            return GetParamName(memberName);
        }
    }

}
