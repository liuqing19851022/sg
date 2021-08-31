using MJUSS.Infrastructure.Core.Constants;
using Orleans;
using Orleans.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Interface.SyncToReadDBChecker
{
    [Version(SysPredefined.Version)]
    public interface ISyncToReadDBCheckerTimer : IGrainWithIntegerKey
    {
        /// <summary>
        /// 启动
        /// </summary>
        /// <returns></returns>
        Task Start();
    }
}
