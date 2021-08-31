using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Core.Config
{
    public class SystemStandardProductConfig
    {
        /// <summary>
        /// 系统标准商品集
        /// </summary>
        public Product[] StandProducts { get; set; }

        public Product FindItemByKey(int combiningPackageType, int saasProductTypeID)
        {
            Product model = new Product();
            if (this.StandProducts != null && this.StandProducts.Length > 0)
            {
                foreach (var item in this.StandProducts)
                {
                    if (item.CombiningPackageType == combiningPackageType && item.SaasProductTypeID == saasProductTypeID)
                    {
                        model = item;
                    }
                }
            }
            return model;
        }

        public Product this[int combiningPackageType, int saasProductTypeID] => this.FindItemByKey(combiningPackageType, saasProductTypeID);
    }

    public class Product
    {
        public long ID { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// CombiningPackageType:1:普通产品，2:员工套餐，3:短信
        /// </summary>
        public int CombiningPackageType { get; set; }
        /// <summary>
        /// SaasProductTypeID:商品模块类型 
        /// 营业= 1,
        /// 库存 = 2,
        /// 会员 = 3,
        /// 报表 = 4,
        /// 设置 = 5,
        /// 微服务=6,
        /// 消费单=7,
        /// 智能插座 = 8,
        /// 绿米电源 = 9
        /// </summary>
        public int SaasProductTypeID { get; set; }
        /// <summary>
        /// 默认价格
        /// </summary>
        public decimal DefaultPrice { get; set; }
        /// <summary>
        /// 是否免费功能
        /// </summary>
        public bool IsFree { get; set; }
    }
}
