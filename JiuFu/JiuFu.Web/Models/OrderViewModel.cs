using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiuFu.Web.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Peice { get; set; }
        public string picture { get; set; }
        public string CLass { get; set; }
        public string Price { get; set; }       //价格
        public string Remarks { get; set; }   //备注
        public string FoodState { get; set; }      //状态
        public bool OrderStatus { get; set; }
    }
}
