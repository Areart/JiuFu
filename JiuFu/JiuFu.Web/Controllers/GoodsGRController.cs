using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JiuFu.Entities;
using JiuFu.ORM.SqlServer;
using JiuFu.Web.Models;

namespace JiuFu.Web.Controllers
{
    public class GoodsGRController : Controller
    {
        private readonly SqlServerDbContext _context;

        public GoodsGRController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: GoodsGR
        public IActionResult Index()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();
            foreach (var i in _context.FoodOrders)
            {
                var food = _context.Foods.Find(i.FoodId);
                orders.Add(new OrderViewModel { Name=food.Name,Peice=(double.Parse(i.Number)* double.Parse(food.Price)).ToString(),picture=food.picture,CLass="食物" ,Id=i.Id ,OrderStatus=i.OrderStatus});
            }
            foreach (var i in _context.GoodsOrders)
            {
                var good = _context.Goodss.Find(i.GoodsId);
                orders.Add(new OrderViewModel { Name = good.Name, Peice = (double.Parse(i.Number) * double.Parse(good.Price)).ToString(), picture = good.picture,CLass="生活用品" ,Id=i.Id, OrderStatus = i.OrderStatus });
            }
            foreach (var i in _context.CommodityOrders)
            {
                var commodidty = _context.Commoditys.Find(i.CommoditysId);
                orders.Add(new OrderViewModel { Name = commodidty.Name, Peice = (double.Parse(i.Number) * double.Parse(commodidty.Price)).ToString(), picture = commodidty.picture, CLass = "周边商品", Id = i.Id, OrderStatus = i.OrderStatus });
            }
            return View(orders);

            
            
        }

        // GET: GoodsGR/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.GoodsOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            var foods = await _context.FoodOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            var commodidtys = await _context.CommodityOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (foods != null)
            {
                var food = _context.Foods.Find(foods.FoodId);
                OrderViewModel order = new OrderViewModel() { Name = food.Name, Peice = (double.Parse(foods.Number) * double.Parse(food.Price)).ToString(), picture = food.picture, CLass = "食物", Id = foods.Id, Number = foods.Number, Remarks =foods.Remarks, FoodState = foods.FoodState.ToString()};
                
                return View(order);
            }
            if (goods != null)
            {
                var good = _context.Goodss.Find(goods.GoodsId);
                OrderViewModel order = new OrderViewModel() { Name = good.Name, Peice = (double.Parse(goods.Number) * double.Parse(good.Price)).ToString(), picture = good.picture, CLass = "生活用品", Id = goods.Id, Number = goods.Number, Remarks = goods.Remarks ,FoodState=goods.State.ToString()};

                return View(order);
            }
            if (commodidtys != null)
            {
                var commodidty = _context.Commoditys.Find(commodidtys.CommoditysId);
                OrderViewModel order = new OrderViewModel() { Name = commodidty.Name, Peice = (double.Parse(commodidtys.Number) * double.Parse(commodidty.Price)).ToString(), picture = commodidty.picture, CLass = "周边商品", Id = commodidtys.Id, Number = commodidtys.Number,Remarks = commodidtys.Remarks, FoodState = commodidtys.SaleStates.ToString() };

                return View(order);
            }
            return NotFound();
          

            
        }

        // GET: GoodsGR/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoodsGR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Detail,picture")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                goods.Id = Guid.NewGuid();
                _context.Add(goods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goods);
        }

        // GET: GoodsGR/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
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

        // POST: GoodsGR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, OrderViewModel order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var goods = await _context.GoodsOrders
                        .FirstOrDefaultAsync(m => m.Id == id);
                    var foods = await _context.FoodOrders
                        .FirstOrDefaultAsync(m => m.Id == id);
                    var commodidtys = await _context.CommodityOrders
                        .FirstOrDefaultAsync(m => m.Id == id);

                    if (foods != null)
                    {
                        foods.OrderStatus = false;
                        _context.Update(foods);
                        await _context.SaveChangesAsync();
                    }
                    if (goods != null)
                    {
                        goods.OrderStatus = false;
                        _context.Update(goods);
                        await _context.SaveChangesAsync();
                    }
                    if (commodidtys != null)
                    {
                        commodidtys.OrderStatus = false;
                        _context.Update(commodidtys);
                        await _context.SaveChangesAsync();
                    }
                   
                }
                catch (DbUpdateConcurrencyException)
                {                  
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: GoodsGR/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

            return View(goods);
        }

        // POST: GoodsGR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var goods = await _context.Goodss.FindAsync(id);
            _context.Goodss.Remove(goods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsExists(Guid id)
        {
            return _context.Goodss.Any(e => e.Id == id);
        }
    }
}
