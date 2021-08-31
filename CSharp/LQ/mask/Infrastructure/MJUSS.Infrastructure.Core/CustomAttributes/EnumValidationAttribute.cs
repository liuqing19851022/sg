using System;
using System.ComponentModel.DataAnnotations;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false,Inherited = false)]
    public class EnumValidationAttribute: ValidationAttribute
    {
        public Type EnumType { get; set; }

        public override bool IsValid(object value)
        {
            return Enum.IsDefined(EnumType, value);
        }
    }

}
