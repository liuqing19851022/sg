using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.Transaction.PostgreSQLTransactionProvider.Storage
{
    public interface ITransactionStateDataAccessFactory
    {
        //Task<ITransactionStateDataAccess<T>> CreateTransactionStateDataAccess<T>(string stateName)
    }
}
