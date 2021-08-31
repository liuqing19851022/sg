namespace MJUSS.Infrastructure.Core.BaseTypes
{
    /// <summary>
    /// 付款方式
    /// </summary>
    public enum PayTypeEnum
    {
        现金 = 1,
        Pos刷卡 = 2,
        支付宝转账 = 3,
        微信支付转账 = 4,
        //预存款 = 5,
        团购 = 7,
        其他 = 8,
        /// <summary>
        /// 当面付
        /// </summary>
        在线支付 = 11,
        会员积分抵现 = 12,

        //自定义类型
        自定义1 = 101,
        自定义2 = 102,
        自定义3 = 103,
        自定义4 = 104,
        自定义5 = 105,
    }
}
