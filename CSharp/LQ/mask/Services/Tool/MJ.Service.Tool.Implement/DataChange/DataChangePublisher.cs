using MJ.Service.Tool.Interface.DataChange;
using MJ.Service.Tool.Interface.DataChange.Param;
using MJUSS.Infrastructure.Core.Constants;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Implement.DataChange
{
    public class DataChangePublisher : Grain, IDataChangePublisher
    {

        public async Task Publish(RequestPublishChangeDataParam request)
        {
            //var streamNameSpace = await GetStreamNameSpace(request.StateName);

            //var streamID = Guid.NewGuid();
            //var streamProvider = GetStreamProvider(OrleansStreamProviderConstant.RabbitMqMessageProvider);
            //var stream =
            //    streamProvider.GetStream<RequestPublishChangeDataParam>(
            //         streamID,
            //        streamNameSpace);
            //await stream.OnNextAsync(request);
        }

        //protected virtual Task<string> GetStreamNameSpace(string stateName)
        //{
        //    return Task.FromResult($"{OrleansStreamProviderStreamNameSpace.DataChangeStreamNameSpace}{stateName}");
        //}
    }
}
