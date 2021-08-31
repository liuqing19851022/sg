using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MJ.Domain.Mask.Shared.Constants;
using MJ.DomainService.Mask.Implement.Extention;
using MJ.QueryService.Mask.Implement.Services.Extention;
using MJ.Service.Tool.Implement.Tool.Extention;
using Orleans;
using Orleans.Hosting;
using Orleans.TestingHost;
using Orleans.Transaction.MemoryTransactionProvider;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MJ.Mask.Implement.Test
{
    public class ClusterFixture : IDisposable
    {
        public ClusterFixture()
        {
            var builder = new TestClusterBuilder();
            builder.AddSiloBuilderConfigurator<TestSiloConfigurations>();
            this.Cluster = builder.Build();
            this.Cluster.Deploy();
        }

        public void Dispose()
        {
            this.Cluster.StopAllSilos();
        }

        public TestCluster Cluster { get; private set; }
    }


   
    public class TestSiloConfigurations : IHostConfigurator
    {
        
        public void Configure(IHostBuilder hostBuilder)
        {
            List<Assembly> assemblyList = new List<Assembly>();
            List<Func<IServiceProvider, CancellationToken, Task>> startActionList = new List<Func<IServiceProvider, CancellationToken, Task>>();
            hostBuilder.ConfigureServices((hostContext, services) =>
            {
                services.UseToolModule(hostContext.Configuration, assemblyList, startActionList);
                services.UseMaskModule(hostContext.Configuration, assemblyList, startActionList);
                services.UseMaskQueryModule(hostContext.Configuration, assemblyList, startActionList);


            }).UseOrleans((context, siloBuilder) =>
            {

                siloBuilder.AddMemoryGrainStorageAsDefault()
                            .AddMemoryGrainStorage("MemoryStore")
                            .UseInMemoryReminderService()
                            .UseMemoryTransactionalStateStorage(MaskTransactionalStorageNameConstants.Mask)
                            .UseTransactions();
                siloBuilder.ConfigureApplicationParts(c =>
                {
                    foreach (var item in assemblyList)
                    {
                        c.AddApplicationPart(item);
                    }
                    
                });
                siloBuilder.AddStartupTask(async (services, c) =>
                {
                    foreach (var actionItem in startActionList)
                    {
                        await actionItem(services, c);
                    }
                });
            });
            
        }
    }

    [CollectionDefinition(ClusterCollection.Name)]
    public class ClusterCollection : ICollectionFixture<ClusterFixture>
    {
        public const string Name = "ClusterCollection";
    }
}
