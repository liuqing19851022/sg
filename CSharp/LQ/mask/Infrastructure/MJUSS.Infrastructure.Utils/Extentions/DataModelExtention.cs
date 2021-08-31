using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class DataModelExtention
    {
        public static T DeepClone<T>(this T t) where T: class{


            using var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, t);
            stream.Position = 0;
            var result = formatter.Deserialize(stream) as T;
            return result;
        }
    }
}
