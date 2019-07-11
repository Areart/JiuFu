using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
     public class Food : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        //名称
        public string Price { get; set; }       //价格
        public Guid FoodClassId { get; set; }
        public virtual FoodClass FoodClass { get; set; }  // 关联食品组
        public string Detail { get; set; }       //详细
        public SaleState SaleState { get; set; }        //状态
        public string picture { get; set; }     //图片
        public Guid flavorId { get; set; }
        public virtual Flavor Flavor  { get; set; }
        public virtual ICollection<FoodOrder> Foods { get; set; }
        public Food()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
