using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    /// <summary>
    /// 检查是否是生成的SessionID
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckIsGenSessionIDAttribute : Attribute
    {
    }
}
