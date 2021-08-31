using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MJ.Service.Tool.Interface.Tool;
using MJUSS.Infrastructure.Core.Config;
using MJUSS.Infrastructure.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Implement.Tool.Extention
{
    public static class ToolServiceExtention
    {

        public static void UseToolModule(this IServiceCollection services, IConfiguration config, List<Assembly> assemblyList, List<Func<IServiceProvider, CancellationToken, Task>> startActionList)
        {
            assemblyList.Add(typeof(ToolServiceExtention).Assembly);
            services.AddSingleton<IIndexDataGrainManager, IndexDataGrainManager>();
            services.AddSingleton<IEsClientFactory, EsClientFactory>();
            services.Configure<ESConnectionsConfig>(config.GetSection(nameof(ESConnectionsConfig)));

        }
    }
}
