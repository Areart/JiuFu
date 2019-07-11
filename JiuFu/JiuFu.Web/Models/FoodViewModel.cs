using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiuFu.Web.Models
{
    public class FoodViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        //名称
        public string Price { get; set; }       //价格
        public  string ClassName { get; set; }  // 关联食品组
        public string Detail { get; set; }       //详细
        public SaleState SaleState { get; set; }        //状态
        public string picture { get; set; }     //图片
        public virtual Flavor Flavor { get; set; }
    }
}
