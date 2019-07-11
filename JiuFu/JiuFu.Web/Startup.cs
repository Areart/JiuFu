using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiuFu.DataAccess;
using JiuFu.Entities;
using JiuFu.ORM.SqlServer;
using JiuFu.UserAndRole;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JiuFu.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {  
            // 配置使用 Sql Server 的 EF Context
            services.AddDbContext<SqlServerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ELearningConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                //.AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<SqlServerDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                options.LoginPath = "/Account/Logon";
                options.AccessDeniedPath = "/Account/AccessDenied";
                //options.SlidingExpiration = true;
            });

            // 限制表单上传字节大小，600 兆
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = 1000000000;
            });
            services.AddScoped<IEntityRepository<Commodity>, EntityRepository<Commodity>>();
            services.AddScoped<IEntityRepository<CommodityOrder>, EntityRepository<CommodityOrder>>();
            services.AddScoped<IEntityRepository<Flavor>, EntityRepository<Flavor>>();
            services.AddScoped<IEntityRepository<Food>, EntityRepository<Food>>();
            services.AddScoped<IEntityRepository<FoodClass>, EntityRepository<FoodClass>>();
            services.AddScoped<IEntityRepository<FoodOrder>, EntityRepository<FoodOrder>>();
            services.AddScoped<IEntityRepository<Goods>, EntityRepository<Goods>>();
            services.AddScoped<IEntityRepository<GoodsOrder>, EntityRepository<GoodsOrder>>();
            services.AddScoped<IEntityRepository<Laundry>, EntityRepository<Laundry>>();
            services.AddScoped<IEntityRepository<LaundryOrder>, EntityRepository<LaundryOrder>>();
            services.AddScoped<IEntityRepository<Entertainment>, EntityRepository<Entertainment>>();
            services.AddScoped<IEntityRepository<Renewal>, EntityRepository<Renewal>>();
            services.AddScoped<IEntityRepository<Scenic>, EntityRepository<Scenic>>();
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
     .AddCookie();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
