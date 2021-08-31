using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.Common
{
    public interface IDataPublish
    {
        Task Publish(long dataID, long version);
        Task PublishBulk(long dataID, long version, Guid bulkID);

    }
}
