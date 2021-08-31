using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    /// <summary>
    /// 权限检查特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class NewPermissionCheckAttribute : Attribute
    {
        /// <summary>
        /// 权限模块
        /// </summary>
        private int PermissionModule { get; }
        /// <summary>
        /// 权限值
        /// </summary>
        private int Permission { get;  }
        

        /// <summary>
        /// 权限key
        /// </summary>
        public string PermissionKey
        {
            get
            {
                return $"{PermissionModule}_{Permission}";
            }
        }

        /// <summary>
        /// 权限key
        /// </summary>
        public long PermissionLongKey
        {
            get; private set;
        }

        public NewPermissionCheckAttribute(long permission)
        {
            this.Permission = (int)(permission & 0xFFFFFFFF);
            this.PermissionModule = (int)(permission >> 32);
            PermissionLongKey = permission;
        }

        //public NewPermissionCheckAttribute(int permissionModule, int permission)
        //{
        //    this.Permission = permission;
        //    this.PermissionModule = permissionModule;
        //    PermissionLongKey = (((long)permissionModule) << 32) | (long)permission;
        //}
    }
}
