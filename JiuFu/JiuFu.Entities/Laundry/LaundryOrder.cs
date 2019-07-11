using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
    /// <summary>
    /// 洗衣订单
    /// </summary>
    public class LaundryOrder : IEntityBase
    {
        public Guid Id { get; set; }
        public virtual Laundry Laundry { get; set; }   //洗衣
        public string Remarks { get; set; }   //备注
        public State State { get; set; }     //状态
        public string Room { get; set; }     //房间号
        public DateTime Date { get; set; }   //日期
        public string Piece { get; set; }   //总件数
        public string Price { get; set; }   //价格
        public LaundryOrder()
        {
            this.Id = Guid.NewGuid();
        }
    }
}