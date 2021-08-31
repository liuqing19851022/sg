using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.BaseTypes.SyncData
{
    public enum ESSyncStateEnum
    {
        未同步 = 1,
        已同步 = 2,
        已删除 = 4,
    }
}
