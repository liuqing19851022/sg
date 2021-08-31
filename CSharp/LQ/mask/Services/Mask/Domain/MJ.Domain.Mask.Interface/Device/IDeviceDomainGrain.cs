using MJ.Domain.Mask.Interface.Device.State;
using MJ.Service.Tool.Interface.Domain;
using MJUSS.Infrastructure.Core.Constants;
using Orleans;
using Orleans.CodeGeneration;
using System;

namespace MJ.Domain.Mask.Interface.Device
{
    [Version(SysPredefined.Version)]
    public interface IDeviceDomainGrain : IMJDomainGrain<DeviceState>, IGrainWithIntegerKey
    {

    }
}
