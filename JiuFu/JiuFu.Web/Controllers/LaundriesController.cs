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
    public class LaundriesController : Controller
    {
        private readonly SqlServerDbContext _context;

        public LaundriesController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: Laundries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Laundrys.ToListAsync());
        }

        // GET: Laundries/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laundries = await _context.Laundrys
           .FirstOrDefaultAsync(m => m.Id == id);
            LaundriesOrderViewModel fo = new LaundriesOrderViewModel { laundriesid = laundries.Id, Room = laundries.Mode, Price = laundries.Price, Remarks = "" };
            return View(fo);
        }

        // GET: Laundries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laundries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mode,Price")] Laundry laundry)
        {
            if (ModelState.IsValid)
            {
                laundry.Id = Guid.NewGuid();
                _context.Add(laundry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laundry);
        }

        // GET: Laundries/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
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

        // POST: Laundries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Mode,Price")] Laundry laundry)
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
                return RedirectToAction(nameof(Index));
            }
            return View(laundry);
        }

        // GET: Laundries/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
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

        // POST: Laundries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var laundry = await _context.Laundrys.FindAsync(id);
            _context.Laundrys.Remove(laundry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaundryExists(Guid id)
        {
            return _context.Laundrys.Any(e => e.Id == id);
        }
        public IActionResult LaundriesOrderCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LaundriesOrderCreate(LaundriesOrderViewModel laundriesorder)
        {
            var laundrie = _context.Laundrys.Single(x => x.Id == laundriesorder.laundriesid);
            var laundries = new LaundryOrder { Laundry = laundrie, Remarks = laundriesorder.Remarks, State = laundriesorder.LaundriesState };

            _context.LaundryOrders.Add(laundries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
