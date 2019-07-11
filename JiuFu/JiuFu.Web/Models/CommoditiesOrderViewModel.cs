using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiuFu.Web.Models
{
    public class CommoditiesOrderViewModel
    {
        public Guid commoditiesid { get; set; }
        public string Name { get; set; }
        public string picture { get; set; }     //图片
        public string Price { get; set; }       //价格
        public string Number { get; set; }       //数量
        public string Remarks { get; set; }   //备注
        public SaleState SaleStates { get; set; }    //状态
        public string Detail { get; set; }
    }
}
