using MJ.Service.Tool.Interface.DataChange.Param;
using MJUSS.Infrastructure.Core.Constants;
using Orleans;
using Orleans.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Interface.DataChange
{
    [Version(SysPredefined.Version)]
    public interface IDataChangePublisher : IGrainWithStringKey
    {
        Task Publish(RequestPublishChangeDataParam request);
    }
}
