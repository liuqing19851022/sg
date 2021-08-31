using MJUSS.Infrastructure.Core.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class RequestDataBaseExtention
    {
        public static RequestData<T> CreateRequest<T>(this RequestDataBase request) where T : class, new()
        {
            var result = new RequestData<T>
            {
                TenantID = request.TenantID,
                AppID = request.AppID,
                Data = new T()
            };
            return result;
        }
    }
}
