namespace Photonicat.VO.Cat
{
    public class TxtMessages
    {
        /// <summary>
        /// 消息
        /// </summary>
        public List<TxtMessageItem> messages { get; set; } = new();
    }

    public class TxtMessageItem
    {
        /// <summary>
        /// 来源
        /// </summary>
        public string from { get; set; } = "";

        public long hash_id { get; set; }

        public string id { get; set; } = "";

        public string msg { get; set; } = "";

        public string send_at { get; set; } = "";
        public long send_at_i { get; set; }

        /// <summary>
        /// REC UNREAD
        /// </summary>
        public string status { get; set; } = "";

        /// <summary>
        /// 存储位置
        /// ME
        /// </summary>
        public string storage { get; set; } = "";
    }
}
