using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MJ.Service.Tool.Interface.Tool;
using MJUSS.Infrastructure.Utils.Extentions;
using Orleans;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MJ.DomainService.Mask.Implement.Extention
{
    public static class MaskExtention
    {
        public static void UseMaskModule(this IServiceCollection services, IConfiguration config, List<Assembly> assemblyList, List<Func<IServiceProvider, CancellationToken, Task>> startActionList)
        {
            assemblyList.Add(typeof(MaskExtention).Assembly);
            assemblyList.Add(typeof(MJ.Domain.Mask.Implement.ForT4).Assembly);


            startActionList.Add((sp, token) => {

				//TODO:添加启动时自动运行的服务
                
				return Task.CompletedTask;
            });

            
        }
    }
}
