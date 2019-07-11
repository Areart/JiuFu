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
    public class ScenicsController : Controller
    {
        private readonly SqlServerDbContext _context;

        public ScenicsController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: Scenics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Scenics.ToListAsync());
        }

        // GET: Scenics/Details/5
        public async Task<IActionResult> Details(Guid? id)
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

            return View(scenic);
        }

        // GET: Scenics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scenics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Position,Date,Detail,picture")] Scenic scenic)
        {
            if (ModelState.IsValid)
            {
                scenic.Id = Guid.NewGuid();
                _context.Add(scenic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scenic);
        }

        // GET: Scenics/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
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

        // POST: Scenics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Position,Date,Detail,picture")] Scenic scenic)
        {
            if (id != scenic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction(nameof(Index));
            }
            return View(scenic);
        }

        // GET: Scenics/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

            return View(scenic);
        }

        // POST: Scenics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scenic = await _context.Scenics.FindAsync(id);
            _context.Scenics.Remove(scenic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScenicExists(Guid id)
        {
            return _context.Scenics.Any(e => e.Id == id);
        }
    }
}
