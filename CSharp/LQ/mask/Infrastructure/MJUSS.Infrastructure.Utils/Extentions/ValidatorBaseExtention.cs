using MJUSS.Infrastructure.Core.BaseClass;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class ValidatorBaseExtention
    {
        public static void Validate(this ITransferData data)
        {
            ValidateObject(data);
        }
        public static void Validate(this IEnumerable listData)
        {
            foreach (var item in listData)
            {
                ValidateObject(item);
            }
        }

      

        public static void Validate<T>(this RequestData<T> data)
        {
            ValidateObject(data.Data);
        }

        public static void ValidateObject(this object instance)
        {
            var context = new ValidationContext(instance, null, null);
            Validator.ValidateObject(instance, context, true);
        }
    }
}
