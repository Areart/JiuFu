using JiuFu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.Entities
{
    /// <summary>
    /// 菜品分类
    /// </summary>
    public class FoodClass : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }     //类名  
        public virtual ICollection<Food> Foods { get; set; }
        public FoodClass()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
