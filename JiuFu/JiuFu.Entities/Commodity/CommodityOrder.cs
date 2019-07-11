using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
    /// <summary>
    /// 周边订单
    /// </summary>
    public class CommodityOrder : IEntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }      //名称
        public Guid CommoditysId { get; set; }        //物品
        public virtual Commodity Commoditys { get; set; }        //物品
        public string Number { get; set; }    //数量
        public string Remarks { get; set; }   //备注        
        public SaleState SaleStates { get; set; }        //状态
        public bool OrderStatus { get; set; }
        public CommodityOrder()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
