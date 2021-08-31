
namespace MJUSS.Infrastructure.Core.Error
{
    public static class MJErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        public static ErrorCodeItem Success = new ErrorCodeItem(0, "成功");
        /// <summary>
        /// 系统异常
        /// </summary>
        public static ErrorCodeItem Exception = new ErrorCodeItem(1, "系统发生异常,请关闭后重试。");
        /// <summary>
        /// 参数为空
        /// </summary>
        public static ErrorCodeItem ArgumentNullException = new ErrorCodeItem(2, "参数不能为空");
        /// <summary>
        /// 参数对象验证异常
        /// </summary>
        public static ErrorCodeItem ParameterValidationException = new ErrorCodeItem(3, "参数验证失败");
        /// <summary>
        /// 视图对象验证异常
        /// </summary>
        public static ErrorCodeItem ViewModelValidationException = new ErrorCodeItem(4, "视图数据验证失败");
        /// <summary>
        /// 需要登录错误
        /// </summary>
		public static ErrorCodeItem LoginRequired = new ErrorCodeItem(5, "您未登录或已登录超时,请重新登录");
        /// <summary>
        /// 不可识别的命令参数
        /// </summary>
        public static ErrorCodeItem UnrecognizedCommandException = new ErrorCodeItem(6, "不可识别的命令参数");
        /// <summary>
        /// 验证错误
        /// </summary>
        public static ErrorCodeItem ValidationError = new ErrorCodeItem(7, "验证错误");

        /// <summary>
        /// 数据格式错误
        /// </summary>
        public static ErrorCodeItem DataFormatError = new ErrorCodeItem(8, "数据格式错误");
        /// <summary>
        /// 流程消息已处理
        /// </summary>
        public static ErrorCodeItem ProcessMessageHasHandle = new ErrorCodeItem(9, "流程消息已处理");
        /// <summary>
        /// 账号已存在 
        /// </summary>
        public static ErrorCodeItem AccountExistError = new ErrorCodeItem(10, "该账号已被注册，请更换帐号名");
        /// <summary>
        ///手机号码已经存在 
        /// </summary>
        public static ErrorCodeItem MobileExistError = new ErrorCodeItem(11, "手机号码已经存在");
        /// <summary>
        /// 不存在指定的ID的数据
        /// </summary>
        public static ErrorCodeItem NotExistTheIdDataModel = new ErrorCodeItem(12, "不存在指定的数据,请关闭后重试。");
        /// <summary>
        /// 图形验证码错误
        /// </summary>
        public static ErrorCodeItem LoginVerifyCodeError = new ErrorCodeItem(13, "登录图形验证码错误");
        /// <summary>
        ///请选择门店 
        /// </summary>
        public static ErrorCodeItem RequiredSelectStoreError = new ErrorCodeItem(14, "请选择门店。");
        /// <summary>
        /// 没有相应的操作权限
        /// </summary>
        public static ErrorCodeItem NoActionPermission = new ErrorCodeItem(15, "没有相应的操作权限！");
        /// <summary>
        /// 短信发送失败
        /// </summary>
        public static ErrorCodeItem SmsSendError = new ErrorCodeItem(16, "短信发送失败");
        /// <summary>
        /// 没找到门店
        /// </summary>
        public static ErrorCodeItem NotFindStoreError = new ErrorCodeItem(17, "没有找到该门店信息");
        /// <summary>
        /// 员工过期
        /// </summary>
        public static ErrorCodeItem StaffAccountExpiredError = new ErrorCodeItem(18, "该帐号已过期，续费请联系客服!");
        /// <summary>
        /// 没有购买产品
        /// </summary>
        public static ErrorCodeItem NotAuthProductError = new ErrorCodeItem(19, "没有购买该功能模块，购买请联系客服!");
        /// <summary>
        /// 购买产品已过期
        /// </summary>
        public static ErrorCodeItem ServiceProductExpiredError = new ErrorCodeItem(20, "该功能模块已过期，续费请联系客服!");
        /// <summary>
        /// 未达到短信重发时间
        /// </summary>
        public static ErrorCodeItem NotArriveSmsSendPeriodSecondsError = new ErrorCodeItem(21, "60秒内不能重复发送短信");

        /// <summary>
        /// 绿米服务端异常 【占位】
        /// </summary>
        public static ErrorCodeItem LvMiServerError = new ErrorCodeItem(22, "");

        /// <summary>
        /// 绿米账号未绑定
        /// </summary>
        public static ErrorCodeItem LvMiAccountNotBindError = new ErrorCodeItem(23, "尚未绑定绿米账号");
        /// <summary>
        /// 房间分类不存在
        /// </summary>
        public static ErrorCodeItem RoomNotExitsError = new ErrorCodeItem(24, "房间分类不存在");
        /// <summary>
        /// 注册图形验证码错误
        /// </summary>
        public static ErrorCodeItem RegisterImageVerifyCodeError = new ErrorCodeItem(25, "登录图形验证码错误");
        /// <summary>
        /// 未关注公共号
        /// </summary>
        public static ErrorCodeItem NotSubscriptWeixinError = new ErrorCodeItem(26, "未关注公共号");

        /// <summary>
        /// 查询数据过多
        /// </summary>
        public static ErrorCodeItem EsQueryTooLargeError = new ErrorCodeItem(30, "查询数据过多");

        /// <summary>
        /// 需要图形验证码
        /// </summary>
        public static ErrorCodeItem NeedRegisterImageVerifyCodeError = new ErrorCodeItem(101, "请输入图形验证码");

        /// <summary>
        /// 查询日期超出限制范围
        /// </summary>
        public static ErrorCodeItem QueryDateOutOfRangeError = new ErrorCodeItem(201, "查询时间区间不能超过90天，请重新选择日期。");

        /// <summary>
        /// 库存盘点盘亏出库失败
        /// </summary>
        public static ErrorCodeItem WmsInventoryOutStockFailedError = new ErrorCodeItem(205, "部分商品因库存变动导致盘亏出库失败，请查看盘点明细");

        /// <summary>
        /// Orleans异常
        /// </summary>
        public static ErrorCodeItem OrleansExceptionError = new ErrorCodeItem(990, "Orleans发生错误");
        /// <summary>
        /// 请求参数异常
        /// </summary>
        public static ErrorCodeItem HttpRequestParameterErrorException = new ErrorCodeItem(991, "请求参数异常，请重试");
        /// <summary>
        /// 重复执行
        /// </summary>
        public static ErrorCodeItem DuplicateExcuteError = new ErrorCodeItem(992, "请勿重复执行");
        /// <summary>
        /// 版本过期异常
        /// </summary>
        public static ErrorCodeItem VersionExpiredError = new ErrorCodeItem(999, "当前版本已过期");

        /// <summary>
        /// ios版本升级
        /// </summary>
        public static ErrorCodeItem IosVersionUpdateError = new ErrorCodeItem(301, "ios版本升级");

        public static ErrorCodeItem ActiveProductConflict = new ErrorCodeItem(302, "活动商品有冲突");
        /// <summary>
        /// 自助预订黑名单账号
        /// </summary>
        public static ErrorCodeItem UnmannedStoreBlackListAccount = new ErrorCodeItem(310, "当前账号已被加入黑名单");
        /// <summary>
        /// 未购买套餐商品
        /// </summary>
        public static ErrorCodeItem NotPurchasedPackageProductError = new ErrorCodeItem(331, "未找到已购买套餐信息");
        /// <summary>
        /// 购买套餐支付请求错误
        /// </summary>
        public static ErrorCodeItem PayPackageOrderError = new ErrorCodeItem(333, "购买套餐订单支付请求错误");

    }
}
