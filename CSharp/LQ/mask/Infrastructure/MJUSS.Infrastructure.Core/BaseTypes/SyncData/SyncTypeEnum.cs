using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.BaseTypes.SyncData
{
    public enum SyncTypeEnum
    {
        已结账 = 1,
        反结账 = 2,
        销账 = 3,
        清除数据 = 4,
        会员充值 = 5,
        会员取消充值 = 6,
        子账单销账 = 7,
        入库 = 8,
        出库 = 9,
        会员充值次数 = 11,
        会员取消充值次数 = 12,
        抵扣次数 = 13,
        取消抵扣次数 = 14,
        预定 = 15,
        预定开单 = 16,
        取消预定 = 17,
        变更预定员工 = 18,
        预定转台 = 19,
        商品变更 = 20,
        门店变更 = 21,
        //会员充值时长数 = 22,
        //会员取消充值时长数 = 23,
        //抵扣时长数 = 24,
        //取消抵扣时长数 = 25,
    }
}
