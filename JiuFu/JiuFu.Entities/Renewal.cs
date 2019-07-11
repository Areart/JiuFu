using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
    /// <summary>
    /// 续退
    /// </summary>
    public class Renewal : IEntityBase
    {
        public Guid Id { get; set; }       
        public string Date { get; set; }        //日期
        public bool Comategory { get; set; }       //数量
        public State state{ get; set; }        //状态
        public Renewal()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
