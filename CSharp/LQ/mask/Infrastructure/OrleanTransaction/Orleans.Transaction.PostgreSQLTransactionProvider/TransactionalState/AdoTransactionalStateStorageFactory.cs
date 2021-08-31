using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Orleans.Configuration;
using Orleans.Runtime;
using Orleans.Transaction.PostgreSQLTransactionProvider.Config;
using Orleans.Transactions;
using Orleans.Transactions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orleans.Transaction.PostgreSQLTransactionProvider.TransactionalState
{
    public class AdoTransactionalStateStorageFactory : ITransactionalStateStorageFactory
    {
        private AdoTransactionProviderConfig adoTransactionProviderConfig;
        private  JsonSerializerSettings jsonSettings;
        private  ILoggerFactory loggerFactory;
        private IGrainFactory grainFactory;
        private ClusterOptions clusterOptions;

        public AdoTransactionalStateStorageFactory(AdoTransactionProviderConfig adoTransactionProviderConfig, ITypeResolver typeResolver, IGrainFactory grainFactory, ILoggerFactory loggerFactory, IOptions<ClusterOptions> clusterOptions)
        {
            this.adoTransactionProviderConfig = adoTransactionProviderConfig;
            this.loggerFactory = loggerFactory;
            this.grainFactory = grainFactory;
            this.clusterOptions = clusterOptions.Value;
            this.jsonSettings = TransactionalStateFactory.GetJsonSerializerSettings(
                typeResolver,
                grainFactory);
        }
        public ITransactionalStateStorage<TState> Create<TState>(string stateName, IGrainActivationContext context) where TState : class, new()
        {
            string key = MakeKey(context, stateName);
            return ActivatorUtilities.CreateInstance<AdoTransactionalStateStorage<TState>>(context.ActivationServices,
                stateName,
                key,
                adoTransactionProviderConfig.ConnectionString,
                this.jsonSettings,
                this.loggerFactory.CreateLogger<AdoTransactionalStateStorage<TState>>(),
                grainFactory
            );
        }

        private string MakeKey(IGrainActivationContext context, string stateName)
        {
            return context.GrainIdentity.PrimaryKeyString ?? context.GrainIdentity.PrimaryKeyLong.ToString();
            //string grainKey = context.GrainInstance.GrainReference.ToShortKeyString();
            //var key = $"{grainKey}_{this.clusterOptions.ServiceId}_{stateName}";
            //key = key
            //   .Replace('/', '_')        // Forward slash
            //   .Replace('\\', '_')       // Backslash
            //   .Replace('#', '_')        // Pound sign
            //   .Replace('?', '_');       // Question mark
            //if (key.Length >= 1024)
            //{
            //    throw new ArgumentException(string.Format("Key length {0} is too long to be an Azure table key. Key={1}", key.Length, key));
            //}
            //return key;
        }
    }
}
