using System;
using System.Collections.Generic;
using System.Text;

namespace MJUSS.Infrastructure.Core.CustomAttributes
{
  
    /// <summary>
    /// 短信发送规则是否有其他规则
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class SmsSendRuleHasRuleAttribute : Attribute
    {
    }
}
