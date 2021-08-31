using MJ.Service.Tool.Interface.TransactionDomainStateChangeTrack.Param;
using MJ.Service.Tool.Interface.TransactionDomainStateChangeTrack.State;
using MJUSS.Infrastructure.Core.Constants;
using Orleans;
using Orleans.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Interface.TransactionDomainStateChangeTrack
{
    /// <summary>
    /// 数据变化跟踪服务
    /// </summary>
    [Version(SysPredefined.Version)]
    public interface ITransactionDomainStateChangeTrackGrain : IGrainWithStringKey
    {
        /// <summary>
        /// 领域数据模型变化
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Transaction(TransactionOption.Suppress)]
        Task DomainStateChange(RequestDomainStateChangeParam param);

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <returns></returns>
        [Transaction(TransactionOption.Suppress)]
        Task<TransactionDomainStateChangeTrackState> GetState();

        /// <summary>
        /// 推送变更数据
        /// </summary>
        /// <returns></returns>
        Task Publish();

    }
}
