using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Orlelans
{
    public interface IOrleansClusterClientFactoryBase
    {
        IClusterClient GetClusterClient();
        Task<bool> InitConfig(int MaxRertyTime=3);
    }
}
