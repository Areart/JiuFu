using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JiuFu.Web.Models;
using JiuFu.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using JiuFu.UserAndRole;
using JiuFu.DataAccess.Seeds;
using JiuFu.ORM.SqlServer;

namespace JiuFu.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SqlServerDbContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;      
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public  HomeController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, SqlServerDbContext context)
        {
             _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
            public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                return View();
            }
            return RedirectToAction("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginVM User)
        {


            var defaultRole = _roleManager.Roles.FirstOrDefault(x => x.ApplicationRoleType == ApplicationRoleTypeEnum.适用于普通注册用户);
            if (defaultRole == null)
            {
                await ApplicationDataSeed.ForRolesAndUsers(_roleManager, _userManager);
            }


            var user = await _userManager.FindByNameAsync(User.UserName);
            if (user != null)
            {

                // 登录系统             
                var result = await _signInManager.PasswordSignInAsync(user, User.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var claims = new List<Claim>();
                    //创建声明，并加入声明组。声明的类型是Name， 值是小明，证书发布者是contoso
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    //创建用户身份SuperSecureLogin
                    var userIdentity = new ClaimsIdentity("SuperSecureLogin");
                    //将声明组加入用户身份userIdentity
                    userIdentity.AddClaims(claims);
                    //创建身份当事者
                    var userPrincipal = new ClaimsPrincipal(userIdentity);
                    //创建身份认证Cookie
                    await HttpContext.SignInAsync(
                        //默认Cookie认证
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        //身份证当事者
                        userPrincipal,
                        //设置认证属性                
                        new AuthenticationProperties
                        {
                            //cookie 到期时间
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                            //永久 cookie
                            IsPersistent = false,
                            //允许刷新认证Session
                            AllowRefresh = false
                        });
                    if (await _userManager.IsInRoleAsync(user, "普通注册用户")&& User.UserRole== "普通注册用户")
                    {
                        return RedirectToAction("Index");
                    }
                   
                }
                else
                {
                    ModelState.AddModelError("Password", "你输入的用户密码错误，请核实后重新输入。");
                    return View(User);
                }
            }

            return View();
        }

        public IActionResult Register()
        {
                return View();         
        }

        // POST: Laundries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Register(UserAdd user)
        {

                ApplicationUser user1 = new ApplicationUser()
                {
                    Id = Guid.NewGuid(),                
                    UserName = user.UserName,
                    Email = user.Email,
                    floor = user.floor,
                    MobileNumber = user.MobileNumber
                };               
                await _userManager.CreateAsync(user1, user.PasswordComfirm);
                await _userManager.AddToRoleAsync(user1, "普通注册用户");
                return RedirectToAction(nameof(Login));
          
           
        }
    }
}
