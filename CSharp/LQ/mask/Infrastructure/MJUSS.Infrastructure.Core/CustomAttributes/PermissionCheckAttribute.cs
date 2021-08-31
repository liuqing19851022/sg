using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    /// <summary>
    /// 权限检查特效
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionCheckAttribute : Attribute
    {
        public long Permission { get; set; }


        public PermissionCheckAttribute(long permission)
        {
            this.Permission = permission;
        }
    }
}
