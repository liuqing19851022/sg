using System;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    /// <summary>
    /// Excel单元格是否为数字
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ExcelCellIsNumbericTypeAttribute: Attribute
    {
    }
}
