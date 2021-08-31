using MJ.Domain.Mask.Shared;
using MJUSS.Infrastructure.Core.CustomAttributes;
using Nest;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MJ.Domain.Mask.Interface.Device.State
{
    [Serializable]
    [DataContract]
    [DomainState]
    public class DeviceState
    {
        [DataMember]
        [Keyword(Index = true, Store = true)]
        public long ID { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        [DataMember]
        [Keyword(Index = true, Store = true)]
        public string SN { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        [DataMember]
        [Keyword(Index = true, Store = true)]
        public string Name { get; set; }

        /// <summary>
        /// 设备类型
        /// <see cref="DeviceTypeEnum"/>
        /// </summary>
        [DataMember]
        [EnumDataType(typeof(DeviceTypeEnum))]
        [Keyword(Index = true, Store = true)]
        public int DeviceType { get; set; }

        /// <summary>
        /// 品牌
        /// <see cref="BrandEnum"/>
        /// </summary>

        [DataMember]
        [EnumDataType(typeof(BrandEnum))]
        [Keyword(Index = true, Store = true)]
        public int Brand { get; set; }

        

        /// <summary>
        /// 补货人员
        /// </summary>
        [DataMember]
        [Keyword(Index = true, Store = true)]
        public long AddStockPerson { get; set; }

        /// <summary>
        /// 预警库存
        /// </summary>
        [DataMember]
        [Range(1,10000)]
        [Keyword(Index = true, Store = true)]
        public int StockWarning { get; set; }

        /// <summary>
        /// 维修员
        /// </summary>
        [DataMember]
        [Keyword(Index = true, Store = true)]
        public long MaintainPerson { get; set; }

        /// <summary>
        /// 累计销售额
        /// 可聚合
        /// </summary>
        [DataMember]
        public decimal SellTotal { get; set; }


        /// <summary>
        /// 最后心跳时间
        /// </summary>
        [DataMember]
        public DateTime LastHeartBeat { get; set; }

        [DataMember]
        public DateTime CreateTime { get; set; }

        [DataMember]
        public DateTime LastUpdate { get; set; }

    }
}
