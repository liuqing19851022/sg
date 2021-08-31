using Orleans;
using Orleans.Transactions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MJ.Service.Tool.Interface.DataChange;
using MJ.Service.Tool.Interface.TransactionDomainStateChangeTrack.Param;
using MJ.Service.Tool.Interface.TransactionDomainStateChangeTrack.State;
using MJ.Service.Tool.Interface.TransactionDomainStateChangeTrack;
using MJ.Service.Tool.Interface.DataChange.Param;
using MJ.Service.Tool.Interface.Tool;
using MJUSS.Infrastructure.Utils.Helper;
using MJ.Service.Tool.DTO.Tool.Bulk.Request;
using MJ.Service.Tool.DTO.Tool.Bulk;
using Microsoft.Extensions.Logging;

namespace MJ.Service.Tool.Implement.TransactionDomainStateChangeTrack
{
    public class TransactionDomainStateChangeTrackGrain : Grain, ITransactionDomainStateChangeTrackGrain
    {
        private TransactionDomainStateChangeTrackState state;
        private ILogger<TransactionDomainStateChangeTrackGrain> logger;
        private IIndexDataGrainManager indexDataGrainManager;

        public TransactionDomainStateChangeTrackGrain(ILogger<TransactionDomainStateChangeTrackGrain> logger, IIndexDataGrainManager indexDataGrainManager)
        {
            this.logger = logger;
            this.indexDataGrainManager = indexDataGrainManager;
        }

        public override Task OnActivateAsync()
        {
            state = new TransactionDomainStateChangeTrackState();
            state.TransactionID = this.GetPrimaryKeyString();
            return Task.CompletedTask;
        }

        public Task DomainStateChange(RequestDomainStateChangeParam param)
        {
            state.LastUpdateTime = DateTime.Now;
            state.StateChangeTrackingDataList.Add(new StateChangeTrackingData()
            {
                DataID = param.DataID,
                StateName = param.DomainStateName,
                ModuleName = param.ModuleName,
                Data = param.Data,
            });
            return Task.CompletedTask;
        }

        public Task<TransactionDomainStateChangeTrackState> GetState()
        {
            return Task.FromResult(state);
        }

        public async Task Publish()
        {
            if(state.StateChangeTrackingDataList.Count == 0)
            {
                return;
            }
            try
            {
                var esBuilkServiceGrain = this.GrainFactory.GetGrain<IESBulkServiceGrain>(state.TransactionID);
                var requestBeginBulkDTO = ServiceRequestFactory.Create<RequestBeginBulkDTO>(0, 0);
                requestBeginBulkDTO.Data.BulkID = state.TransactionID;
                await esBuilkServiceGrain.BeginBulk(requestBeginBulkDTO);

                var requestAddBulkDataDTO = ServiceRequestFactory.Create<RequestAddBulkDataDTO>(0, 0);
                requestAddBulkDataDTO.Data.BulkID = state.TransactionID;
                foreach (var stateChangeTrackingDataItem in state.StateChangeTrackingDataList.ToLookup(c => $"{c.StateName}_{c.DataID}", c => c))
                {
                    var item = stateChangeTrackingDataItem.Last();
                    
                    requestAddBulkDataDTO.Data.BulkIndexDataList.Add(new BulkIndexData()
                    {
                        Data = item.Data,
                        DataID = item.DataID,
                        IndexName = string.IsNullOrEmpty(item.ModuleName) switch
                        {
                            true => item.StateName.ToLower(),
                            _ => $"{item.ModuleName}_{item.StateName}".ToLower(),
                        },
                        TypeName = item.StateName.ToLower(),
                        IndexDataGrain = await indexDataGrainManager.GeteIndexDataGrain(this.GrainFactory, item.StateName, item.DataID),
                    });
                }
                await esBuilkServiceGrain.AddBulkData(requestAddBulkDataDTO);

                var requestCommitBulkDataDTO = ServiceRequestFactory.Create<RequestCommitBulkDataDTO>(0, 0);
                requestCommitBulkDataDTO.Data.BulkID = state.TransactionID;
                await esBuilkServiceGrain.CommitBulkData(requestCommitBulkDataDTO);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.GetBaseException().ToString());
            }

        }
    }
}
