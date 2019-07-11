using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace JiuFu.Entities
{
    /// <summary>
    /// 食品订单
    /// </summary>
    public class FoodOrder : IEntityBase
    {
        public Guid Id { get; set; }
        public string Room{ get; set; }          //房间号
        public Guid FoodId { get; set; }
        public virtual Food Food { get; set; }  // 关联食品组
        public string Number { get; set; }       //数量     
        public string Remarks { get; set; }   //备注
        public FoodStateEnum FoodState { get; set; }      //状态
        public string FlarNames { get; set; }
        public bool OrderStatus { get; set; } 
        public FoodOrder()
        {
            this.Id = Guid.NewGuid();
        }
    }
  
}
