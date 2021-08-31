namespace MJUSS.Infrastructure.Core.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;


    public class ListData<T> {
        [DataMember]
        public List<T> Datas { get; set; }
    }


    /// <summary>
    ///     分页数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    [DataContract]
    public class PageData<T> : ListData<T>
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        public PageData()
        {
            this.Datas = new List<T>();
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="datas"></param>
        public PageData(List<T> datas)
        {
            this.Datas = datas;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="dataCount"></param>
        public PageData(List<T> datas, long dataCount)
        {
            this.Datas = datas;
            this.DataCount = dataCount;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="dataCount"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        public PageData(List<T> datas, long dataCount, int pageSize, int pageIndex)
        {
            this.Datas = datas;
            this.DataCount = dataCount;
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
        }


        /// <summary>
        ///     总数据量
        /// </summary>
        [DataMember]
        public long DataCount { get; set; }

        /// <summary>
        ///     分页大小
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }

        /// <summary>
        ///     当前页
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }

        /// <summary>
        ///     总页数
        /// </summary>
        [DataMember]
        public long Pages
        {
            get
            {
                if (this.PageSize <= 0)
                {
                    throw new Exception("PageSize必须大于0");
                }
                return this.DataCount % this.PageSize > 0
                           ? this.DataCount / this.PageSize + 1
                           : this.DataCount / this.PageSize;
            }
        }
    }


    [Serializable]
    [DataContract]
    public class BaseRequestPageData {
        /// <summary>
        /// 页面索引
        /// </summary>
        [DataMember]
        [Range(1, int.MaxValue, ErrorMessage = "页码必须大于0。")]
        public int PageIndex { get; set; }
        /// <summary>
        /// 页面记录数
        /// </summary>
        [DataMember]
        [Range(1, int.MaxValue, ErrorMessage = "页显示记录数必须大于0。")]
        public int PageSize { get; set; }
    }
}