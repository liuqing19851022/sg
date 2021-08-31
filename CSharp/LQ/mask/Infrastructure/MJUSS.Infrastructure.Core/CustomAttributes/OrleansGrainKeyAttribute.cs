
namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    using System;
    /// <summary>
    /// Grain主键特性，适用于Request的字段上
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class OrleansGrainKeyAttribute: Attribute
    {
         
    }
}