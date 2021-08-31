#region C#文件说明

// /**********************************************************************************	
// 	* 类   名 ：TableNames.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJUSS.Infrastructure.Core
// 	* 文 件 名：TableNames.cs
// 	* 创建时间：2016-05-04 19:00
// 	* 作    者： MJKJ.用户名：>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/

#endregion

namespace MJUSS.Infrastructure.Core.Constants
{
    public static class TableNames
    {
        #region SMS

        public const string SMSSendData = "SMS.SMSSendData";
        public const int SMSSendDataTableType = 107;

        #endregion SMS

        #region Message

        public const string Messages = "Message.Messages";
        public const int MessagesTableType = 108;

        public const string SmsCode = "Message.SmsCode";
        public const int SmsCodeTableType = 109;

        public const string SmsMessage = "Message.SmsMessage";
        public const int SmsMessageTableType = 110;

        public const string MessagesCall = "Message.MessagesCall";
        public const int MessagesCallTableType = 111;

        /// <summary>
        /// 定时提醒信息
        /// </summary>
        public const string GlobalReminderInfo ="Message. GlobalReminderInfo";
        public const int GlobalReminderInfoTableType = 11222;
        #endregion Message

        #region Base

        public const string BaseApplications = "Base.Applications";
        public const int ApplicationsTableType = 112;

        public const string BaseUnit = "Base.Unit";
        public const int BaseUnitTableType = 113;

        public const string BaseRegion = "Base.Region";
        public const int BaseRegionTableType = 114;

        public const string BaseSaleChannel = "Base.SaleChannel";
        public const int BaseSaleChannelTableType = 115;

        #endregion Base

        #region tenent

        public const string Tenants = "Tenant.Tenants";
        public const int TenantsTableType = 116;

        public const string TenantProductService = "Tenant.TenantProductService";
        public const int TenantProductServiceTableType = 117;

        #endregion tenant

        #region DistributedProcesse

        public const string Process = "DistributedProcesse.Process";
        public const int ProcessTableType = 118;

        public const string ProcessInstance = "DistributedProcesse.ProcessInstance";
        public const int ProcessInstanceTableType = 119;

        public const string ProcessMessage = "DistributedProcesse.ProcessMessage";
        public const int ProcessMessageTableType = 120;

        public const string ProcessNodeInstance = "DistributedProcesse.ProcessNodeInstance";
        public const int ProcessNodeInstanceTableType = 121;

        public const string GuoTanDataSync = "DistributedProcesse.GuoTanDataSync";
        public const string WaitSyncOtherPlatformData = "DistributedProcesse.WaitSyncOtherPlatformData";

        #endregion DistributedProcesse

        #region Product

        public const string Product = "Product.Product";
        public const int ProductTableType = 122;

        public const string ProductCategory = "Product.ProductCategory";
        public const int ProductCategoryTableType = 123;

        public const string ProductPrice = "Product.ProductPrice";
        public const int ProductPriceTableType = 124;

        public const string Ingredients = "Product.Ingredients";
        public const int IngredientsTableType = 125;

        public const string ProductAndIngredients = "Product.ProductAndIngredients";
        public const int ProductAndIngredientsTableType = 126;

        public const string ProductImage = "Product.ProductImage";
        public const int ProductImageTableType = 127;

        public const string ProductOrPackageMap = "Product.ProductOrPackageMap";
        public const string ProductImportRecord = "Product.ProductImportRecord";
        public const string IngredientsImportRecord = "Product.IngredientsImportRecord";
        public const string ProductImportDetail = "Product.ProductImportDetail";
        public const string IngredientsImportDetail = "Product.IngredientsImportDetail";

        public const string ProductAndPeiProductMap= "Product.ProductAndPeiProductMap";
        public const string ProductSellOutCategoryAndProductMap = "Product.ProductSellOutCategoryAndProductMap";
        public const string ProductSellOutCategory = "Product.ProductSellOutCategory";
        public const string ProductSellOutCategoryTimeRange = "Product.ProductSellOutCategoryTimeRange";
        public const string WaitProductSellOutTimeRangeTask = "Product.WaitProductSellOutTimeRangeTask";
        public const string SyncProductData = "Product.SyncProductData";
        #endregion

        #region Account

        public const string Online = "Account.online";
        public const int OnlineTableType = 128;

        public const string Account = "Account.account";
        public const int AccountTableType = 129;

        public const string AccountTenantRelationship = "Account.AccountTenantRelationship";
        public const int AccountTenantRelationshipTableType = 130;

        #endregion

        #region MemberCard

        public const string Card = "MemberCard.Card";
        public const int CardTableType = 131;

        public const string CardUseRecord = "MemberCard.CardUseRecord";
        public const int CardUseRecordTableType = 132;

        public const string RechargeRecord = "MemberCard.RechargeRecord";
        public const int RechargeRecordTableType = 133;

        #endregion

        #region Wms

        public const string WMS_StoreHouse = "Wms.WMS_StoreHouse";
        public const int WMS_StoreHouseTableType = 134;

        public const string WMS_Stock = "Wms.WMS_Stock";
        public const int WMS_StockTableType = 135;

        public const string WMS_OutStock = "Wms.WMS_OutStock";
        public const int WMS_OutStockTableType = 136;

        public const string WMS_InStock = "Wms.WMS_InStock";
        public const int WMS_InStockTableType = 137;

        public const string WMS_Inventory = "Wms.WMS_Inventory";
        public const int WMS_InventoryTableType = 138;

        public const string WMS_OutStockDetail = "Wms.WMS_OutStockDetail";
        public const int WMS_OutStockDetailTableType = 139;

        public const string WMS_InStockDetail = "Wms.WMS_InStockDetail";
        public const int WMS_InStockDetailTableType = 140;

        public const string WMS_InventoryDetail = "Wms.WMS_InventoryDetail";
        public const int WMS_InventoryDetailTableType = 141;

        public const string WMS_AllocateList = "Wms.WMS_AllocateList";
        public const int WMS_AllocateListTableType = 142;

        public const string WMS_AllocateDetail = "Wms.WMS_AllocateDetail";
        public const int WMS_AllocateDetailTableType = 143;

        public const string WMS_AllocateOutStockMap = "Wms.WMS_AllocateOutStockMap";
        public const int WMS_AllocateOutStockMapTableType = 144;

        public const string WMS_AllocateInStockMap = "Wms.WMS_AllocateInStockMap";
        public const int WMS_AllocateInStockMapTableType = 145;

        public const string WMS_InventoryOutStockMap = "Wms.WMS_InventoryOutStockMap";
        public const int WMS_InventoryOutStockMapTableType = 146;

        public const string WMS_InventoryInStockMap = "Wms.WMS_InventoryInStockMap";
        public const int WMS_InventoryInStockMapTableType = 147;

        public const string WMS_ProfitandLossBill = "Wms.WMS_ProfitandLossBill";
        public const int WMS_ProfitandLossBillTableType = 148;

        public const string WMS_ProfitandLossBillDetail = "Wms.WMS_ProfitandLossBillDetail";
        public const int WMS_ProfitandLossBillDetailTableType = 149;
        public const string SyncWmsData = "Wms.SyncWmsData";

        #endregion

        #region CRM

        public const string CustomerLevel = "CRM.CustomerLevel";
        public const int CustomerLevelTableType = 150;

        public const string Customer = "CRM.Customer";
        public const int CustomerTableType = 151;

        public const string CustomerPaySecure = "CRM.CustomerPaySecure";
        public const int CustomerPaySecureTableType = 152;

        public const string CustomerBalance = "CRM.CustomerBalance";
        public const int CustomerBalanceTableType = 153;

        public const string CustomerRechargeRecord = "CRM.CustomerRechargeRecord";
        public const int CustomerRechargeRecordTableType = 154;

        public const string CustomerRechargeType = "CRM.CustomerRechargeType";
        public const int CustomerRechargeTypeTableType = 155;

        public const string CustomerBalanceUseRecord = "CRM.CustomerBalanceUseRecord";
        public const int CustomerBalanceUseRecordTableType = 156;

        public const string CustomerPointsGetRecord = "CRM.CustomerPointsGetRecord";
        public const int CustomerPointsGetRecordTableType = 157;
        public const string MerchantWxGZHInfo = "CRM.MerchantWxGZHInfo";
        public const int MerchantWxGZHInfoTableType = 158;
        public const string MemberWxUserMap = "CRM.MemberWxUserMap";
        public const int MemberWxUserMapTableType = 159;
        public const string MemberWeixinUsersInfo = "CRM.MemberWeixinUsersInfo";
        public const int MemberWeixinUsersInfoTableType = 160;
        public const string WxTemplateMsgSet = "CRM.WxTemplateMsgSet";
        public const int WxTemplateMsgSetTableType = 161;
        public const string MemberImportRecord = "CRM.MemberImportRecord";
        public const int MemberImportRecordTableType = 162;
        public const string MemberImportDetail = "CRM.MemberImportDetail";
        public const int MemberImportDetailTableType = 163;
        /// <summary>
        /// 积分抵现规则
        /// </summary>
        public const string PointsInCashRule = "CRM.PointsInCashRule";
        public const int PointsInCashRuleTableType = 164;

        /// <summary>
        /// 积分兑换商品规则
        /// </summary>
        public const string PointsInProductRule = "CRM.PointsInProductRule";
        public const int PointsInProductRuleTableType = 165;

        /// <summary>
        /// 积分兑换商品日志明细
        /// </summary>
        public const string PointsInProductDetail = "CRM.PointsInProductDetail";
        public const int PointsInProductDetailTableType = 166;

        /// <summary>
        /// 积分兑换商品日志明细
        /// </summary>
        public const string CustomerPointsUseLog = "CRM.CustomerPointsUseLog";
        public const int CustomerPointsUseLogTableType = 167;

        /// <summary>
        /// 客户获得积分日志表
        /// </summary>
        public const string CustomerPointsGetLog = "CRM.CustomerPointsGetLog";
        public const int CustomerPointsGetLogTableType = 168;

        public const string CustomerConsumePointsRule = "CRM.CustomerConsumePointsRule";
        public const int CustomerConsumePointsRuleTableType = 169;

        public const string CustomerRechargePointsRule = "CRM.CustomerRechargePointsRule";
        public const int CustomerRechargePointsRuleTableType = 170;
        public const string SyncCrmData = "Crm.SyncCrmData";
        public const int SyncCrmDataTableType = 171;

        public const string CrmRechargeOrder = "Crm.RechargeOrder";
        public const int CrmRechargeOrderTableType = 172;

        public const string CustomerTimeCardRechargeType = "Crm.CustomerTimeCardRechargeType";
        public const string CustomerTimesCard = "Crm.CustomerTimesCard";
        public const string CustomerTimesCardUseRecord = "Crm.CustomerTimesCardUseRecord";
        public const string CustomerTimesRechargeRecord = "Crm.CustomerTimesRechargeRecord";
        public const string TimesCard = "Crm.TimesCard";
        public const string TimesCardProduct = "Crm.TimesCardProduct";
        public const string TimesCardCategory = "Crm.TimesCardCategory";
        public const string CustomerTimesRechargeRecordDetail = "Crm.CustomerTimesRechargeRecordDetail";
        public const string CustomerTimesCardUseRecordDetail = "Crm.CustomerTimesCardUseRecordDetail";
        public const string CustomerTimesPackageRechargeRecordDetail = "Crm.CustomerTimesPackageRechargeRecordDetail";
        public const string TimesCardPackageDetail = "Crm.TimesCardPackageDetail";

        #endregion CRM

        #region Store

        public const string Company = "Store.Company";
        public const int CompanyTableType = 173;

        public const string Store = "Store.Store";
        public const int StoreTableType = 174;

        public const string Staff = "Store.Staff";
        public const int StaffTableType = 175;

        public const string StoreStaffRelationship = "Store.StoreStaffRelationship";
        public const int StoreStaffRelationshipTableType = 176;

        public const string Room = "Store.Room";
        public const int RoomTableType = 177;

        public const string RoomAndRoomChargeSetRelationship = "Store.RoomAndRoomChargeSetRelationship";
        public const int RoomAndRoomChargeSetRelationshipTableType = 178;

        public const string Role = "Store.Role";
        public const int RoleTableType = 179;

        public const string Desk = "Store.Desk";
        public const int DeskTableType = 180;

        public const string RoleAccountRelationship = "Store.RoleAccountRelationship";
        public const int RoleAccountRelationshipTableType = 181;

        public const string RolePermission = "Store.RolePermission";
        public const int RolePermissionTableType = 182;

        public const string ChargeSet = "Store.ChargeSet";
        public const int ChargeSetTableType = 183;

        public const string RoomMaxChageRule = "Store.RoomMaxChageRule";
        public const int RoomMaxChageRuleTableType = 184;

        public const string RoomChargeSet = "Store.RoomChargeSet";
        public const int RoomChargeSetTableType = 185;

        public const string StoreAuthorizationCode = "Store.StoreAuthorizationCode";
        public const int StoreAuthorizationCodeTableType = 186;

        public const string StorePrinterSettings = "Store.StorePrinterSettings";
        public const int StorePrinterSettingsTableType = 187;

        public const string StoreDayEndTimeRange = "Store.StoreDayEndTimeRange";
        public const int StoreDayEndTimeRangeTableType = 188;

        public const string SmartPlug = "Store.SmartPlug";
        public const int SmartPlugTableType = 189;

        public const string DeskMinConsume = "Store.DeskMinConsume";
        public const int DeskMinConsumeTableType = 190;

        public const string PaySetting = "Store.PaymentSetting";
        public const int PaySettingTableType = 191;

        public const string ProductCommissionRule = "Store.ProductCommissionRule";
        public const int ProductCommissionRuleTableType = 10050001;

        public const string ProductCommissionDetailRule = "Store.ProductCommissionRuleDetail";
        public const int ProductCommissionRuleDetailTableType = 10050002;
        public const string StoreScanCodeOpenBillSetting = "Store.StoreScanCodeOpenBillSetting";
        public const string StoreOperationLog = "Store.StoreOperationLog";
        public const string NewRoleAndPermissionRelationship = "Store.NewRoleAndPermissionRelationship";

        

        #endregion

        #region Sales

        public const string ConsumeBill = "Sales.ConsumeBill";
        public const int ConsumeBillTableType = 1;

        public const string ConsumeBillDetail = "Sales.ConsumeBillDetail";
        public const int ConsumeBillDetailTableType = 2;

        public const string BookConsumeBillMap = "Sales.BookConsumeBillMap";
        public const int BookConsumeBillMapTableType = 3;

        public const string ConsumeBillPay = "Sales.ConsumeBillPay";
        public const int ConsumeBillPayTableType = 4;

        public const string ConsumeBillPayType = "Sales.ConsumeBillPayType";
        public const int ConsumeBillPayTypeTableType = 5;

        public const string Book = "Sales.Book";
        public const int BookTableType = 6;

        public const string BookDetail = "Sales.BookDetail";
        public const int BookDetailTableType = 7;

        public const string CashBook = "Sales.CashBook";

        public const string HandoverWork = "Sales.HandoverWork";
        public const int HandoverWorkTableType = 8;

        public const string HandoverWorkProductDetail = "Sales.HandoverWorkProductDetail";
        public const int HandoverWorkProductDetailTableType = 9;

        public const string HandoverWorkSales = "Sales.HandoverWorkSales";
        public const int HandoverWorkSalesTableType = 10;

        public const string HandoverWorkPayType = "Sales.HandoverWorkPayType";
        public const int HandoverWorkPayTypeTableType = 11;

        public const string ConsumeBillDiscountRange = "Sales.ConsumeBillDiscountRange";
        public const int ConsumeBillDiscountRangeTableType = 12;

        public const string DeskRunStatus = "Sales.DeskRunStatus";
        public const int DeskRunStatusTableType = 13;

        public const string ChangeDeskRoomFee = "Sales.ChangeDeskRoomFee";
        public const int ChangeDeskRoomFeeTableType = 14;

        public const string MergeConsumeBill = "Sales.MergeConsumeBill";
        public const int MergeConsumeBillTableType = 15;

        public const string ChangeDeskProduct = "Sales.ChangeDeskProduct";
        public const int ChangeDeskProductTableType = 16;

        public const string ConsumeBillCleanLog = "Sales.ConsumeBillCleanLog";
        public const int ConsumeBillCleanLogTableType = 17;

        public const string ConsumeBillReversedCheckout = "Sales.ConsumeBillReversedCheckout";
        public const int ConsumeBillReversedCheckoutTableType = 18;

        public const string DeskPauses = "Sales.DeskPauses";
        public const int DeskPausesTableType = 19;

        public const string ConsumeBillPrePaidDetail = "ConsumeBillPrePaidDetail";
        public const int ConsumeBillPrePaidDetailTableType = 20;

        public const string SaleSyncData = "Sales.SyncData";
        public const int SaleSyncDataTableType = 21;

        public const string ConsumeBillPayOrder = "Sales.ConsumeBillPayOrder";
        public const int ConsumeBillPayOrderTableType = 22;
        public const string ConsumeBillWriteOffPayOrder = "Sales.ConsumeBillWriteOffPayOrder";
        public const int ConsumeBillWriteOffPayOrderTableType = 23;
        public const string ConsumeBillWriteOffPayType = "Sales.ConsumeBillWriteOffPayType";
        public const int ConsumeBillWriteOffPayTypeTableType = 24;
        public const string ConsumeBillPendingWriteOff = "Sales.ConsumeBillPendingWriteOff";
        public const int ConsumeBillPendingWriteOffTableType = 25;

        public const string ConsumeSelfOpenBillExtend = "Sales.ConsumeSelfOpenBillExtend";
        public const int ConsumeSelfOpenBillExtendTableType = 1036;
        public const string CommonPayOrderTable = "Sales.CommonPayOrder";

        public const int BizRoomDeskTableType = 26;
        public const int CashBookTableType = 27;
        public const int CashOutOrdersTableType = 28;
        public const int ConsumeBillPrePaidOrderTableType = 29;
        public const int ConsumeBillWriteOffOrderTableType = 30;

        

        public const string Activities = "Sales.Activities";
        public const int ActivitiesTableType = 31;

        public const string ActivitiesProducts = "Sales.ActivitiesProducts";
        public const int ActivitiesProductsTableType = 32;

        public const string ActivitiesLogs = "Sales.ActivitiesLogs";
        public const int ActivitiesLogsTableType = 33;

        public const string ConsumeBillDetailConsumeProductTagMap = "Sales.ConsumeBillDetailConsumeProductTagMap";
        public const string ProductTagsMap = "Sales.ProductTagsMap";
        public const string ConsumeProductTag = "Sales.ConsumeProductTag";
        //public const string ProductCategoryProductTags = "Sales.ProductCategoryProductTags";
        public const string ConsumeProductTagCategory = "Sales.ConsumeProductTagCategory";

        /// <summary>
        /// 开单定时提醒信息
        /// </summary>
        public const int OBCalculatorReminderInfoTableType = 11124;
        public const string OBCalculatorReminderInfo = "Sales.OBCalculatorReminderInfo";

        /// <summary>
        /// 自助开单设置
        /// </summary>
        public const int SelfBookSettingTableType = 11125;
        public const string SelfBookSetting = "Sales.SelfBookSetting";

        /// <summary>
        /// 员工提成
        /// </summary>
        public const string StaffCommissionDetail = "Sales.StaffCommissionDetail";
        public const string ConsumeBillDetailPackageProductMap = "Sales.ConsumeBillDetailPackageProductMap";
        public const string ConsumeBillExtend = "Sales.ConsumeBillExtend";
        public const string DeskBizExtend = "Sales.DeskBizExtend";

        /// <summary>
        /// 快捷消费单
        /// </summary>
        public const string FastConsumeBill = "Sales.FastConsumeBill";
        public const string FastConsumeBillAndConsumeBillMap = "Sales.FastConsumeBillAndConsumeBillMap";

        /// <summary>
        /// 消费明细扩展表
        /// </summary>
        public const string ConsumeBillDetailExtend = "Sales.ConsumeBillDetailExtend";

        public const string MultiBookSetting = "Sales.MultiBookSetting";
        public const string SaleOperationLog = "Sales.SaleOperationLog";

        #endregion Sales

        #region Statistics
        public const string ProductStatistics = "Statistics.ProductStatistics";
        public const int ProductStatisticsTableType = 31;
        public const string CheckOutTypeReport = "Statistics.CheckOutTypeReport";
        public const int CheckOutTypeReportTableType = 32;
        public const string MemberConsumeReport = "Statistics.MemberConsumeReport";
        public const int MemberConsumeReportTableType = 33;
        public const string MemberRechargeReport = "Statistics.MemberRechargeReport";
        public const int MemberRechargeReportTableType = 34;
        public const string ProductCategorySaleReport = "Statistics.ProductCategorySaleReport";
        public const int ProductCategorySaleReportTableType = 35;
        public const string ProductSaleReport = "Statistics.ProductSaleReport";
        public const int ProductSaleReportTableType = 36;
        public const string StaffSaleCheckOutReport = "Statistics.StaffSaleCheckOutReport";
        public const int StaffSaleCheckOutReportTableType = 37;
        public const string StaffSaleCreateBillReport = "Statistics.StaffSaleCreateBillReport";
        public const int StaffSaleCreateBillReportTableType = 38;
        public const string SaleReport = "Statistics.SaleReport";
        public const int SaleReportTableType = 39;
        public const string StaffSaleProductReport = "Statistics.StaffSaleProductReport";
        public const int StaffSaleProductReportTableType = 40;
        public const string StatisticsRecord = "Statistics.StatisticsRecord";
        public const int StatisticsRecordTableType = 41;
        public const string WaitStatisticsRecord = "Statistics.WaitStatisticsRecord";
        public const int WaitStatisticsRecordTableType = 42;
        public const string RoomCategoryReport = "Statistics.RoomCategoryReport";
        public const int RoomCategoryReportTableType = 43;
        public const string RoomReport = "Statistics.RoomReport";
        public const int RoomReportTableType = 44;
        public const string StaffProductReport = "Statistics.StaffProductReport";
        public const int StaffProductReportTableType = 45;
        public const string StaffRechargeReport = "Statistics.StaffRechargeReport";
        public const int StaffRechargeReportTableType = 46;
        public const string InStockReport = "Statistics.InStockReport";
        public const string OutStockReport = "Statistics.OutStockReport";
        public const string RechargePayTypeReport = "Statistics.RechargePayTypeReport";
        public const string MemberRechargeTimesCardReport = "Statistics.MemberRechargeTimesCardReport";
        public const string RechargeTimesCardPayTypeReport = "Statistics.RechargeTimesCardPayTypeReport";
        public const string TimesCardConsumeReport = "Statistics.TimesCardConsumeReport";
        public const string MemberTimesCardConsumeReport = "Statistics.MemberTimesCardConsumeReport";
        public const string RechargeTimesCardReport = "Statistics.RechargeTimesCardReport";
        public const string InOutStockReport = "Statistics.InOutStockReport";

        public const string StaffBookReport = "Statistics.StaffBookReport";
        public const string RoomBookReport = "Statistics.RoomBookReport";
        public const string RoomBookStatusReport = "Statistics.RoomBookStatusReport";
        public const string StaffTimesCardRechargeReport = "Statistics.StaffTimesCardRechargeReport";

        #endregion

        #region SaasManager
        public const string SaasManagerTenant = "SaasManager.SaasManagerTenant";
        public const int SaasManagerTenantTableType = 47;
        public const string SassProduct = "SaasManager.SassProduct";
        public const int SassProductTableType = 48;
        public const string StaffPackageProduct = "SaasManager.StaffPackageProduct";
        public const int StaffPackageProductTableType = 49;
        public const string CombiningPackageProduct = "SaasManager.CombiningPackageProduct";
        public const int CombiningPackageProductTableType = 50;
        public const string CombiningPackageProductDetail = "SaasManager.CombiningPackageProductDetail";
        public const int CombiningPackageProductDetailTableType = 51;
        public const string SmsPackageProduct = "SaasManager.SmsPackageProduct";
        public const int SmsPackageProductTableType = 52;
        public const string CombiningPackageProductOrderDetailMap = "SaasManager.CombiningPackageProductOrderDetailMap";
        public const int CombiningPackageProductOrderDetailMapTableType = 53;
        public const string BackgroundSassSmsOrderDetail = "SaasManager.BackgroundSassSmsOrderDetail";
        public const int BackgroundSassSmsOrderDetailTableType = 54;
        public const string BackgroundSassStaffOrderDetail = "SaasManager.BackgroundSassStaffOrderDetail";
        public const int BackgroundSassStaffOrderDetailTableType = 55;
        public const string BackgroundSassOrderCombiningPackageProductDetail = "SaasManager.SassOrderCombiningPackageProductDetail";
        public const int BackgroundSassOrderCombiningPackageProductDetailTableType = 56;
        public const string SassOrder = "SaasManager.SassOrder";
        public const int SassOrderTableType = 57;
        public const string BackgroundSassRenewOrder = "SaasManager.BackgroundSassRenewOrder";
        public const int BackgroundSassRenewOrderTableType = 58;
        public const string BackgroundSassUpdateOrder = "SaasManager.BackgroundSassUpdateOrder";
        public const int BackgroundSassUpdateOrderTableType = 59;
        public const string TenantCombinePackageProduct = "SaasManager.TenantCombinePackageProduct";
        public const int TenantCombinePackageProductTableType = 60;
        public const string TenantSmsCount = "SaasManager.TenantSmsCount";
        public const int TenantSmsCountTableType = 61;
        public const string TenantStaffEffectiveTime = "SaasManager.TenantStaffEffectiveTime";
        public const int TenantStaffEffectiveTimeTableType = 62;
        public const string TenantServiceSummary = "SaasManager.TenantServiceSummary";
        public const int TenantServiceSummaryTableType = 63;

        public const string TenantStaffEffectiveTimeLog = "SaasManager.TenantStaffEffectiveTimeLog";
        public const int TenantStaffEffectiveTimeLogTableType = 64;
        public const string TenantSmsCountLog = "SaasManager.TenantSmsCountLog";
        public const int TenantSmsCountLogTableType = 65;
        public const string TenantCombinePackageProductLog = "SaasManager.TenantCombinePackageProductLog";
        public const int TenantCombinePackageProductLogTableType = 66;
        public const string TelComManageImageMap = "SaasManager.TelComManageImageMap";
        public const int TelComManageImageMapTableType = 67;
        public const string TelComManager = "SaasManager.TelComManager";
        public const int TelComManagerTableType = 68;

        public const string TenantExtend = "SaasManager.TenantExtend";
        public const int TenantExtendTableType = 69;
        public const string ContactRecord = "SaasManager.ContactRecord";
        public const int ContactRecordTableType = 70;

        public const string QrCodeBatch = "SaasManager.QrCodeBatch";
        public const int QrCodeBatchTableType = 71;
        public const string QrCodes = "SaasManager.QrCodes";
        public const int QrCodesTableType = 72;

        public const string PayRequestSerialRecord = "SaasManager.PayRequestSerialRecord";
        public const int PayRequestSerialRecordTableType = 73;
        public const string PayNotifySerialRecord = "SaasManager.PayNotifySerialRecord";
        public const int PayNotifySerialRecordTableType = 74;
        public const string StoreAudit = "SaasManager.StoreAudit";

        #endregion

        #region Image
        public const string ImageLibary = "ImageLibary.ImageLibary";
        public const int ImageLibaryTableType = 75;
        public const string StoreImageDirectory = "StoreImageDirectory";
        public const int StoreImageDirectoryTableType = 76;
        public const string StoreImage= "StoreImage";
        public const int StoreImageTableType = 77;
        #endregion

        #region PushMessage
        public const string PushMessage = "PushMessage.PushMessage";
        public const int PushMessageTableType = 78;
        public const string PushMessageReadStatus = "PushMessage.PushMessageReadStatus";
        public const int PushMessageReadStatusTableType = 79; 
        public const string PushMessageStat = "PushMessage.PushMessageStat";
        public const int PushMessageStatTableType = 80;
        public const string BookPushMessage = "PushMessage.BookPushMessage";
        public const int BookPushMessageTableType = 81;
        public const string DeskStatusChangePushMessage = "PushMessage.DeskStatusChangePushMessage";
        public const int DeskStatusChangePushMessageTableType = 82;
        #endregion

        #region FindTeaHouse
        public const string ZCLWeixinUsersInfo = "FindTeaHouse.ZCLWeixinUsersInfo";
        public const int ZCLWeixinUsersInfoTableType = 83;
        public const string ZCLAccountMap = "FindTeaHouse.ZCLAccountMap";
        public const int ZCLAccountMapTableType = 84;
        public const string ZCLUserOnline = "FindTeaHouse.ZCLUserOnline";
        public const int ZCLUserOnlineTableType = 85;
        public const string ZCLBookAccountMap = "FindTeaHouse.ZCLBookAccountMap";
        public const int ZCLBookAccountMapTableType = 86;
        public const string ZCLStoreDeskInfo = "FindTeaHouse.ZCLStoreDeskInfo";
        public const int ZCLStoreDeskInfoTableType = 87;
        public const string ZCLStoreInfo = "FindTeaHouse.ZCLStoreInfo";
        public const int ZCLStoreInfoTableType = 88;
        public const string ZCLStoreImageMap = "FindTeaHouse.ZCLStoreImageMap";
        public const int ZCLStoreImageMapTableType = 89;
        public const string ZCLDeskImageMap = "FindTeaHouse.ZCLDeskImageMap";
        public const int ZCLDeskImageMapTableType = 90;
        public const string ZCLGeoLocation = "FindTeaHouse.ZCLGeoLocation";
        public const int ZCLGeoLocationTableType = 91;
        public const string ZCLStoreRoomInfo = "FindTeaHouse.ZCLStoreRoomInfo";
        public const int ZCLStoreRoomInfoTableType = 92;
        public const string ZCLFavorite = "FindTeaHouse.ZCLFavorite";
        public const int ZCLFavoriteTableType = 93;
        public const string ZCLStoreServiceTagMap = "FindTeaHouse.ZCLStoreServiceTagMap";
        public const int ZCLStoreServiceTagMapTableType = 94;
        public const string ZCLStoreServiceTag = "FindTeaHouse.ZCLStoreServiceTag";
        public const int ZCLStoreServiceTagTableType = 95;
        public const string ZCLStoreComment = "FindTeaHouse.ZCLStoreComment";
        public const int ZCLStoreCommentTableType = 96;
        public const string ZCLStoreCommentCount = "FindTeaHouse.ZCLStoreCommentCount";
        public const int ZCLStoreCommentCountTableType = 97;
        public const string ZCLStoreTagComment = "FindTeaHouse.ZCLStoreTagComment";
        public const int ZCLStoreTagCommentTableType = 98;
        public const string ZCLStoreTagCommentCount = "FindTeaHouse.ZCLStoreTagCommentCount";
        public const int ZCLStoreTagCommentCountTableType = 99;
        public const string UserCommentTag = "FindTeaHouse.UserCommentTag";
        public const int UserCommentTagTableType = 100;
        public const string UserCommentTagMap = "FindTeaHouse.UserCommentTagMap";
        public const int UserCommentTagMapTableType = 101;
        public const string ChessParty = "FindTeaHouse.ChessParty";
        public const int ChessPartyTableType = 102;
        public const string ChessPartyMemberInfo = "FindTeaHouse.ChessPartyMemberInfo";
        public const int ChessPartyMemberInfoTableType = 103;
        public const string ChessPartyJoinFeeOrder = "FindTeaHouse.ChessPartyJoinFeeOrder";
        public const int ChessPartyJoinFeeOrderTableType = 104;
        public const string ChessPartyConsumeBillMap = "FindTeaHouse.ChessPartyConsumeBillMap";
        public const int ChessPartyConsumeBillMapTableType = 105;
        public const string ChessPartyStoreRebateSet = "FindTeaHouse.ChessPartyStoreRebateSet";
        public const int ChessPartyStoreRebateSetTableType = 106;
        #endregion


        public const int CustomerRechargeOrdersTableType = 10001;
        public const int CustomerReChargeRulesTableType = 10002;
        public const int ImageLibraryTableType = 10003;
        public const int MemberCardRelateCustomerTableType = 10004;
        public const int PermissionCategoryTableType = 10005;
        public const int PermissionTableType = 10006;
        public const int PointsInProductDetailsTableType = 10007;
        public const int RegionTableType = 10008;
        public const int RoleAndPermissionRelationshipTableType = 10009;
        public const int SaleChannelTableType = 10010;
        public const int SassOrderCombiningPackageProductDetailTableType = 10011;
        public const int SmartPlugMapsTableType = 10012;
        public const int SmartSwitchSettingsTableType = 10013;
        public const int StorePaymentSettingsTableType = 10014;
        public const int SyncSaleDataTableType = 10015;
        public const int ThirdPlatformInfoTableType = 10016;
        public const int UnitTableType = 10017;
        public const int WMS_ProfitAndLossBillDetailTableType = 10018;
        public const int WMS_ProfitAndLossBillTableType = 10019;
        public const int ZCLStoreBaiduCoordinateTableType = 10020;
        public const int ZCLStoreDeskInfoImageMapTableType = 10021;
        public const int ZCLStoreImageCountTableType = 10022;
        public const int ZCLUserCommentTagTableType = 10023;
        public const int ZCLUserCommentTagMapTableType = 10024;
        public const int ZCLUserFavoritesTableType = 10025;
        public const int ProductOrPackageMapTableType = 10026;
        public const int ConsumeBillDetailPackageProductMapTableType = 10027;
        public const int StaffCommissionDetailTableType = 10028;
        public const int StoreScanCodeOpenBillSettingTableType = 10029;
        public const int ProductImportRecordTableType = 10030;
        public const int IngredientsImportRecordTableType = 10031;
        public const int ProductImportDetailTableType = 10032;
        public const int IngredientsImportDetailTableType = 10033;
        public const int ConsumeBillExtendTableType = 10034;
        public const int DeskBizExtendTableType = 10035;
        public const int ConsumeBillDetailConsumeProductTagMapTableType = 10036;
        public const int ConsumeProductTagTableType = 10037;
        //public const int ProductCategoryProductTagsTableType = 10038;
        public const int StoreOperationLogTableType = 10039;
        public const int StoreAuditTableType = 10040;
        
        public const int InStockReportTableType = 10041;
        public const int OutStockReportTableType = 10042;
        public const int RechargePayTypeReportTableType = 10043;
        public const int SyncWmsDataTableType = 10044;

        public const int ProductAndPeiProductMapTableType = 10045;

        public const int CustomerTimeCardRechargeTypeTableType = 10046;
        public const int CustomerTimesCardTableType = 10047;
        public const int CustomerTimesCardUseRecordTableType = 10048;
        public const int CustomerTimesRechargeRecordTableType = 10049;
        public const int TimesCardTableType = 10050;
        public const int TimesCardProductTableType = 10051;
        public const int TimesCardCategoryTableType = 1052;

        public const int FastConsumeBillTableType = 1053;
        public const int FastConsumeBillAndConsumeBillMapTableType = 1054;
        public const int ProductTagsMapTableType = 1055;
        public const int ConsumeProductTagCategoryTableType = 1056;
        public const int ProductCategoryProductTagsTableType = 1057;
        public const int CustomerTimesRechargeRecordDetailTableType = 1058;
        public const int CustomerTimesCardUseRecordDetailTableType = 1059;

        public const int CommonPayOrderTableType = 1060;       
        public const int MemberRechargeTimesCardReportTableType = 1061;
        public const int RechargeTimesCardPayTypeReportTableType = 1062;
        public const int TimesCardConsumeReportTableType = 1063;
        public const int MemberTimesCardConsumeReportTableType = 1064;
        public const int RechargeTimesCardReportTableType = 1065;
        public const int MultiBookSettingTableType = 1066;

        public const int ConsumeBillDetailExtendTableType = 1070;
        public const int InOutStockReportTableType = 1071;
        public const int StaffBookReportTableType = 1089;
        public const int RoomBookReportTableType = 1090;
        public const int RoomBookStatusReportTableType = 1091;


        public const string Coupon = "Sales.Coupon";
        public const string Coupons = "Sales.Coupons";
        public const string CouponOperLog = "Sales.CouponOperLog";
        public const string CouponActivity = "Sales.CouponActivity";
        public const string CouponRechargeActiveRule = "Sales.CouponRechargeActiveRule";
        public const string CouponsGiveLog = "Sales.CouponsGiveLog";
        //public const string CouponUseLog = "Sales.CouponUseLog";


        public const int CouponActivityTableType = 1101;
        public const int CouponTableType = 1102;
        public const int CouponOperLogTableType = 1103;
        public const int CouponRechargeActiveRuleTableType = 1104;
        public const int CouponsTableType = 1105;
        public const int CouponActivityStatisticsTableType = 1106;
        public const int CouponsUseLogTableType = 1107;
        public const int StaffTimesCardRechargeReportTableType = 1108;


        public const int ChangeDeskLogsTableType = 1110;

        public const int CouponsGiveDetailsTableType = 1111;
        public const int CouponsGiveLogTableType = 1112;

        public const string ChangeDeskLogs = "Sales.ChangeDeskLogs";
        public const int GuoTanDataSyncTableType = 1113;
        public const int ProductSellOutCategoryAndProductMapTableType = 1114;
        public const int ProductSellOutCategoryTableType = 1115;
        public const int ProductSellOutCategoryTimeRangeTableType = 1116;

        public const int CancleSaleInStockSourceTableType = 1120;
        public const int CancleSaleInStockDetailSourceTableType = 1121;
        public const int SaleOutStockSourceTableType = 1122;
        public const int SaleOutStockDetailSourceTableType = 1123;
        public const int ConsumeBillCancleInfoTableType = 1124;
        public const int ConsumeBillDetailCancleInfoTableType = 1125;

        public const int SmartPlugDelayCloseTableType = 1126;
        public const int WaitProductSellOutTimeRangeTaskTableType = 1127;

        public const string WxMemberCardSetting = "CRM.WxMemberCardSetting";
        public const int WxMemberCardSettingTableType = 1128;

        public const int CustomerTimesPackageRechargeRecordDetailTableType = 1129;
        public const int TimesCardPackageDetailTableType = 1130;
        //public const string CustomerTimesPackageRechargeRecordDetail = "Crm.CustomerTimesPackageRechargeRecordDetail";
        //public const string TimesCardPackageDetail = "Crm.TimesCardPackageDetailTableType";
        public const int SyncProductDataTableType = 1131;
        public const int SyncStoreDataTableType = 1132;
        public const int WaitSyncOtherPlatformDataTableType = 1133;
        public const int SaleOperationLogTableType = 1134;

        public const string ChangeOrderedProductLogs = "Sale.ChangeOrderedProductLogs";
        public const int ChangeOrderedProductLogsTableType = 1135;
        public const string DeskMaintainInfo = "Sale.DeskMaintainInfo";
        public const int DeskMaintainInfoTableType = 1136;
        public const int NewRoleAndPermissionRelationshipTableType = 1137;


        public const string DepositUserInfo = "Store.DepositUserInfo";
        public const string DepositInfo = "Store.DepositInfo";
        public const string DepositLog = "Store.DepositLog";

        public const int DepositInfoTableType = 1138;
        public const int DepositLogTableType = 1139;
        public const int DepositUserInfoTableType = 1140;
        public const int DepositSummaryTableType = 1141;
        public const int StoreSmsSendRuleSettingsTableType = 1142;

        /*无人门店订单 liujianhua 20191104*/
        public const string UnmannedOrder = "FindTeaHouse.UnmannedOrder";
        public const int UnmannedOrderTableType = 1150;
        public const string UnmannedOrderDetail = "FindTeaHouse.UnmannedOrderDetail";
        public const int UnmannedOrderDetailTableType = 1151;
        public const string UnmannedOrderedTimes = "FindTeaHouse.UnmannedOrderedTimes";
        public const int UnmannedOrderedTimesTableType = 1152;
        public const string UnmannedOrderPaidDetail = "FindTeaHouse.UnmannedOrderPaidDetail";
        public const int UnmannedOrderPaidDetailTableType = 1153;
        public const string FindTeaHousesPendingTaskData = "FindTeaHouse.FindTeaHousesPendingTaskData";

        /*liujianhua 20200103 */
        public const string CouponRegActiveRule = "Sales.CouponRegActiveRule";
        public const int CouponRegActiveRuleTableType = 1160;

        public const string ConsumeBillExtendPayNow = "Sales.ConsumeBillExtendPayNow";
        public const int ConsumeBillExtendPayNowTableType = 1161;

        /* 时长卡相关*/
        public const string DurationCardCategory = "CRM.DurationCardCategory";
        public const int DurationCardCategoryTableType = 1170;
        public const string DurationCard = "CRM.DurationCard";
        public const int DurationCardTableType = 1171;
        public const string DurationCardCoverImages = "CRM.DurationCardCoverImages";
        public const int DurationCardCoverImagesTableType = 1172;
        public const string DurationCardRoomInfo = "CRM.DurationCardRoomInfo";
        public const int DurationCardRoomInfoTableType = 1173;
        public const string CustomerDurationCard = "CRM.CustomerDurationCard";
        public const int CustomerDurationCardTableType = 1174;
        public const string CustomerDurationCardRechargeType = "CRM.CustomerDurationCardRechargeType";
        public const int CustomerDurationCardRechargeTypeTableType = 1175;
        public const string CustomerDurationRechargeRecord = "CRM.CustomerDurationRechargeRecord";
        public const int CustomerDurationRechargeRecordTableType = 1176;
        public const string CustomerDurationRechargeRecordDetail = "CRM.CustomerDurationRechargeRecordDetail";
        public const int CustomerDurationRechargeRecordDetailTableType = 1177;
        public const string CustomerDurationCardUseRecord = "CRM.CustomerDurationCardUseRecord";
        public const int CustomerDurationCardUseRecordTableType = 1178;
        public const string CustomerDurationCardUseRecordDetail = "CRM.CustomerDurationCardUseRecordDetail";
        public const int CustomerDurationCardUseRecordDetailTableType = 1179;

        public const string MeiTuanPrdMaps = "Store.MeiTuanPrdMaps";
        public const int SmartSpeakersTableType = 1180;
        public const int SmartSpeakersMapsTableType = 1181;
        

        /*门店定时任务*/
        public const string StorePendingTaskData = "Store.StorePendingTaskData";

        /*Crm定时任务*/
        public const string CrmPendingTaskData = "Crm.CrmPendingTaskData";

        /*Sale定时任务*/
        public const string SalePendingTaskData = "Sale.SalePendingTaskData";    

        /*微信第三方平台*/
        public const int MiniAppTokenTableType = 1182;
        public const string MiniAppToken = "FindTeaHouse.MiniAppToken";
        public const int AuthMiniAppInfoTableType = 1183;
        public const string AuthMiniAppInfo = "FindTeaHouse.AuthMiniAppInfo";
        public const int MiniAppCodeTableType = 1184;
        public const string MiniAppCode = "FindTeaHouse.MiniAppCode";
        public const int MiniAppExperiencerTableType = 1185;
        public const string MiniAppExperiencer = "FindTeaHouse.MiniAppExperiencer";
        public const int MiniAppPushLogTableType = 1186;
        public const string MiniAppPushLog = "FindTeaHouse.MiniAppPushLog";
        public const int MiniAppSubscribeMessageTableType = 1187;
        public const string MiniAppSubscribeMessage = "FindTeaHouse.MiniAppSubscribeMessage";
        public const int MiniAppCodeAuditTableType = 1188;
        public const string MiniAppCodeAudit = "FindTeaHouse.MiniAppCodeAudit";

        /*美团点评*/
        public const int MeiTuanAccountTableType = 1191;
        public const int MeiTuanPrdMapsTableType = 1192;
        public const int MeiTuanReceiptLogsTableType = 1194;
        public const string MeiTuanReceiptLogs = "Store.MeiTuanReceiptLogs";

        /*无人订单扩展表*/
        public const int UnmannedOrderExtendTableType = 1193;
        public const string UnmannedOrderExtend = "FindTeaHouse.UnmannedOrderExtend";

        public const int CrmOperationLogTableType = 1195;
        public const string CrmOperationLog = "Crm.CrmOperationLog";

        public const int AccountOperationLogTableType = 1196;
        public const string AccountOperationLog = "Account.AccountOperationLog";

        /*广告导航表*/
        public const int AdNavigationTableType = 1197;
        public const string AdNavigation = "FindTeaHouse.AdNavigation";

        /*客户时长卡使用每日统计*/
        public const int CustomerDurationCardDailyUseSummaryTableType = 1198;
        public const string CustomerDurationCardDailyUseSummary = "CRM.CustomerDurationCardDailyUseSummary";

        public const int SelfHelpOrdersTableType = 1199;
        public const string SelfHelpOrders = "Sales.SelfHelpOrders";

        public const int SmartPlugLogsTableType = 1200;
        //包座
        public const int SeatCardTableType = 1201;
        public const string SeatCardTable = "CRM.SeatCard";
        //套餐新购续费重构2020.09
        public const int OrderPackageProductSnapshotTableType = 1202;
        public const string OrderPackageProductSnapshot = "SaasManager.OrderPackageProductSnapshot";
        public const int OrderPackageSmsShotsnapTableType = 1203;
        public const string OrderPackageSmsShotsnap = "SaasManager.OrderPackageSmsShotsnap";
        public const int OrderPackageStaffSnapshotTableType = 1204;
        public const string OrderPackageStaffSnapshot = "SaasManager.OrderPackageStaffSnapshot";
        public const int PackageProductCategoryTableType = 1205;
        public const string PackageProductCategory = "SaasManager.PackageProductCategory";
        public const int PackageProductTableType = 1206;
        public const string PackageProduct = "SaasManager.PackageProduct";
        public const int PackageProductOrderTableType = 1207;
        public const string PackageProductOrder = "SaasManager.PackageProductOrder";
        public const int PackageSmsTableType = 1208;
        public const string PackageSms = "SaasManager.PackageSms";
        public const int PackageSmsOrderTableType = 1209;
        public const string PackageSmsOrder = "SaasManager.PackageSmsOrder";
        public const int PackageStaffTableType = 1210;
        public const string PackageStaff = "SaasManager.PackageStaff";
        public const int PackageStaffOrderTableType = 1211;
        public const string PackageStaffOrder = "SaasManager.PackageStaffOrder";
        public const int PurchasedPackageProductTableType = 1212;
        public const string PurchasedPackageProduct = "SaasManager.PurchasedPackageProduct";
        public const int PurchasedPackageProductDetailTableType = 1213;
        public const string PurchasedPackageProductDetail = "SaasManager.PurchasedPackageProductDetail";
        public const int PurchasedPackageProductDetailLogTableType = 1214;
        public const string PurchasedPackageProductDetailLog = "SaasManager.PurchasedPackageProductDetailLog";
        public const int PurchasedPackageProductLogTableType = 1215;
        public const string PurchasedPackageProductLog = "SaasManager.PurchasedPackageProductLog";
        public const int PurchasedPackageSmsTableType = 1216;
        public const string PurchasedPackageSms = "SaasManager.PurchasedPackageSms";
        public const int PurchasedPackageSmsLogTableType = 1217;
        public const string PurchasedPackageSmsLog = "SaasManager.PurchasedPackageSmsLog";
        public const int PurchasedPackageStaffTableType = 1218;
        public const string PurchasedPackageStaff = "SaasManager.PurchasedPackageStaff";
        public const int PurchasedPackageStaffDetailTableType = 1219;
        public const string PurchasedPackageStaffDetail = "SaasManager.PurchasedPackageStaffDetail";
        public const int PurchasedPackageStaffDetailLogTableType = 1220;
        public const string PurchasedPackageStaffDetailLog = "SaasManager.PurchasedPackageStaffDetailLog";
        public const int PurchasedPackageStaffLogTableType = 1221;
        public const string PurchasedPackageStaffLog = "SaasManager.PurchasedPackageStaffLog";
        public const int OrderPackageProductCategorySnapshotTableType = 1222;
        public const string OrderPackageProductCategorySnapshot = "SaasManager.OrderPackageProductCategorySnapshot";
        public const int CustomerSeatCardRechargeRecordDetailTableType = 1223;
        public const string CustomerSeatCardRechargeRecordDetailTable = "CRM.CustomerSeatCardRechargeRecordDetail";
        public const int CustomerSeatCardRechargeRecordTableType = 1224;
        public const string CustomerSeatCardRechargeRecordTable = "CRM.CustomerSeatCardRechargeRecord";
        public const int CustomerSeatCardTableType = 1225;
        public const string CustomerSeatCardTable = "CRM.CustomerSeatCard";
        public const int CustomerSeatCardRechargeTypeTableType = 1226;
        public const string CustomerSeatCardRechargeTypeTable = "CRM.CustomerSeatCardRechargeType";
        public const int ZCLCustomerSeatCardMapTableType = 1227;
        public const string ZCLCustomerSeatCardMapTableTypeTable = "FindTeaHouses.ZCLCustomerSeatCardMap";

        //自助预订提前结束消费部分退款        
        public const int AheadOverRefundBillTableType = 1230;
        public const string AheadOverRefundBill = "FindTeaHouses.AheadOverRefundBill";
        public const int AheadOverRefundBillDetailTableType = 1231;
        public const string AheadOverRefundBillDetail = "FindTeaHouses.AheadOverRefundBillDetail";

        public const int ExcelExportTaskTableTableType = 1232;
        public const string ExcelExportTaskTable = "Base.ExcelExportTaskTable";

        //预结账
        public const int ConsumeBillPreCheckoutExtendTableType = 1233;
        public const string ConsumeBillPreCheckoutExtend = "Sale.ConsumeBillPreCheckoutExtend";
        public const int ConsumeBillPreCheckoutLogsTableType = 1234;
        public const string ConsumeBillPreCheckoutLogs = "Sale.ConsumeBillPreCheckoutLogs";

        public const int ChangePackageProductOrderTableType = 1235;
        public const string ChangePackageProductOrder = "SaasManager.ChangePackageProductOrder";
        public const int PackageOrderTableType = 1236;
        public const string PackageOrder = "SaasManager.PackageOrder";
        public const int PackageOrderPayTypeTableType = 1237;
        public const string PackageOrderPayType = "SaasManager.PackageOrderPayType";
        public const int RebuyPackageProductOrderTableType = 1238;
        public const string RebuyPackageProductOrder = "SaasManager.RebuyPackageProductOrder";
        public const int RebuyPackageStaffOrderTableType = 1239;
        public const string RebuyPackageStaffOrder = "SaasManager.RebuyPackageStaffOrder";

        //门店通用设置
        public const int StoreCommonSettingsTableType = 1240;
        public const string StoreCommonSettings = "Store.StoreCommonSettings";

        public const int StoreMixedSettingsTableType = 1241;
        //商户端黑名单
        public const int ZCLBlackListTableType = 1242;
        public const string ZCLBlackList = "FindTeaHouses.ZCLBlackList";

        //商户端
        public const int MerchantWxNotiSwitchSettingTableType = 1243;
        public const string MerchantWxNotiSwitchSetting = "CRM.MerchantWxNotiSwitchSetting";

        //库存商品拆零
        public const int UnpackProductRelationMapTableType = 1244;
        public const string UnpackProductRelationMap = "Product.UnpackProductRelationMap";
        //保洁签到
        public const int CleanerSignInTableType = 1245;
        public const string CleanerSignIn = "Store.CleanerSignIn";

        //会员消费时长报表
        public const int MemberConsumeTimeLengthReportTableType = 1246;
        public const string MemberConsumeTimeLengthReport = "Statistics.MemberConsumeTimeLengthReport";

        public const int CloundDicTableType = 1246;
        public const int CloundTagValueTableType = 1247;
        public const int CloundProdutTableType = 1248;


    }
}