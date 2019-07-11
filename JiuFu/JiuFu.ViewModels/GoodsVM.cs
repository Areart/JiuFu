using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.ViewModels
{
     public class GoodsVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }      //名称
        public string Price { get; set; }       //价格
        public string Detail { get; set; }  //详细
        public IFormFile Picture { get; set; }     //图片
    }
}
