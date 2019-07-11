using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
    /// <summary>
    /// 洗衣
    /// </summary>
    public class Laundry : IEntityBase
    {
        public Guid Id { get; set; }
        public string Mode { get; set; }      //方式
        public string Price { get; set; }     //价格
        public virtual ICollection<LaundryOrder> LaundriesOrder { get; set; }
        public Laundry()
        {
            this.Id = Guid.NewGuid();
        }
    }
}

