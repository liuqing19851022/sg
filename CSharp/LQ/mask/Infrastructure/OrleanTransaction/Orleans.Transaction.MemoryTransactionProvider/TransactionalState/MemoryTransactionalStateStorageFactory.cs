using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Orleans.Configuration;
using Orleans.Runtime;
using Orleans.Transactions;
using Orleans.Transactions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orleans.Transaction.MemoryTransactionProvider.TransactionalState
{
    public class MemoryTransactionalStateStorageFactory : ITransactionalStateStorageFactory
    {
        private JsonSerializerSettings jsonSettings;
        private ILoggerFactory loggerFactory;
        private IGrainFactory grainFactory;

        public MemoryTransactionalStateStorageFactory(ITypeResolver typeResolver, IGrainFactory grainFactory, ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            this.grainFactory = grainFactory;
            jsonSettings = TransactionalStateFactory.GetJsonSerializerSettings(
                typeResolver,
                grainFactory);
        }
        public ITransactionalStateStorage<TState> Create<TState>(string stateName, IGrainActivationContext context) where TState : class, new()
        {
            string key = MakeKey(context, stateName);
            return ActivatorUtilities.CreateInstance<MemoryTransactionalStateStorage<TState>>(context.ActivationServices,
                stateName,
                key,
                jsonSettings,
                loggerFactory.CreateLogger<MemoryTransactionalStateStorage<TState>>(),
                grainFactory
            );
        }

        private string MakeKey(IGrainActivationContext context, string stateName)
        {
            return context.GrainIdentity.PrimaryKeyString ?? context.GrainIdentity.PrimaryKeyLong.ToString();
        }
    }
}
