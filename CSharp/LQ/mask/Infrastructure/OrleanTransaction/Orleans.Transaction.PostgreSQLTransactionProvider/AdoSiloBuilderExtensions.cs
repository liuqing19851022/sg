using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Orleans.Hosting;
using Orleans.Providers;
using Orleans.Runtime;
using Orleans.Transaction.PostgreSQLTransactionProvider.Config;
using Orleans.Transaction.PostgreSQLTransactionProvider.TransactionalState;
using Orleans.Transactions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orleans.Transaction.PostgreSQLTransactionProvider
{
    public static class AdoTransactionSiloBuilderExtensions
    {
        public static ISiloBuilder UseTransactionalStateStorage(this ISiloBuilder builder, string name, Action<AdoTransactionProviderConfig> configureOptions)
        {
            return builder.ConfigureServices(service => service.UseTransactionalStateStorage(name, c=>c.Configure(configureOptions)));
        }

        public static ISiloBuilder UseTransactionalStateStorage(this ISiloBuilder builder, Action<AdoTransactionProviderConfig> configureOptions)
        {
            return builder.ConfigureServices(service => service.UseTransactionalStateStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, c => c.Configure(configureOptions)));
        }


        public static IServiceCollection UseTransactionalStateStorage(this IServiceCollection services, string name, Action<OptionsBuilder<AdoTransactionProviderConfig>> configureOptions = null)
        {
            configureOptions(services.AddOptions<AdoTransactionProviderConfig>(name));
            services.TryAddSingleton<ITransactionalStateStorageFactory>(sp => sp.GetServiceByName<ITransactionalStateStorageFactory>(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME));
            services.AddSingletonNamedService<ITransactionalStateStorageFactory>(name, Create);
            return services;
        }

        public static ITransactionalStateStorageFactory Create(IServiceProvider services, string name)
        {
            var options = services.GetRequiredService<IOptionsMonitor<AdoTransactionProviderConfig>>();
            return ActivatorUtilities.CreateInstance<AdoTransactionalStateStorageFactory>(services, options.Get(name));
        }

    }
}
