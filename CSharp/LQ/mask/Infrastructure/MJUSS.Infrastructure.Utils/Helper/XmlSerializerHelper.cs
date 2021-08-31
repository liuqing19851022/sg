namespace MJUSS.Infrastructure.Utils.Helper
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class XmlSerializerHelper
    {
        public static string Serialize<T>(T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using var ms = new MemoryStream();
            serializer.Serialize(ms, data);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
