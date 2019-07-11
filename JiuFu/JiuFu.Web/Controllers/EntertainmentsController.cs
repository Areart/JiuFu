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
    public class EntertainmentsController : Controller
    {
        private readonly SqlServerDbContext _context;

        public EntertainmentsController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: Entertainments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entertainments.ToListAsync());
        }

        // GET: Entertainments/Details/5
        public async Task<IActionResult> Details(Guid? id)
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

            return View(entertainment);
        }

        // GET: Entertainments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entertainments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Position,Date,Detail,picture")] Entertainment entertainment)
        {
            if (ModelState.IsValid)
            {
                entertainment.Id = Guid.NewGuid();
                _context.Add(entertainment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entertainment);
        }

        // GET: Entertainments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
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

        // POST: Entertainments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Position,Date,Detail,picture")] Entertainment entertainment)
        {
            if (id != entertainment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction(nameof(Index));
            }
            return View(entertainment);
        }

        // GET: Entertainments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

            return View(entertainment);
        }

        // POST: Entertainments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var entertainment = await _context.Entertainments.FindAsync(id);
            _context.Entertainments.Remove(entertainment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntertainmentExists(Guid id)
        {
            return _context.Entertainments.Any(e => e.Id == id);
        }
    }
}
