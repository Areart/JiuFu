using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JiuFu.DataAccess.Seeds;
using JiuFu.Entities;
using JiuFu.ORM.SqlServer;
using JiuFu.UserAndRole;
using JiuFu.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JiuFu.Web.Controllers
{
    public class BackstageController : Controller
    {
        private readonly SqlServerDbContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        public BackstageController(SqlServerDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;
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
            if (user != null || await _userManager.IsInRoleAsync(user, "适用于系统管理人员"))
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
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Password", "你输入的用户密码错误，请核实后重新输入。");
                    return View(User);
                }
            }

            return View();
        }

        #region 送物
        public async Task<IActionResult> GoodsIndex(string searchString)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                var good = await _context.Goodss.ToArrayAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    good = await _context.Goodss.Where(x => x.Name.Contains(searchString)).OrderBy(x => x.Name).ToArrayAsync();

                }
                return View(good);


            }
            return RedirectToAction("Login");
        }
        public IActionResult GoodsCreate()
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

        // POST: Goods1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GoodsCreate([Bind("Id,Name,Price,Detail,picture")] Goods goods)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                var files = Request.Form.Files;
                if (ModelState.IsValid)
                {

                    goods.Id = Guid.NewGuid();
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    if (files.Count > 0)
                    {
                        int g = files[0].FileName.LastIndexOf(".");
                        string newFileName = goods.Id.ToString() + files[0].FileName.Substring(g);
                        var filePath = webRootPath + "/Images/" + newFileName;
                        goods.picture = "/Images/" + newFileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await files[0].CopyToAsync(stream);
                        }
                    }
                    _context.Add(goods);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(GoodsIndex));
                }
                return View(goods);


            }
            return RedirectToAction("Login");
        }


        public async Task<IActionResult> GoodsDetails(Guid? id)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var goods = await _context.Goodss
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (goods == null)
                {
                    return NotFound();
                }

                return View(goods);

            }
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> GoodsEdit(Guid? id)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var goods = await _context.Goodss.FindAsync(id);
                if (goods == null)
                {
                    return NotFound();
                }
                return View(goods);

            }
            return RedirectToAction("Login");
        }

        // POST: Goods1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GoodsEdit(Guid id, [Bind("Id,Name,Price,Detail,picture")] Goods goods)
        {


            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (id != goods.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        var files = Request.Form.Files;
                        if (files.Count != 0)
                        {
                            string webRootPath = _hostingEnvironment.WebRootPath;
                            int g = files[0].FileName.LastIndexOf(".");
                            string newFileName = goods.Id.ToString() + files[0].FileName.Substring(g);
                            var filePath = webRootPath + "/Images/" + newFileName;
                            goods.picture = "/Images/" + newFileName;
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await files[0].CopyToAsync(stream);
                            }
                        }
                        _context.Update(goods);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!GoodsExists(goods.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(GoodsIndex));
                }
                return View(goods);

            }
            return RedirectToAction("Login");
        }

        // GET: Goods1/Delete/5
        public async Task<IActionResult> GoodsDelete(Guid? id)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var goods = await _context.Goodss
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (goods == null)
                {
                    return NotFound();
                }

                _context.Goodss.Remove(goods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GoodsIndex));

            }
            return RedirectToAction("Login");
        }

        // POST: Goods1/Delete/5


        private bool GoodsExists(Guid id)
        {
            return _context.Goodss.Any(e => e.Id == id);

        }

        #endregion

        #region 周边


        // GET: Commodities
        public async Task<IActionResult> CommodityIndex(string searchString)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                var commodity = await _context.Commoditys.ToListAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    commodity = await _context.Commoditys.Where(x => x.Name.Contains(searchString)).OrderBy(x => x.Name).ToListAsync();

                }
                return View(commodity);

            }
            return RedirectToAction("Login");
        }

        // GET: Commodities/Details/5
        public async Task<IActionResult> CommodityDetails(Guid? id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var commodity = await _context.Commoditys
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (commodity == null)
                {
                    return NotFound();
                }

                return View(commodity);

            }
            return RedirectToAction("Login");
        }

        // GET: Commodities/Create
        public IActionResult CommodityCreate()
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

        // POST: Commodities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommodityCreate([Bind("Id,Name,Price,Detail,SaleState,picture")] Commodity commodity)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    commodity.Id = Guid.NewGuid();
                    var files = Request.Form.Files;
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    if (files.Count > 0)
                    {
                        int g = files[0].FileName.LastIndexOf(".");
                        string newFileName = commodity.Id.ToString() + files[0].FileName.Substring(g);
                        var filePath = webRootPath + "/Images/" + newFileName;
                        commodity.picture = "/Images/" + newFileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await files[0].CopyToAsync(stream);
                        }
                    }
                    _context.Add(commodity);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(CommodityIndex));
                }
                return View(commodity);
            }
            return RedirectToAction("Login");
        }

        // GET: Commodities/Edit/5
        public async Task<IActionResult> CommodityEdit(Guid? id)
        {


            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var commodity = await _context.Commoditys.FindAsync(id);
                if (commodity == null)
                {
                    return NotFound();
                }
                return View(commodity);
            }
            return RedirectToAction("Login");
        }

        // POST: Commodities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommodityEdit(Guid id, [Bind("Id,Name,Price,Detail,SaleState,picture")] Commodity commodity)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (id != commodity.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        var files = Request.Form.Files;
                        if (files.Count != 0)
                        {
                            string webRootPath = _hostingEnvironment.WebRootPath;
                            int g = files[0].FileName.LastIndexOf(".");
                            string newFileName = commodity.Id.ToString() + files[0].FileName.Substring(g);
                            var filePath = webRootPath + "/Images/" + newFileName;
                            commodity.picture = "/Images/" + newFileName;
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await files[0].CopyToAsync(stream);
                            }
                        }
                        _context.Update(commodity);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CommodityExists(commodity.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(CommodityIndex));
                }
                return View(commodity);

            }
            return RedirectToAction("Login");
        }

        // GET: Commodities/Delete/5
        public async Task<IActionResult> CommodityDelete(Guid? id)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var commodity = await _context.Commoditys
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (commodity == null)
                {
                    return NotFound();
                }

                _context.Commoditys.Remove(commodity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CommodityIndex));
            }
            return RedirectToAction("Login");
        }

        private bool CommodityExists(Guid id)
        {
            return _context.Commoditys.Any(e => e.Id == id);
        }
        #endregion


        #region 景点

        public async Task<IActionResult> ScenicIndex(string searchString)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                var Scenic = await _context.Scenics.ToListAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    Scenic = await _context.Scenics.Where(x => x.Name.Contains(searchString)).OrderBy(x => x.Name).ToListAsync();

                }
                return View(Scenic);
            }
            return RedirectToAction("Login");
        }

        // GET: Scenics1/Details/5
        public async Task<IActionResult> ScenicDetails(Guid? id)
        {


            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var scenic = await _context.Scenics
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (scenic == null)
                {
                    return NotFound();
                }

                return View(scenic);
            }
            return RedirectToAction("Login");
        }

        // GET: Scenics1/Create
        public IActionResult ScenicCreate()
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

        // POST: Scenics1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ScenicCreate([Bind("Id,Name,Position,Date,Detail,picture")] Scenic scenic)
        {


            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    scenic.Id = Guid.NewGuid();
                    var files = Request.Form.Files;
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    if (files.Count > 0)
                    {
                        int g = files[0].FileName.LastIndexOf(".");
                        string newFileName = scenic.Id.ToString() + files[0].FileName.Substring(g);
                        var filePath = webRootPath + "/Images/" + newFileName;
                        scenic.picture = "/Images/" + newFileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await files[0].CopyToAsync(stream);
                        }
                    }
                    _context.Add(scenic);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ScenicIndex));
                }
                return View(scenic);
            }
            return RedirectToAction("Login");
        }

        // GET: Scenics1/Edit/5
        public async Task<IActionResult> ScenicEdit(Guid? id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var scenic = await _context.Scenics.FindAsync(id);
                if (scenic == null)
                {
                    return NotFound();
                }
                return View(scenic);
            }
            return RedirectToAction("Login");
        }

        // POST: Scenics1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ScenicEdit(Guid id, [Bind("Id,Name,Position,Date,Detail,picture")] Scenic scenic)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (id != scenic.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        var files = Request.Form.Files;
                        if (files.Count != 0)
                        {
                            string webRootPath = _hostingEnvironment.WebRootPath;
                            int g = files[0].FileName.LastIndexOf(".");
                            string newFileName = scenic.Id.ToString() + files[0].FileName.Substring(g);
                            var filePath = webRootPath + "/Images/" + newFileName;
                            scenic.picture = "/Images/" + newFileName;
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await files[0].CopyToAsync(stream);
                            }
                        }
                        _context.Update(scenic);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ScenicExists(scenic.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(ScenicIndex));
                }
                return View(scenic);
            }
            return RedirectToAction("Login");
        }

        // GET: Scenics1/Delete/5
        public async Task<IActionResult> ScenicDelete(Guid? id)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var scenic = await _context.Scenics
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (scenic == null)
                {
                    return NotFound();
                }

                _context.Scenics.Remove(scenic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ScenicIndex));
            }
            return RedirectToAction("Login");
        }

        private bool ScenicExists(Guid id)
        {
            return _context.Scenics.Any(e => e.Id == id);
        }

        #endregion

        #region 娱乐

        public async Task<IActionResult> EntertainmentsIndex(string searchString)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                var Entertainments = await _context.Entertainments.ToListAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    Entertainments = await _context.Entertainments.Where(x => x.Name.Contains(searchString)).OrderBy(x => x.Name).ToListAsync();

                }
                return View(Entertainments);
            }
            return RedirectToAction("Login");
        }

        // GET: Entertainments1/Details/5
        public async Task<IActionResult> EntertainmentsDetails(Guid? id)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var entertainment = await _context.Entertainments
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (entertainment == null)
                {
                    return NotFound();
                }

                return View(entertainment);
            }
            return RedirectToAction("Login");
        }

        // GET: Entertainments1/Create
        public IActionResult EntertainmentsCreate()
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

        // POST: Entertainments1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EntertainmentsCreate([Bind("Id,Name,Position,Date,Detail,picture")] Entertainment entertainment)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    entertainment.Id = Guid.NewGuid();
                    var files = Request.Form.Files;
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    if (files.Count > 0)
                    {
                        int g = files[0].FileName.LastIndexOf(".");
                        string newFileName = entertainment.Id.ToString() + files[0].FileName.Substring(g);
                        var filePath = webRootPath + "/Images/" + newFileName;
                        entertainment.picture = "/Images/" + newFileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await files[0].CopyToAsync(stream);
                        }
                    }
                    _context.Add(entertainment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(EntertainmentsIndex));
                }
                return View(entertainment);
            }
            return RedirectToAction("Login");
        }

        // GET: Entertainments1/Edit/5
        public async Task<IActionResult> EntertainmentsEdit(Guid? id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var entertainment = await _context.Entertainments.FindAsync(id);
                if (entertainment == null)
                {
                    return NotFound();
                }
                return View(entertainment);
            }
            return RedirectToAction("Login");
        }

        // POST: Entertainments1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EntertainmentsEdit(Guid id, [Bind("Id,Name,Position,Date,Detail,picture")] Entertainment entertainment)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (id != entertainment.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        var files = Request.Form.Files;
                        if (files.Count != 0)
                        {
                            string webRootPath = _hostingEnvironment.WebRootPath;
                            int g = files[0].FileName.LastIndexOf(".");
                            string newFileName = entertainment.Id.ToString() + files[0].FileName.Substring(g);
                            var filePath = webRootPath + "/Images/" + newFileName;
                            entertainment.picture = "/Images/" + newFileName;
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await files[0].CopyToAsync(stream);
                            }
                        }
                        _context.Update(entertainment);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EntertainmentExists(entertainment.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(EntertainmentsIndex));
                }
                return View(entertainment);
            }
            return RedirectToAction("Login");
        }

        // GET: Entertainments1/Delete/5
        public async Task<IActionResult> EntertainmentsDelete(Guid? id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var entertainment = await _context.Entertainments
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (entertainment == null)
                {
                    return NotFound();
                }

                _context.Entertainments.Remove(entertainment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(EntertainmentsIndex));
            }
            return RedirectToAction("Login");
        }
        private bool EntertainmentExists(Guid id)
        {
            return _context.Entertainments.Any(e => e.Id == id);
        }

        #endregion

        #region 洗衣

        public async Task<IActionResult> LaundryIndex(string searchString)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                var Laundry = await _context.Laundrys.ToListAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    Laundry = await _context.Laundrys.Where(x => x.Mode.Contains(searchString)).OrderBy(x => x.Mode).ToListAsync();

                }
                return View(Laundry);
            }
            return RedirectToAction("Login");
        }

        // GET: Laundries/Details/5
        public async Task<IActionResult> LaundryDetails(Guid? id)
        {


            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var laundry = await _context.Laundrys
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (laundry == null)
                {
                    return NotFound();
                }

                return View(laundry);
            }
            return RedirectToAction("Login");
        }

        // GET: Laundries/Create
        public IActionResult LaundryCreate()
        {
            var u = HttpContext.User.Claims.First().Value;
            var users = _context.ApplicationUsers.Find(Guid.Parse(u));
            ViewBag.User = users;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        // POST: Laundries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LaundryCreate([Bind("Id,Mode,Price")] Laundry laundry)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    laundry.Id = Guid.NewGuid();
                    _context.Add(laundry);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(LaundryIndex));
                }
                return View(laundry);
            }
            return RedirectToAction("Login");
        }

        // GET: Laundries/Edit/5
        public async Task<IActionResult> LaundryEdit(Guid? id)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var laundry = await _context.Laundrys.FindAsync(id);
                if (laundry == null)
                {
                    return NotFound();
                }
                return View(laundry);
            }
            return RedirectToAction("Login");
        }

        // POST: Laundries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LaundryEdit(Guid id, [Bind("Id,Mode,Price")] Laundry laundry)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {

                if (id != laundry.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {

                        _context.Update(laundry);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LaundryExists(laundry.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(LaundryIndex));
                }
                return View(laundry);

            }
            return RedirectToAction("Login");
        }

        // GET: Laundries/Delete/5
        public async Task<IActionResult> LaundryDelete(Guid? id)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var laundry = await _context.Laundrys
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (laundry == null)
                {
                    return NotFound();
                }

                _context.Laundrys.Remove(laundry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(LaundryIndex));
            }
            return RedirectToAction("Login");
        }

        private bool LaundryExists(Guid id)
        {
            return _context.Laundrys.Any(e => e.Id == id);
        }

        #endregion

        #region 员工管理

        public async Task<IActionResult> PersonnelIndex()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                List<ApplicationUser> user = await _context.ApplicationUsers.ToListAsync();
                List<PersonnelVM> pvm = new List<PersonnelVM>();
                foreach (var us in user)
                {
                    var ap = await _userManager.GetRolesAsync(us);
                    string aw = ap.First().ToString();
                    if (aw == "普通注册用户")
                    {
                        continue;
                    }
                    pvm.Add(new PersonnelVM
                    {
                        Id = us.Id,
                        Name = us.Name,
                        Birthday = us.Birthday,
                        MobileNumber = us.MobileNumber,
                        Sex = us.Sex,                      
                        Email = us.Email,
                        ApplicationRoleType = ap.First().ToString()
                    });
                }
                return View(pvm);
            }
            return RedirectToAction("Login");
        }
        public IActionResult PersonnelCreate()
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

        // POST: Laundries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]       
        public async Task<IActionResult> PersonnelCreate(UserAdd user)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
             
                    ApplicationUser user1 = new ApplicationUser()
                    {
                        Id = Guid.NewGuid(),
                        Name = user.Name,
                        Sex = user.Sex,                    
                        Birthday = user.Birthday,
                        UserName = user.UserName,
                        Email = user.Email,
                        floor=user.floor,
                        MobileNumber = user.MobileNumber
                    };
                    var files = Request.Form.Files;
                    if (files.Count != 0)
                    {
                        string webRootPath = _hostingEnvironment.WebRootPath;
                        int g = files[0].FileName.LastIndexOf(".");
                        string newFileName = user1.Id.ToString() + files[0].FileName.Substring(g);
                        var filePath = webRootPath + "/Images/" + newFileName;
                        user1.AvatarPath = "/Images/" + newFileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await files[0].CopyToAsync(stream);
                        }
                    }
                    await _userManager.CreateAsync(user1, user.PasswordComfirm);
                    await _userManager.AddToRoleAsync(user1, user.ApplicationRoleType);
                    return RedirectToAction(nameof(PersonnelIndex));                   
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> PersonnelDetails(Guid? id)
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var applicationUserss = await _context.ApplicationUsers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (applicationUserss == null)
                {
                    return NotFound();
                }

                return View(applicationUserss);
            }
            return RedirectToAction("Login");
        }

        // GET: Entertainments1/Edit/5
        public async Task<IActionResult> PersonnelEdit(Guid? id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var applicationUser = await _context.ApplicationUsers.FindAsync(id);
                if (applicationUser == null)
                {
                    return NotFound();
                }
                PeersenVM personnel = new PeersenVM() { Id=applicationUser.Id,UserName=applicationUser.UserName,Name=applicationUser.Name,Birthday=applicationUser.Birthday,Email=applicationUser.Email,Sex=applicationUser.Sex,MobileNumber=applicationUser.MobileNumber };
                return View(personnel);
            }
            return RedirectToAction("Login");
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]      
        public async Task<IActionResult> PersonnelEdit(Guid id, PeersenVM user)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id != user.Id)
                {
                    return NotFound();
                }
                
                    try
                    {
                        ApplicationUser user1 = _context.ApplicationUsers.Find(id);

                        user1.Id = id;
                        user1.Name = user.Name;
                        user1.Sex = user.Sex;
                        user1.Birthday = user.Birthday;
                        user1.UserName = user.UserName;
                        user1.Email = user.Email;
                        user1.floor = user.Floor;
                        user1.MobileNumber = user.MobileNumber;                        
                        var files = Request.Form.Files;
                        if (files.Count != 0)
                        {
                            string webRootPath = _hostingEnvironment.WebRootPath;
                            int g = files[0].FileName.LastIndexOf(".");
                            string newFileName = user1.Id.ToString() + files[0].FileName.Substring(g);
                            var filePath = webRootPath + "/Images/" + newFileName;
                            user1.AvatarPath = "/Images/" + newFileName;
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await files[0].CopyToAsync(stream);
                            }
                        }
                        _context.Update(user1);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ApplicationUserExists(user.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(PersonnelIndex));              
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> PersonnelDelete(Guid? id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var u = HttpContext.User.Claims.First().Value;
                var users = _context.ApplicationUsers.Find(Guid.Parse(u));
                ViewBag.User = users;
                if (id == null)
                {
                    return NotFound();
                }

                var applicationUser = await _context.ApplicationUsers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (applicationUser == null)
                {
                    return NotFound();
                }
                _context.ApplicationUsers.Remove(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PersonnelIndex));               
            }
            return RedirectToAction("Login");
        }
        private bool ApplicationUserExists(Guid id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
        #endregion
    }
}