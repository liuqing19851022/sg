//using MJUSS.Infrastructure.Core.BaseTypes.Wms;

//namespace MJUSS.Infrastructure.Utils.Helper
//{
//    public static class WmsInOutStockSysCodeTool
//    {
//        /// <summary>
//        /// 获取入库的SysCode
//        /// </summary>
//        /// <param name="consumeBillID"></param>
//        /// <param name="customerPointsUseLogID"></param>
//        /// <returns></returns>
//        public static string GenerateInStockSysCode(long consumeBillID, long customerPointsUseLogID)
//        {
//            var sysCode = string.Empty;
//            if (consumeBillID > 0)
//            {
//                sysCode = consumeBillID.ToString();
//            }
//            else if (customerPointsUseLogID > 0)
//            {
//                sysCode = $"/{(int)WmsInStockTypeEnum.取消积分兑换入库}/{customerPointsUseLogID.ToString()}";
//            }
//            return sysCode;
//        }
//        /// <summary>
//        /// 解析入库的SysCode
//        /// </summary>
//        /// <param name="sysCode"></param>
//        /// <returns></returns>
//        public static (int InStockType, string SysCode) ResolveInStockSysCode(string sysCode)
//        {
//            var inStockType = (int)WmsInStockTypeEnum.取消消费入库;
//            var result = sysCode;
//            var prefix = $"/{(int)WmsInStockTypeEnum.取消积分兑换入库}/";
//            if (sysCode.Contains(prefix))
//            {
//                inStockType = (int)WmsInStockTypeEnum.取消积分兑换入库;
//                result = sysCode.Replace(prefix, "");
//            }
//            else
//            {
//                inStockType = (int)WmsInStockTypeEnum.取消消费入库;
//                result = sysCode;
//            }
//            return (inStockType, result);
//        }

//        /// <summary>
//        /// 获取出库的SysCode
//        /// </summary>
//        /// <param name="consumeBillID"></param>
//        /// <param name="customerPointsUseLogID"></param>
//        /// <returns></returns>
//        public static string GenerateOutStockSysCode(long consumeBillID, long customerPointsUseLogID)
//        {
//            var sysCode = string.Empty;
//            if (consumeBillID > 0)
//            {
//                sysCode = consumeBillID.ToString();
//            }
//            else if (customerPointsUseLogID > 0)
//            {
//                sysCode = $"/{(int)WmsOutStockTypeEnum.积分兑换出库}/{customerPointsUseLogID.ToString()}";
//            }
//            return sysCode;
//        }
//        /// <summary>
//        /// 解析出库的SysCode
//        /// </summary>
//        /// <param name="sysCode"></param>
//        /// <returns></returns>
//        public static (int OutStockType, string SysCode) ResolveOutStockSysCode(string sysCode)
//        {
//            var outStockType = (int)WmsOutStockTypeEnum.销售出库;
//            var result = sysCode;
//            var prefix = $"/{(int)WmsOutStockTypeEnum.积分兑换出库}/";
//            if (sysCode.Contains(prefix))
//            {
//                outStockType = (int)WmsOutStockTypeEnum.积分兑换出库;
//                result = sysCode.Replace(prefix, "");
//            }
//            else
//            {
//                outStockType = (int)WmsOutStockTypeEnum.销售出库;
//                result = sysCode;
//            }
//            return (outStockType, result);
//        }
//    }
//}
