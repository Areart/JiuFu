using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
    /// <summary>
    /// 物品订单
    /// </summary>
    public class GoodsOrder : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }         //名称
        public  Guid GoodsId { get; set; }        //物品
        public virtual Goods Goods { get; set; }        //物品
        public string Number { get; set; }       //数量
        public string Remarks { get; set; }   //备注
        public string Room { get; set; }         //房间
        public State  State{ get; set; }        //状态
        public bool OrderStatus { get; set; }
        public GoodsOrder()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
