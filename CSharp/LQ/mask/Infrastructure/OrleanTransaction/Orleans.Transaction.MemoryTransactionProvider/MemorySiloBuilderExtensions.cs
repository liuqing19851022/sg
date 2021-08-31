using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Orleans;
using Orleans.Hosting;
using Orleans.Providers;
using Orleans.Runtime;
using Orleans.Transaction.MemoryTransactionProvider.TransactionalState;
using Orleans.Transactions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orleans.Transaction.MemoryTransactionProvider
{
    public static class MemorySiloBuilderExtensions
    {
        public static ISiloBuilder UseMemoryTransactionalStateStorage(this ISiloBuilder builder, string name)
        {
            return builder.ConfigureServices(service => service.UseMemoryTransactionalStateStorage(name));
        }

        public static ISiloBuilder UseMemoryTransactionalStateStorage(this ISiloBuilder builder)
        {
            return builder.ConfigureServices(service => service.UseMemoryTransactionalStateStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME));
        }


        public static IServiceCollection UseMemoryTransactionalStateStorage(this IServiceCollection services, string name)
        {
            services.TryAddSingleton(sp => sp.GetServiceByName<ITransactionalStateStorageFactory>(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME));
            services.AddSingletonNamedService(name, Create);
            return services;
        }

        public static ITransactionalStateStorageFactory Create(IServiceProvider services, string name)
        {
            return ActivatorUtilities.CreateInstance<MemoryTransactionalStateStorageFactory>(services);
        }


    }
}
