namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    using System;

    /// <summary>
    /// 必须选择门店
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class RequiredSelectStoreAttribute : Attribute
    {
        
    }
}