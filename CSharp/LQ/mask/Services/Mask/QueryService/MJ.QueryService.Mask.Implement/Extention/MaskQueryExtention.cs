using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MJ.Service.Tool.Interface.Tool;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MJ.QueryService.Mask.Implement.Services.Extention
{
    public static class MaskQueryExtention
    {
        public static void UseMaskQueryModule(this IServiceCollection services, IConfiguration config, List<Assembly> assemblyList, List<Func<IServiceProvider, CancellationToken, Task>> startActionList)
        {
            assemblyList.Add(typeof(MaskQueryExtention).Assembly);


            startActionList.Add((sp, token) => {

                var indexDataGrainManager = sp.GetService<IIndexDataGrainManager>();
				//TODO:代码生成后解注释
                //dexDataGrainManager.AddMaskIndexService();
                return Task.CompletedTask;
            });



        }
    }
}
