using JiuFu.Entities;
using JiuFu.ORM.SqlServer;
using JiuFu.UserAndRole;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuFu.DataAccess.Seeds
{
    public static class ApplicationDataSeed
    {
        static SqlServerDbContext _dbContext;

        public static void ForEntities(SqlServerDbContext context)
        {
            _dbContext = context;
            _ForOrganAndJob();
        }
        /// <summary>
        /// 用户组
        /// </summary>
        public static async Task ForRolesAndUsers(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            #region 创建角色
            var role1 = new ApplicationRole()
            {
                Name = "普通注册用户",
                DisplayName = "普通注册用户",
                Description = "具备普通注册用户数据处理的用户组。",
                SortCode = "00001",
                ApplicationRoleType = ApplicationRoleTypeEnum.适用于普通注册用户,
                IsDefaultRole = true
            };

            var role2 = new ApplicationRole() { Name = "适用于送物服务员", DisplayName = "适用于送物服务员", Description = "具备接收送物信息的用户组。", SortCode = "00002", ApplicationRoleType = ApplicationRoleTypeEnum.适用于送物服务员, IsDefaultRole = true };
            var role3 = new ApplicationRole() { Name = "适用于送餐服务员", DisplayName = "适用于送餐服务员", Description = "具备接收送餐信息的用户组。", SortCode = "00003", ApplicationRoleType = ApplicationRoleTypeEnum.适用于送餐服务员, IsDefaultRole = true };
            var role4 = new ApplicationRole() { Name = "适用于厨师", DisplayName = "适用于厨师", Description = "具备接收食品订单的用户组。", SortCode = "00004", ApplicationRoleType = ApplicationRoleTypeEnum.适用于厨师, IsDefaultRole = true };
            var role5 = new ApplicationRole() { Name = "适用于清洁服务员", DisplayName = "适用于清洁服务员", Description = "具备接收保洁信息用户组。", SortCode = "00005", ApplicationRoleType = ApplicationRoleTypeEnum.适用于清洁服务员, IsDefaultRole = true };
            var role6 = new ApplicationRole() { Name = "适用于系统管理人员", DisplayName = "适用于系统管理人员", Description = "具备全部权限的用户组", SortCode = "00006", ApplicationRoleType = ApplicationRoleTypeEnum.适用于系统管理人员, IsDefaultRole = true };

            await roleManager.CreateAsync(role1);
            await roleManager.CreateAsync(role2);
            await roleManager.CreateAsync(role3);
            await roleManager.CreateAsync(role4);
            await roleManager.CreateAsync(role5);
            await roleManager.CreateAsync(role6);
            #endregion

            #region 创建普通用户
            for (int i = 0; i < 20; i++)
            {
                var counterString = i.ToString();
                if (i < 10)
                    counterString = "00" + i.ToString();
                if (i >= 10 && i < 100)
                    counterString = "0" + i.ToString();

                var normalUser = new ApplicationUser()
                {
                    UserName = "孙大头" + counterString,
                    Sex = true,
                    MobileNumber = "13988888888",
                    Email = "normal" + counterString + "@hotmail.com"
                };

                await userManager.CreateAsync(normalUser, "123@Abc");
                await userManager.AddToRoleAsync(normalUser, "普通注册用户");
            }
            #endregion

            #region 创建系统管理员用户
            var systemAdministrator = new ApplicationUser()
            {
                UserName = "admin",
                MobileNumber = "13617808232",
                Email = "admin@hotmail.com",
            };

            await userManager.CreateAsync(systemAdministrator, "1234@Abcd");
            await userManager.AddToRoleAsync(systemAdministrator, "管理员用户组");
            #endregion

            #region 送餐服务员
            var informationIssuer = new ApplicationUser()
            {
                UserName = "issuer",
                MobileNumber = "13617808232",
                Email = "issuer@hotmail.com"
            };

            await userManager.CreateAsync(informationIssuer, "123@Abc");
            await userManager.AddToRoleAsync(informationIssuer, "适用于送餐服务员");
            #endregion

            #region 创建送物服务员
            var educationalAdministrators = new ApplicationUser()
            {
                UserName = "fox",
                MobileNumber = "13617808232",
                Email = "huangdl@outlook.com"
            };

            await userManager.CreateAsync(educationalAdministrators, "123@Abc");
            await userManager.AddToRoleAsync(educationalAdministrators, "适用于送物服务员");
            #endregion

            #region 创建厨师用户
            var teacher = new ApplicationUser()
            {
                UserName = "teacher",
                MobileNumber = "13617808232",
                Email = "teacher@hotmail.com"
            };

            await userManager.CreateAsync(teacher, "123@Abc");
            await userManager.AddToRoleAsync(teacher, "适用于厨师");
            #endregion

            #region 创建清洁用户
            var student = new ApplicationUser()
            {
                UserName = "student",
                MobileNumber = "13617808232",
                Email = "student@hotmail.com"
            };

            await userManager.CreateAsync(student, "123@Abc");
            await userManager.AddToRoleAsync(student, "适用于清洁服务员");
            #endregion
        }



        private static void _ForOrganAndJob()
        {
           
                var dept = _dbContext.Commoditys.FirstOrDefault();
                var commoditys = new List<Commodity>()
                {
                    new Commodity (){ Name="福山咖啡",Price="100",Detail="澄迈县福山镇是海南最早种植咖啡的地方，经过半个多世纪的发展，目前，福山咖啡文化游已成为澄迈旅游一个新的增长点，日益呈现出多样化发展的咖啡馆业，又为福山经济增添了新的名片",SaleState=SaleState.售卖中,picture="/Images/054.png" },
                    new Commodity (){ Name="三亚芒果",Price="50",Detail="著名的热带水果，是与柑桔、香蕉、葡萄、苹果并列的世界五大水果之一，它有“热带果王”之美称。，",SaleState=SaleState.售卖中,picture="/Images/056.png" },
                    new Commodity (){ Name="文昌鸡",Price="100",Detail="文昌鸡是海南省的地方鸡种，已有400多年的养殖历史，具有皮薄嫩滑、肉味馥香的特点。 ，",SaleState=SaleState.售卖中,picture="/Images/053.png" },
                    new Commodity (){ Name="黎锦",Price="90",Detail="海南岛黎族民间织锦。有悠久的历史。产于海南岛的黎族居住区，《峒溪纤志》载：“黎人取中国彩帛，拆取色丝和吉贝，织之成锦。”范成大《桂海虞衡志》记载的“黎单”，“黎幕”宋代已远销大陆，“桂林人悉买以为卧具”。",SaleState=SaleState.售卖中,picture="/Images/052.png" },
                    new Commodity (){ Name="椰雕",Price="200",Detail="椰雕是以椰壳、椰棕、椰木为原料，用手工雕刻成各种实用产品和造型艺术品 [1]  。椰雕是海南岛的特产之一。椰雕因旧时官吏常以它进贡朝廷而得“天南贡品”之誉。",SaleState=SaleState.售卖中,picture="/Images/055.png" },
                    new Commodity (){ Name="南汉草席",Price="110",Detail="海南省琼海南汉特产。以美观大方、、凉爽舒适、结实耐用而闻名遐迩。",SaleState=SaleState.售卖中,picture="/Images/051.png" }
                };
                foreach (var person in commoditys)
                {
                    _dbContext.Commoditys.Add(person);
                }
                _dbContext.SaveChanges();         

           
                var foodClass = new List<FoodClass>()
                {
                new FoodClass() { Name="中餐"},
                new FoodClass() { Name="西餐"},
                new FoodClass() { Name="饮品"},
                new FoodClass() { Name="水果"},
                new FoodClass() { Name="甜点"}
                };
                foreach (var person in foodClass)
                {
                    _dbContext.FoodClass.Add(person);
                }
                _dbContext.SaveChanges();
          
            
                var flavor = new List<Flavor>()
                {
                new Flavor() { Name="度"},
                new Flavor() { Name="辣"},
                new Flavor() { Name="咸"},
                new Flavor() { Name="甜"},
                new Flavor() { Name="酸"}              
                };
                foreach (var person in flavor)
                {
                    _dbContext.Flavors.Add(person);
                }
                _dbContext.SaveChanges();
          
                var degree = new List<Degree>()
                {
                new Degree() { Name="微辣",Flavors=flavor.Single(s=>s.Name=="辣")},
                new Degree() { Name="中辣",Flavors=flavor.Single(s=>s.Name=="辣")},
                new Degree() { Name="特辣",Flavors=flavor.Single(s=>s.Name=="辣")},
                new Degree() { Name="微酸",Flavors=flavor.Single(s=>s.Name=="酸")},
                new Degree() { Name="中酸",Flavors=flavor.Single(s=>s.Name=="酸")},
                new Degree() { Name="特酸",Flavors=flavor.Single(s=>s.Name=="酸")},
                new Degree() { Name="微咸",Flavors=flavor.Single(s=>s.Name=="咸")},
                new Degree() { Name="中咸",Flavors=flavor.Single(s=>s.Name=="咸")},
                new Degree() { Name="特咸",Flavors=flavor.Single(s=>s.Name=="咸")},
                new Degree() { Name="微甜",Flavors=flavor.Single(s=>s.Name=="甜")},
                new Degree() { Name="中甜",Flavors=flavor.Single(s=>s.Name=="甜")},
                new Degree() { Name="特甜",Flavors=flavor.Single(s=>s.Name=="甜")},
                new Degree() { Name="小",Flavors=flavor.Single(s=>s.Name=="度")},
                new Degree() { Name="中",Flavors=flavor.Single(s=>s.Name=="度")},
                new Degree() { Name="大",Flavors=flavor.Single(s=>s.Name=="度")}
                };
                foreach (var person in degree)
                {
                    _dbContext.Degrees.Add(person);
                }
           
                var food = new List<Food>()
                {
                new Food() { Name="剁椒鱼头",Price="500",FoodClass=foodClass.Single(a=>a.Name=="中餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/DJYT.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="宫保鸡丁",Price="500",FoodClass=foodClass.Single(a=>a.Name=="中餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/GBJD.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="口水鸡",Price="500",FoodClass=foodClass.Single(a=>a.Name=="中餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/KSJ.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="水煮牛肉",Price="500",FoodClass=foodClass.Single(a=>a.Name=="中餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/SJNR.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="松鼠鱼",Price="500",FoodClass=foodClass.Single(a=>a.Name=="中餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/SSY.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="鱼香肉丝",Price="500",FoodClass=foodClass.Single(a=>a.Name=="中餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/YXRS.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="法式鹅肝",Price="500",FoodClass=foodClass.Single(a=>a.Name=="西餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/FSEG.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="法式烤羊排",Price="500",FoodClass=foodClass.Single(a=>a.Name=="西餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/FSKYP.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="黑椒牛肉",Price="500",FoodClass=foodClass.Single(a=>a.Name=="西餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/HJNP.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="奶油鸡肉蘑菇汤",Price="500",FoodClass=foodClass.Single(a=>a.Name=="西餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/JRT/dianc.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="水果沙拉",Price="500",FoodClass=foodClass.Single(a=>a.Name=="西餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/SGSL.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="意大利面",Price="500",FoodClass=foodClass.Single(a=>a.Name=="西餐"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/YDYM.jpg",Flavor=flavor.Single(s=>s.Name=="辣")},
                new Food() { Name="百岁山",Price="500",FoodClass=foodClass.Single(a=>a.Name=="饮品"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/BSS.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="可乐",Price="500",FoodClass=foodClass.Single(a=>a.Name=="饮品"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/KL.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="里鹏葡萄酒",Price="500",FoodClass=foodClass.Single(a=>a.Name=="饮品"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/KYXB.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="茅台白酒",Price="500",FoodClass=foodClass.Single(a=>a.Name=="饮品"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/MT.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="酩悦香槟",Price="500",FoodClass=foodClass.Single(a=>a.Name=="饮品"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/LP.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="薇吉伍德咖啡",Price="500",FoodClass=foodClass.Single(a=>a.Name=="饮品"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/MSKF.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                 new Food() { Name="哈密瓜",Price="500",FoodClass=foodClass.Single(a=>a.Name=="水果"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/HMG.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="苹果",Price="500",FoodClass=foodClass.Single(a=>a.Name=="水果"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/PG.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="提子",Price="500",FoodClass=foodClass.Single(a=>a.Name=="水果"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/TZ.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="西瓜",Price="500",FoodClass=foodClass.Single(a=>a.Name=="水果"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/XG.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="樱桃",Price="500",FoodClass=foodClass.Single(a=>a.Name=="水果"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/YT.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="火龙果",Price="500",FoodClass=foodClass.Single(a=>a.Name=="水果"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/HLG.jpg",Flavor=flavor.Single(s=>s.Name=="度")},
                new Food() { Name="冰淇淋",Price="500",FoodClass=foodClass.Single(a=>a.Name=="甜点"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/BQL.jpg",Flavor=flavor.Single(s=>s.Name=="甜")},
                new Food() { Name="布丁",Price="500",FoodClass=foodClass.Single(a=>a.Name=="甜点"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/BD.jpg",Flavor=flavor.Single(s=>s.Name=="甜")},
                new Food() { Name="蛋糕",Price="500",FoodClass=foodClass.Single(a=>a.Name=="甜点"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/DG.jpg",Flavor=flavor.Single(s=>s.Name=="甜")},
                new Food() { Name="奶油甜甜圈",Price="500",FoodClass=foodClass.Single(a=>a.Name=="甜点"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/TTQ.jpg",Flavor=flavor.Single(s=>s.Name=="甜")},
                new Food() { Name="苹果派",Price="500",FoodClass=foodClass.Single(a=>a.Name=="甜点"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/PGP.jpg",Flavor=flavor.Single(s=>s.Name=="甜")},
                new Food() { Name="芋圆",Price="500",FoodClass=foodClass.Single(a=>a.Name=="甜点"),Detail="通常以鳙鱼鱼头、剁椒为主料，配以豉油、姜、葱、蒜等辅料蒸制而成。菜品色泽红亮、味浓、肉质细嫩。肥而不腻、口感软糯、鲜辣适口。",SaleState=SaleState.售卖中,picture="/Images/YY.jpg",Flavor=flavor.Single(s=>s.Name=="甜")}
                };
                foreach (var person in food)
                {
                    _dbContext.Foods.Add(person);
                }
                _dbContext.SaveChanges();          
          
                var goods = new List<Goods>()
                {
                new Goods() { Name="毛巾",Price="10",Detail="毛巾是一种清洁用品，特征为方形纯棉纺织品，使用方法为打湿后拧干擦拭皮肤，以达到去除污渍、清洁凉爽的效果。",picture="/Images/002.png"},
                new Goods() { Name="牙刷",Price="10",Detail="牙刷是一种清洁用品，为手柄式刷子，用于在刷子上添加牙膏，然后反复刷洗牙齿各个部位。",picture="/Images/10.png"},
                new Goods() { Name="吹风筒",Price="10",Detail="吹风筒能够短时间帮助人们头发吹干,是非常常见的智能科技产品。",picture="/Images/11.png"},
                new Goods() { Name="浴巾",Price="10",Detail="浴巾是一种清洁用品，属于毛巾的一个种类，由棉纤维纺织而成，用于洗澡后擦身、遮体和保暖。",picture="/Images/12.png"},
                new Goods() { Name="纸笔",Price="10",Detail="提供各式各样的笔给用户所需要的来选择。",picture="/Images/13.png"},
                 new Goods() { Name="充电器",Price="10",Detail="提供多种的手机笔记本电脑充电器给用户所需要的来选择。",picture="/Images/14.png"}
                };
                foreach (var person in goods)
                {
                    _dbContext.Goodss.Add(person);
                }
                _dbContext.SaveChanges();
          
                var laundry = new List<Laundry>()
                {
                new Laundry() { Mode="水洗",Price="500"},
                new Laundry() { Mode="干洗",Price="500"}
                };
                foreach (var person in laundry)
                {
                    _dbContext.Laundrys.Add(person);
                }
                _dbContext.SaveChanges();
            
                var entertainment = new List<Entertainment>()
                {
                new Entertainment() { Name="游泳池",Position="5F",Date="早上8点-晚上10点",Detail="舒适宜人,能在四季安全享受的室内游泳池XX酒店世界室内 游泳池的面积达到20mx8m,水深为1.2m~1.6m,以overflow方式的特殊过滤系统,确保清澈干净的水质.",picture="/Images/1.jpg"},
                new Entertainment() { Name="健身房",Position="XX酒店2F",Date="早上8:00-晚上22:00",Detail="机器设备比较齐全,室内空气通风,健身房运行环境和专业的教练 使你的健身效果事半功陪，专业、诚信、服务是永远求。我们真诚的祝福每一个人:澎湃生命活力，快乐健康生活.",picture="/Images/2.jpg"},
                new Entertainment() { Name="棋牌室",Position="1F",Date="早上8:00-晚上22:00",Detail="你可以选择以下娱乐项目:麻将、扑克牌、牌九、百家乐、象棋、 围棋、五子棋、黑白棋等。花样多，让你玩得开心.",picture="/Images/4.jpg"},
                new Entertainment() { Name="球馆",Position="XX酒店高尔夫球场",Date="早上8:00-晚上22:00",Detail="占地面积1000到2000亩左右的球场,附近有室内练习场、 人工湖、观赛区,小卖部等其他娱乐项目.",picture="/Images/3.jpg"},
                new Entertainment() { Name="电影厅",Position="3F",Date="周一至周五8:00-22:00 周末8:00-00:30",Detail="健康时尚的欢唱环境,为您精心打造全新五星级的欢唱体验,一流的业务素质和优质的服务水平.",picture="/Images/5.jpg"},
                  new Entertainment() { Name="KTV",Position="4F",Date="周一至周五8:00-22:00 周末8:00-23:30",Detail="2、3D的电影厅,可以观看到不同的视野,带你走进不一样的世界.你可以看到最新的电影、经典的电影、只要你想看我们就给你播放.",picture="/Images/6.jpg"}
                };
                foreach (var person in entertainment)
                {
                    _dbContext.Entertainments.Add(person);
                }
                _dbContext.SaveChanges();
          
                var scenic = new List<Scenic>()
                {
                new Scenic() { Name="公园",Position="海南省海口市西南石山镇",Date="全天",Detail="海口市西南石山镇,距市区仅15公里,西线高速公路 转绿色长廊可达,绕城高速公路穿过园区。占地108平方公里,是(世界)国家地质公园4A级景区.",picture="/Images/01.png"},
                new Scenic() { Name="海底世界",Position="海南三亚",Date="早上8点-晚上17点",Detail=" 海底世界半潜观光、深海潜水摩托、香蕉船、拖曳伞、徒手潜水、 玻璃观光船、快艇观光、摩托艇、冲浪飞车、沙滩摩托车、沙滩浴场等娱乐项目。清澈的海水里，生活着世界 上保护最完整的、种类繁多的硬珊瑚和软珊瑚，还有摇曳多姿的藻类植物,追来逐去的庞大鱼群,海蛇、海胆、海星.",picture="/Images/02.png"},
                new Scenic() { Name="蜈支洲岛",Position="三亚市北部的海棠湾内",Date="早上10点-晚上10点",Detail="蜈支洲岛为国家AAAAA级景区,又名”情人岛“, 具有得天独厚的潜水条件,被誉为国内优质潜水胜地,拥有30余项海路项目,独创”海底、水上、 空中、陆地“四栖游玩体验.",picture="/Images/03.png"},
                new Scenic() { Name="大小洞天",Position="三亚市南山",Date="早上9:00-晚上17:00",Detail=" 三亚市南山大小洞天风景区(原海山奇观风景区、 古称鳌山大小洞天),位于三亚市区以西40公里的海滨,总面积22.5平方公里,景区已有800 多年历史。大小洞天风景区以其秀丽的海景、山景和石景号称琼崖第一山水名胜.",picture="/Images/04.png"},
                new Scenic() { Name="旅游区",Position="三亚市",Date="旅游观光双层巴士(发车时间:首班06:00,每半小时一班,末班18:40",Detail="亚龙湾旅游区集中了现代旅游五大要素:海洋、沙滩、阳光、绿色、新鲜空气于一体,呈现明显的 热带海洋性气候,全年平均气温25.5℃,冬季海水最低温度22度,适宜四季游泳和开展各类海上运动。这里海湾面积达66平方公里,可同时容纳 十万人嬉水畅游,数千只游艇游弋追逐。这里如诗如画的自然风光、舒适完善的旅游度假设施和独具特色的旅游项目已成为旅游者向往的度假天堂.",picture="/Images/05.png"},
                new Scenic() { Name="植物园",Position="海南省兴隆温泉旅游区内",Date="早上7:30-晚上18点",Detail="植物园占地 600多亩,植物品种2300多,植物园拥有热带经济作物、 林木及园艺植物品种,保存有野生植物资源和珍稀物种,引进国内外名贵的热带植物种类,合理配置,结合林草等 优美景观的相间布局.",picture="/Images/06.png"}
                };
                foreach (var person in scenic)
                {
                    _dbContext.Scenics.Add(person);
                }
                _dbContext.SaveChanges();           
        }
    }

}
