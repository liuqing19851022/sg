using MJ.Service.Tool.Interface.Domain;
using MJ.Service.Tool.Interface.TransactionDomainStateChangeTrack;
using MJ.Service.Tool.Interface.TransactionDomainStateChangeTrack.Param;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Orleans;
using Orleans.Transactions;
using Orleans.Transactions.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Implement.Domain
{
    [Orleans.Concurrency.Reentrant]
    public class MJDomainGrain<T> : Grain, IMJDomainGrain<T> where T : class, new()
    {
        protected ITransactionalState<T> state;
        protected string storeageName = "MJ";

        public MJDomainGrain(ITransactionalState<T> state)
        {
            var contructorMethod = this.GetType().GetConstructors().First();
            var parameter = contructorMethod.GetParameters().Where(c => c.CustomAttributes.Any(c => c.AttributeType.Name == typeof(TransactionalStateAttribute).Name)).FirstOrDefault();
            if(parameter != null)
            {
                var transactionalStateAttribute = parameter.GetCustomAttributes(false)
                                                           .FirstOrDefault(c => c.GetType().Name == typeof(TransactionalStateAttribute).Name) as TransactionalStateAttribute;
                if(transactionalStateAttribute != null)
                {
                    storeageName = transactionalStateAttribute.StorageName;
                }
            }
            this.state = state;
        }

        protected virtual Task<TResult> PerformRead<TResult>(Func<T, TResult> readFunction)
        {
            return state.PerformRead(readFunction);
        }
        /// <summary>
        /// 执行更新状态，有返回值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="updateFunction"></param>
        /// <returns></returns>
        protected virtual async Task<TResult> PerformUpdate<TResult>(Func<T, TResult> updateFunction)
        {
            var result = await state.PerformUpdate(updateFunction);
            var transactionInfo = TransactionContext.GetTransactionInfo();
            var currentState = await GetState();

            await GrainFactory.GetGrain<ITransactionDomainStateChangeTrackGrain>(transactionInfo.Id)
                .DomainStateChange(new RequestDomainStateChangeParam()
                {
                    TransactionID = transactionInfo.Id,
                    DataID = this.GetPrimaryKeyString() ?? this.GetPrimaryKeyLong().ToString(),
                    DomainStateName = typeof(T).Name,
                    Data = JObject.FromObject(currentState).ToString(Formatting.None),
                    ModuleName = storeageName,
                });

            return result;
        }
        /// <summary>
        /// 执行更新状态,无返回值
        /// </summary>
        /// <param name="updateFunction"></param>
        /// <returns></returns>
        protected virtual async Task PerformUpdate(Action<T> updateFunction)
        {
            await state.PerformUpdate(updateFunction);
            var transactionInfo = TransactionContext.GetTransactionInfo();
            var currentState = await GetState();

            await GrainFactory.GetGrain<ITransactionDomainStateChangeTrackGrain>(transactionInfo.Id)
                .DomainStateChange(new RequestDomainStateChangeParam()
                {
                    TransactionID = transactionInfo.Id,
                    DataID = this.GetPrimaryKeyString() ?? this.GetPrimaryKeyLong().ToString(),
                    DomainStateName = typeof(T).Name,
                    Data = JObject.FromObject(currentState).ToString(Formatting.None),
                    ModuleName = storeageName,
                });
        }
        /// <summary>
        /// 获取State
        /// </summary>
        /// <returns></returns>
        public Task<T> GetState()
        {
            return PerformRead(c =>
            {
                return c;
            });
        }
    }
}
