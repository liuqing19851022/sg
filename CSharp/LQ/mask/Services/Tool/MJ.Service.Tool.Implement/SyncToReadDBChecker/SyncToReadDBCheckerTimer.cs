using LinqToDB.Configuration;
using LinqToDB.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MJ.Service.Tool.Interface.SyncToReadDBChecker;
using MJUSS.Infrastructure.Core.Constants;
using MJUSS.Infrastructure.Core.CustomAttributes;
using Newtonsoft.Json.Linq;
using Orleans;
using Orleans.Providers;
using Orleans.Transaction.PostgreSQLTransactionProvider.Config;
using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataAccess;
using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.DataModel;
using Orleans.Transaction.PostgreSQLTransactionProvider.Storage.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Implement.SyncToReadDBChecker
{
    public partial class SyncToReadDBCheckerTimer : Grain, ISyncToReadDBCheckerTimer
    {
        protected bool isStart;
        protected DataConnection dataConnection;
        protected List<string> domainStateNameList;
        protected Dictionary<string, ITransactionMetaDataAccess> metaDataDataAccessMap;
        protected Queue<(string tableName, TransactionMetaDataModel metaDataModel, ITransactionMetaDataAccess metaDataDataAccess)> executeQueue;
        protected int tableIndex;
        protected ILoggerFactory loggerFactory;
        protected int delayTime = 1000;
        protected int bulkGetVersionCount = 50;
        protected int delayMinute = 5;
        protected string storageName;
        protected Assembly domainAssembly;
        protected IOptionsMonitor<AdoTransactionProviderConfig> config;
        public SyncToReadDBCheckerTimer(IOptionsMonitor<AdoTransactionProviderConfig> config, ILoggerFactory loggerFactory)
        {

            this.config = config;
            metaDataDataAccessMap = new Dictionary<string, ITransactionMetaDataAccess>();
            executeQueue = new Queue<(string, TransactionMetaDataModel, ITransactionMetaDataAccess)>();
            this.loggerFactory = loggerFactory;
        }


        public override async Task OnActivateAsync()
        {
            dataConnection = await GetDataConnection();
        }

        public override async Task OnDeactivateAsync()
        {
            await dataConnection.DisposeAsync();
        }

        private Task<DataConnection> GetDataConnection()
        {
            var adoTransactionProviderConfig = config.Get(storageName);

            var builder = new LinqToDbConnectionOptionsBuilder();
            builder.UsePostgreSQL(adoTransactionProviderConfig.ConnectionString);
            var result = new DataConnection(builder.Build());
            return Task.FromResult(result);
        }

        private Task<List<string>> GetTableNameList()
        {
            var schema = dataConnection.DataProvider.GetSchemaProvider().GetSchema(dataConnection);
            var result = schema.Tables.Where(c => !c.TableName.EndsWith(SysPredefined.MetaTableEndName)).Select(c => c.TableName).ToList();
            return Task.FromResult(result);
        }

        protected virtual async Task OnTime(object arg)
        {
            await RefreshQueueData();
            if (executeQueue.Count == 0)
            {
                tableIndex++;
                if (tableIndex >= domainStateNameList.Count)
                {
                    tableIndex = 0;
                }
                return;
            }

            var tablename = domainStateNameList[tableIndex];
            var metaDataModelList = new List<TransactionMetaDataModel>();
            for (int i = 0; i < bulkGetVersionCount; i++)
            {
                if (executeQueue.Count == 0)
                {
                    break;
                }
                var metaDataQueueItem = executeQueue.Dequeue();
                metaDataModelList.Add(metaDataQueueItem.metaDataModel);
            }


            try
            {
                var dataAccess = metaDataDataAccessMap[tablename];


                await dataAccess.SetLastUpdateTimeSuccess(metaDataModelList.Select(c => c.ID).ToList(), DateTime.Now);

                //var publishGrain = GrainFactory.GetGrain<IDataChangePublisher>(tablename);
                //await publishGrain.Publish(new RequestPublishChangeDataParam()
                //{
                //    StateName = tablename,
                //    ChangeDataList = metaDataModelList.Select(c => new ChangeDataDTO()
                //    {
                //        DataID = c.ID,
                //        StateName = tablename
                //    }).ToList(),
                //});
            }
            catch (Exception ex)
            {
                await this.WriteErrorLog(loggerFactory, ex);
            }
        }


        protected virtual async Task RefreshQueueData()
        {
            if (executeQueue.Count > 0 || domainStateNameList.Count == 0)
            {
                return;
            }
            var tableName = domainStateNameList[tableIndex];
            var metaDataAccess = metaDataDataAccessMap[tableName];
            var esSyncDataModeList = await metaDataAccess.GetTopNDataList(50, DateTime.Now.AddMinutes(-1 * delayMinute));
            foreach (var item in esSyncDataModeList)
            {
                executeQueue.Enqueue((tableName, item, metaDataAccess));
            }

        }


        public virtual async Task Start()
        {
            if (isStart)
            {
                return;
            }
            isStart = true;
            var domainStateList = domainAssembly.GetTypes().Where(c => c.IsClass && c.GetCustomAttributes(true).Any(c => c.GetType().Name == typeof(DomainStateAttribute).Name)).ToList();
            domainStateNameList = domainStateList.Select(c => c.Name).ToList();
            await InitDatabase();
            RegisterTimer(OnTime, null, new TimeSpan(), TimeSpan.FromMilliseconds(delayTime));
        }

        private async Task InitDatabase()
        {
            foreach (var stateName in domainStateNameList)
            {
                metaDataDataAccessMap[stateName] = new TransactionMetaDataAccess(dataConnection, $"{stateName}{SysPredefined.MetaTableEndName}");
            }
            await CreateTable(domainStateNameList);
        }

        private async Task CreateTable(List<string> domainStateNameList)
        {
            var tableNameList = await GetTableNameList();
            var notExistTable = domainStateNameList.Except(tableNameList).ToList();
            foreach (var item in notExistTable)
            {
                await metaDataDataAccessMap[item].CreateTable();
                var transactionStateDataAccess = new TransactionStateDataAccess(dataConnection, $"{item}");
                await transactionStateDataAccess.CreateTable();
            }
        }

    }
}
