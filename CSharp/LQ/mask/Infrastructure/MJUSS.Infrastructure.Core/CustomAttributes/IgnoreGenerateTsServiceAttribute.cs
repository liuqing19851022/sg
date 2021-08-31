using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class IgnoreGenerateTsServiceAttribute : Attribute
    {
        public bool Ignore { get; set; } = true;

    }
}
