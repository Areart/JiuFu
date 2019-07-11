using JiuFu.Entities;
using JiuFu.UserAndRole;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiuFu.ORM.SqlServer
{
    public class SqlServerDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }
        #region 食物相关类
        public DbSet<Food> Foods { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<FoodClass> FoodClass { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        #endregion

        #region 相关类
        public DbSet<Commodity> Commoditys { get; set; }
        public DbSet<CommodityOrder> CommodityOrders { get; set; }
        public DbSet<Goods> Goodss { get; set; }
        public DbSet<GoodsOrder> GoodsOrders { get; set; }
        public DbSet<Laundry> Laundrys { get; set; }
        public DbSet<LaundryOrder> LaundryOrders { get; set; }
        public DbSet<Entertainment> Entertainments { get; set; }
        public DbSet<Renewal> Renewals { get; set; }
        public DbSet<Scenic> Scenics { get; set; }
        #endregion

        #region 用户与角色相关
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        #endregion


        /// <summary>
        /// 如果不需要 DbSet<T> 所定义的属性名称作为数据库表的名称，可以在下面的位置自己重新定义
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
