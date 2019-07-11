using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
    /// <summary>
    /// 娱乐
    /// </summary>
    public class Entertainment : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }      //名称
        public string Position{ get; set; }  //位置
        public string Date{ get; set; }  //时间
        public string Detail{ get; set; }  //详细
        public string picture { get; set; }     //图片
        public Entertainment()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
