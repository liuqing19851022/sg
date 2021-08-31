using Orleans;
using Orleans.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Interface.Domain
{
    /// <summary>
    /// 领域模型grain
    /// </summary>
    public interface IMJDomainGrain<T> where T : class, new()
    {
        /// <summary>
        /// 获取state
        /// </summary>
        /// <returns></returns>
        [Transaction(TransactionOption.CreateOrJoin)]
        Task<T> GetState();
    }

}
