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
    public class GoodsController : Controller
    {
        private readonly SqlServerDbContext _context;

        public GoodsController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: Goods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Goodss.ToListAsync());
        }

        // GET: Goods/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goodss
                .FirstOrDefaultAsync(m => m.Id == id);
            GoodsOrderViewModel fo = new GoodsOrderViewModel { goodid = goods.Id, picture = goods.picture, Price = goods.Price, Name = goods.Name, Number = "1", Remarks = "" };
            return View(fo);
        }

        // GET: Goods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
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

        // GET: Goods/Edit/5
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

        // POST: Goods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Price,Detail,picture")] Goods goods)
        {
            if (id != goods.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction(nameof(Index));
            }
            return View(goods);
        }

        // GET: Goods/Delete/5
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

        // POST: Goods/Delete/5
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

        public IActionResult GoodsOrderCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GoodsOrderCreate( GoodsOrderViewModel goodsorder)
        {
            var good = _context.Goodss.Single(x => x.Id == goodsorder.goodid);
            var goodorders = new GoodsOrder { Goods = good, Name = goodsorder.Name, Number = goodsorder.Number, Remarks = goodsorder.Remarks, State = goodsorder.GoodState, GoodsId=good.Id, OrderStatus = true };
            _context.GoodsOrders.Add(goodorders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
