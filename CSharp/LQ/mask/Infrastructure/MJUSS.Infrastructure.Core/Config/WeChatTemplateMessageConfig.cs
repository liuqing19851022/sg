using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.Config
{
    public class WeChatTemplateMessageConfig
    {
        /// <summary>
        /// 预订成功通知模板 到找茶楼商户
        /// </summary>
        public string OrderCreateC2BTemplateId { get; set; }

        /// <summary>
        /// 预订取消通知模板 到找茶楼商户
        /// </summary>
        public string OrderCancelC2BTemplateId { get; set; }

        /// <summary>
        /// 预订取消通知模板 到找茶楼
        /// </summary>
        public string OrderCancelB2CTemplateId { get; set; }

        /// <summary>
        /// 预订超时取消通知模板 到找茶楼商户
        /// </summary>
        public string OrderTimeExpiredCancelC2BTemplateId { get; set; }

        /// <summary>
        /// 预订超时取消通知模板 到找茶楼
        /// </summary>
        public string OrderTimeExpiredCancelB2CTemplateId { get; set; }

        /// <summary>
        /// 约局创建成功
        /// </summary>
        public string ChessPartyCreateTemplateId { set; get; }
        /// <summary>
        /// 约局加入成功
        /// </summary>
        public string ChessPartyJoinTemplateId { get; set; }
        /// <summary>
        /// 约局成功模板消息编号 
        /// </summary>
        public string ChessPartySuccessTemplateId { get; set; }
        /// <summary>
        /// 约局信息变更模板消息编号
        /// </summary>
        public string ChessPartyChangedTemplateId { get; set; }
        /// <summary>
        /// 约局预定失败模板消息编号
        /// </summary>
        public string OrderUnSuccessTemplateId { get; set; }
    }
}
