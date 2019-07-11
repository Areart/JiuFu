using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
    /// <summary>
    /// 物品
    /// </summary>
    public class Goods : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }      //名称
        public string Price { get; set; }       //价格
        public string Detail { get; set; }  //详细
        public string picture { get; set; }     //图片
        public virtual ICollection<GoodsOrder> GoodsOrders { get; set; }
        public Goods()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
