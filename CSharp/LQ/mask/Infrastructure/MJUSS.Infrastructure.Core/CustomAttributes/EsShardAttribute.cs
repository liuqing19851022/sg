using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
    /// <summary>
    /// es分片数量
    /// </summary>
    public class EsShardAttribute : Attribute
    {
        /// <summary>
        /// 分片数量
        /// </summary>
        public int ShardCount { get; set; }
        public EsShardAttribute(int shardCount = 5)
        {
            ShardCount = shardCount;
        }
    }
}
