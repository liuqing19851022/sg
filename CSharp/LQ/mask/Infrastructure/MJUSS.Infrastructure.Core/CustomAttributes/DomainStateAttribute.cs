using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    /// <summary>
    /// 领域模型状态特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DomainStateAttribute : Attribute
    {
    }
}
