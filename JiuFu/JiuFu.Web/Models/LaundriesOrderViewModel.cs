using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiuFu.Web.Models
{
    public class LaundriesOrderViewModel
    {
        public string Laundry { get; set; }
        public Guid laundriesid { get; set; }

        public string Price { get; set; }       //价格
        public string Remarks { get; set; }   //备注
        public string Room { get; set; }     //房间号
        public State LaundriesState { get; set; }      //状态
    }
}

