using System.Runtime.Serialization;

namespace PushPgToES.DTO
{
    [DataContract]
    public class BulkCommitDataItem
    {
        [DataMember(Name = "index")]
        public BulkCommitDataIndexItem Index { get; set; } = new();



    }

    public class BulkCommitDataIndexItem
    {
        [DataMember(Name = "_id")]
        public string ID { get; set; } = string.Empty;

        [DataMember(Name = "_index")]
        public string Alias { get; set; } = string.Empty;
    }
}
