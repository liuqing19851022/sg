using System;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class ExcelHeaderNameAttribute : Attribute
    {
        public ExcelHeaderNameAttribute(string columeHeaderName)
        {
            this.ColumnHeaderName = columeHeaderName;
        }

        /// <summary>
        /// 列表头名称
        /// </summary>
        public string ColumnHeaderName { get; set; }
    }
}
