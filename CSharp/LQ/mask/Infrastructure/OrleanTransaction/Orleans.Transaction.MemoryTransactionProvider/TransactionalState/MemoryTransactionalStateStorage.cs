using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataModel;
using Orleans.Transactions.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Orleans.Transactions;

namespace Orleans.Transaction.MemoryTransactionProvider.TransactionalState
{
    public class MemoryTransactionalStateStorage<TState> : ITransactionalStateStorage<TState> where TState : class, new()
    {
        private readonly JsonSerializerSettings jsonSettings;
        private readonly ILogger logger;
        private string stateName;
        private string dataID;
        private TransactionMetaDataModel transactionMetaDataModel;
        private List<TransactionStateDataModel> stateList;
        private IGrainFactory grainFactory;



        public MemoryTransactionalStateStorage(string stateName, string dataID, JsonSerializerSettings JsonSettings, ILogger<MemoryTransactionalStateStorage<TState>> logger, IGrainFactory grainFactory)
        {
            this.stateName = stateName;
            this.dataID = dataID;
            jsonSettings = JsonSettings;
            this.logger = logger;
            this.grainFactory = grainFactory;

            // default values must be included
            // otherwise, we get errors for explicitly specified default values
            // (e.g.  Orleans.Transactions.Azure.Tests.TestState.state)
            jsonSettings.DefaultValueHandling = DefaultValueHandling.Include;
            stateList = new List<TransactionStateDataModel>();
        }



        public async Task<TransactionalStorageLoadResponse<TState>> Load()
        {
            try
            {

                if (transactionMetaDataModel == null)
                {
                    if (logger.IsEnabled(LogLevel.Debug))
                        logger.LogDebug($"{stateName}:{dataID} Loaded v0, fresh");

                    // first time load
                    return new TransactionalStorageLoadResponse<TState>();
                }

                var committedState = GetCommittedState();
                var prepareRecordsToRecover = GetPrepareRecordsToRecover();

                if (logger.IsEnabled(LogLevel.Debug))
                    logger.LogDebug($"{stateName}:{dataID} Loaded v{transactionMetaDataModel.CommittedSequenceId} rows={string.Join(",", stateList.Select(s => $"{s.DataID}-{s.SequenceId}"))}");

                TransactionalStateMetaData metadata = JsonConvert.DeserializeObject<TransactionalStateMetaData>(transactionMetaDataModel.Metadata, jsonSettings);
                return new TransactionalStorageLoadResponse<TState>(transactionMetaDataModel.ETag, committedState, transactionMetaDataModel.CommittedSequenceId, metadata, prepareRecordsToRecover);
            }
            catch (Exception ex)
            {
                logger.LogError("Transactional state load failed {Exception}.", ex);
                throw;
            }
        }

        private List<PendingTransactionState<TState>> GetPrepareRecordsToRecover()
        {
            var PrepareRecordsToRecover = new List<PendingTransactionState<TState>>();
            foreach (var stateItem in stateList)
            {
                if (stateItem.SequenceId <= transactionMetaDataModel.CommittedSequenceId)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(stateItem.TransactionManager))
                {
                    break;
                }

                var tm = JsonConvert.DeserializeObject<ParticipantId>(stateItem.TransactionManager, jsonSettings);

                var pendingState = JsonConvert.DeserializeObject<TState>(stateItem.StateJson, jsonSettings);
                PrepareRecordsToRecover.Add(new PendingTransactionState<TState>()
                {
                    SequenceId = stateItem.SequenceId,
                    State = pendingState,
                    TimeStamp = stateItem.TransactionTimestamp,
                    TransactionId = stateItem.TransactionId,
                    TransactionManager = tm
                });
            }

            return PrepareRecordsToRecover;
        }

        private TState GetCommittedState()
        {
            TState committedState;
            if (transactionMetaDataModel.CommittedSequenceId == 0 || stateList.Count == 0)
            {
                committedState = new TState();
            }
            else
            {
                var stateDataModel = stateList.FirstOrDefault(c => c.SequenceId == transactionMetaDataModel.CommittedSequenceId);
                if (stateDataModel == null)
                {
                    stateDataModel = stateList.Last();
                    //var error = $"Storage state corrupted: no record for committed state v{transactionMetaDataModel.CommittedSequenceId}";
                    //logger.LogCritical($"{stateName}:{dataID} {error}");
                    //throw new InvalidOperationException(error);
                }
                committedState = JsonConvert.DeserializeObject<TState>(stateDataModel.StateJson, jsonSettings);
            }

            return committedState;
        }

     
        public async Task<string> Store(string expectedETag, TransactionalStateMetaData metadata, List<PendingTransactionState<TState>> statesToPrepare, long? commitUpTo, long? abortAfter)
        {
            //if (transactionMetaDataModel.ETag != expectedETag)
            //    throw new ArgumentException(nameof(expectedETag), "Etag does not match");

            var abortedTransactionStateDataModelList = await CleanUpAbortedRecords(abortAfter);
            var obsoleteBefore = commitUpTo ?? transactionMetaDataModel?.CommittedSequenceId ?? 0;
            (var insertTransactionStateDataModelList, var updateTransactionStateDataModelList) = await AddPrepareRecords(statesToPrepare, obsoleteBefore);
            await SetTransactionMetaData(metadata, commitUpTo);
            var obsoleteTransactionStateDataModelList = await RemoveObsoleteRecords(obsoleteBefore);
            return transactionMetaDataModel.ETag;
        }

    


        private Task<List<TransactionStateDataModel>> RemoveObsoleteRecords(long obsoleteBefore)
        {
            List<TransactionStateDataModel> obsoleteTransactionStateDataModelList = new List<TransactionStateDataModel>();
            obsoleteTransactionStateDataModelList.AddRange(stateList.Where(c => c.SequenceId < obsoleteBefore));
            foreach (var item in obsoleteTransactionStateDataModelList)
            {
                stateList.Remove(item);
            }
            return Task.FromResult(obsoleteTransactionStateDataModelList);
        }

        private Task SetTransactionMetaData(TransactionalStateMetaData metadata, long? commitUpTo)
        {
            if (transactionMetaDataModel == null)
            {
                transactionMetaDataModel = new TransactionMetaDataModel();
                transactionMetaDataModel.CreateTime = DateTime.Now;
            }
            transactionMetaDataModel.Metadata = JsonConvert.SerializeObject(metadata, jsonSettings);
            if (commitUpTo.HasValue && commitUpTo.Value > transactionMetaDataModel.CommittedSequenceId)
            {
                transactionMetaDataModel.CommittedSequenceId = commitUpTo.Value;
            }
            transactionMetaDataModel.LastUpdateTime = DateTime.Now;
            transactionMetaDataModel.ETag = "*";
            return Task.CompletedTask;
        }

        private Task<(List<TransactionStateDataModel> insertTransactionStateDataModelList, List<TransactionStateDataModel> updateTransactionStateDataModelList)> AddPrepareRecords(List<PendingTransactionState<TState>> statesToPrepare, long obsoleteBefore)
        {
            List<TransactionStateDataModel> insertTransactionStateDataModelList = new List<TransactionStateDataModel>();
            List<TransactionStateDataModel> updateTransactionStateDataModelList = new List<TransactionStateDataModel>();
            if (statesToPrepare != null)
            {
                foreach (var s in statesToPrepare)
                {
                    if (s.SequenceId < obsoleteBefore)
                    {
                        continue;
                    }
                    var stateDataModel = stateList.FirstOrDefault(c => c.SequenceId == s.SequenceId);
                    if (stateDataModel != null)
                    {
                        stateDataModel.TransactionId = s.TransactionId;
                        stateDataModel.TransactionTimestamp = s.TimeStamp;
                        stateDataModel.TransactionManager = JsonConvert.SerializeObject(s.TransactionManager, jsonSettings);
                        stateDataModel.StateJson = JsonConvert.SerializeObject(s.State, jsonSettings);
                        updateTransactionStateDataModelList.Add(stateDataModel);

                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace($"{stateName}:{dataID}.{stateDataModel.SequenceId} Update {stateDataModel.TransactionId}");
                    }
                    else
                    {
                        stateDataModel = new TransactionStateDataModel()
                        {
                            DataID = dataID,
                            SequenceId = s.SequenceId,
                            ETag = "*",
                            TransactionManager = JsonConvert.SerializeObject(s.TransactionManager, jsonSettings),
                            Timestamp = s.TimeStamp,
                            TransactionId = s.TransactionId,
                            TransactionTimestamp = s.TimeStamp,
                            StateJson = JsonConvert.SerializeObject(s.State, jsonSettings),

                        };
                        stateList.Add(stateDataModel);
                        insertTransactionStateDataModelList.Add(stateDataModel);

                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace($"{stateName}:{stateDataModel.DataID}.{stateDataModel.SequenceId} Insert {stateDataModel.TransactionId}");
                    }

                }
                stateList = stateList.OrderBy(c => c.SequenceId).ToList();
            }
            return Task.FromResult((insertTransactionStateDataModelList, updateTransactionStateDataModelList));
        }

        private Task<List<TransactionStateDataModel>> CleanUpAbortedRecords(long? abortAfter)
        {
            var abortedTransactionStateDataModelList = new List<TransactionStateDataModel>();
            if (abortAfter.HasValue && stateList.Count > 0)
            {
                abortedTransactionStateDataModelList.AddRange(stateList.Where(c => c.SequenceId > abortAfter));
                foreach (var item in abortedTransactionStateDataModelList)
                {
                    stateList.Remove(item);
                }
            }
            return Task.FromResult(abortedTransactionStateDataModelList);
        }
    }
}
