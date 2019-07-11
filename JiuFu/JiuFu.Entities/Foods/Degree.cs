using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
     public class Degree : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }       //名称        
        public virtual Flavor Flavors { get; set; }
        public Degree()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
