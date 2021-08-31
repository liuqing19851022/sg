using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace MJ.Service.Tool.Interface.Tool
{
    public class IndexDataGrainManager : IIndexDataGrainManager
    {
        private ConcurrentDictionary<string, Func<IGrainFactory, string, Task<IIndexDataGrainBase>>> indexDataGrainMap = new ConcurrentDictionary<string, Func<IGrainFactory, string, Task<IIndexDataGrainBase>>>();
        public Task AddGetndexDataGrainFunc(string domainStateName, Func<IGrainFactory, string, Task<IIndexDataGrainBase>> getIndexDataGrain)
        {
            var key = domainStateName.ToLower();
            indexDataGrainMap[key] = getIndexDataGrain;
            return Task.CompletedTask;
        }


        public async Task<IIndexDataGrainBase> GeteIndexDataGrain(IGrainFactory grainFactory, string domainStateName, string id)
        {
            var key = domainStateName.ToLower();
            if (!indexDataGrainMap.ContainsKey(key))
            {
                return null;
            }
            var itemFunc = indexDataGrainMap[key];
            var result = await itemFunc(grainFactory, id);
            return result;
        }

    }

}
