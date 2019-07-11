using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JiuFu.Entities;
using JiuFu.ORM.SqlServer;

namespace JiuFu.Web.Controllers
{
    public class FoodClassesController : Controller
    {
        private readonly SqlServerDbContext _context;

        public FoodClassesController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: FoodClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodClass.ToListAsync());
        }

        // GET: FoodClasses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodClass = await _context.FoodClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodClass == null)
            {
                return NotFound();
            }

            return View(foodClass);
        }

        // GET: FoodClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FoodClass foodClass)
        {
            if (ModelState.IsValid)
            {
                foodClass.Id = Guid.NewGuid();
                _context.Add(foodClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodClass);
        }

        // GET: FoodClasses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodClass = await _context.FoodClass.FindAsync(id);
            if (foodClass == null)
            {
                return NotFound();
            }
            return View(foodClass);
        }

        // POST: FoodClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] FoodClass foodClass)
        {
            if (id != foodClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodClassExists(foodClass.Id))
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
            return View(foodClass);
        }

        // GET: FoodClasses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodClass = await _context.FoodClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodClass == null)
            {
                return NotFound();
            }

            return View(foodClass);
        }

        // POST: FoodClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var foodClass = await _context.FoodClass.FindAsync(id);
            _context.FoodClass.Remove(foodClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodClassExists(Guid id)
        {
            return _context.FoodClass.Any(e => e.Id == id);
        }
    }
}
