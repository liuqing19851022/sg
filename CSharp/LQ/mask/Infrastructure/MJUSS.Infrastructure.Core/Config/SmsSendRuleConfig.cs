using MJUSS.Infrastructure.Core.CustomAttributes;
using Orleans.Concurrency;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MJUSS.Infrastructure.Core.Config
{
    [Flags]
    public enum SmsSendGroupEnum1
    {
        寄存商品 = 1,

        领取商品 = 1 << 1,

        [SmsSendRuleHasRule]
        寄存过期 = 1 << 2,

        小程序自助预订续费提醒 = 1 << 3,

        挂单 = 1 << 4,

        商家取消自助预订订单提醒 = 1 << 5,

        手动赠送代金券 = 1 << 6,

        小程序自助预订提醒开始消费 = 1 << 7,
    }

    [Serializable]
    [DataContract]
    [Immutable]
    public class SmsSendRuleConfig
    {
        /// <summary>
        /// 第一组开关,每组可用保存63种类型
        /// 默认全选
        /// </summary>
        [DataMember]
        public long SendGroup1 { get; set; } = -1;

        [DataMember]
        public string DepositExpDayBefore { get; set; } = "3";

        public bool EnableSendGroup1(SmsSendGroupEnum1 enums)
        {
            var val = (long)enums;
            return (val & SendGroup1) == val;
        }

    }
}
