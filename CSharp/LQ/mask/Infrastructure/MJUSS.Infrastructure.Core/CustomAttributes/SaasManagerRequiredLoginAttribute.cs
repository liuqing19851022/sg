using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    /// <summary>
    /// 后台特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SaasManagerRequiredLoginAttribute : Attribute
    {
    }    
}
