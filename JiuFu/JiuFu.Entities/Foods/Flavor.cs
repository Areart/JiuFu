using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
    /// <summary>
    /// 口味
    /// </summary>
    public class Flavor : IEntityBase
    { 
        public Guid Id { get; set; }            
        public string Name { get; set; }       //名称
        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
        public Flavor()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
