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
    public class CommoditiesController : Controller
    {
        private readonly SqlServerDbContext _context;

        public CommoditiesController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: Commodities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Commoditys.ToListAsync());
        }

        // GET: Commodities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var commodities = await _context.Commoditys
                .FirstOrDefaultAsync(m => m.Id == id);
            CommoditiesOrderViewModel fo = new CommoditiesOrderViewModel { commoditiesid = commodities.Id, picture = commodities.picture, Price = commodities.Price, Name = commodities.Name, Number = "1", Remarks = "" };
            return View(fo);
        }

        // GET: Commodities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commodities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Detail,SaleState,picture")] Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                commodity.Id = Guid.NewGuid();
                _context.Add(commodity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commodity);
        }

        // GET: Commodities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
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

        // POST: Commodities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Price,Detail,SaleState,picture")] Commodity commodity)
        {
            if (id != commodity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction(nameof(Index));
            }
            return View(commodity);
        }

        // GET: Commodities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

            return View(commodity);
        }

        // POST: Commodities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var commodity = await _context.Commoditys.FindAsync(id);
            _context.Commoditys.Remove(commodity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommodityExists(Guid id)
        {
            return _context.Commoditys.Any(e => e.Id == id);
        }
        public IActionResult CommditiesOrderCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommditiesOrderCreate(CommoditiesOrderViewModel commoditiesorder)
        {
            var commodities = _context.Commoditys.Single(x => x.Id == commoditiesorder.commoditiesid);
            var commoditiesorders = new CommodityOrder { Commoditys = commodities, Name = commoditiesorder.Name, Number = commoditiesorder.Number, Remarks = commoditiesorder.Remarks, SaleStates = commoditiesorder.SaleStates, CommoditysId = commodities.Id, OrderStatus = true };
            _context.CommodityOrders.Add(commoditiesorders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
