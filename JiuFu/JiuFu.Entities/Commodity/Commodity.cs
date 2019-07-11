using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
    /// <summary>
    /// 周边
    /// </summary>
     public class Commodity:IEntityBase
    {
        public Guid Id { get; set; }
       
        public string Name{ get; set; }           //商品名称
        public string Price{ get; set; }            //价格
        public string Detail{ get; set; }             //详细
        public SaleState SaleState{ get; set; }         //状态
        public string picture { get; set; }     //图片
        public virtual ICollection<CommodityOrder> CommodityOrder { get; set; }

        public Commodity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
