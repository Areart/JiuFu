using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JiuFu.Web.Models
{
     public class FoodOrderViewModel
    {
        public Guid foodid { get; set; }
        public string Name { get; set; }
        public string picture { get; set; }     //图片
        public string Price { get; set; }       //价格
        public string Number { get; set; }       //数量
        public string Remarks { get; set; }   //备注
        public List<Degree> degree { get; set; }
        public string degrees { get; set; }
        public FoodStateEnum FoodState { get; set; }      //状态
    }
}
