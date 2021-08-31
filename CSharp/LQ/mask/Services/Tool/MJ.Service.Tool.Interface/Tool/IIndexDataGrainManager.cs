using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Interface.Tool
{
    /// <summary>
    /// 索引Grain管理工具
    /// </summary>
    public interface IIndexDataGrainManager
    {
        /// <summary>
        /// 新增模型数据Grain
        /// </summary>
        /// <param name="domainStateName"></param>
        /// <param name="getIndexDataGrain"></param>
        /// <returns></returns>
        Task AddGetndexDataGrainFunc(string domainStateName, Func<IGrainFactory, string, Task<IIndexDataGrainBase>> getIndexDataGrain);
        /// <summary>
        /// 获取模型数据Grain
        /// </summary>
        /// <param name="domainStateName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IIndexDataGrainBase> GeteIndexDataGrain(IGrainFactory grainFactory, string domainStateName, string id);
    }
}
