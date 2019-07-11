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
using Microsoft.AspNetCore.Authorization;

namespace JiuFu.Web.Controllers
{
    public class FoodsController : Controller
    {
        private readonly SqlServerDbContext _context;
        public FoodsController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: Foods
        public async Task<IActionResult> Index(string searchString)
        {
             var s = await _context.Foods.OrderBy(x => x.FoodClass.Name).ToArrayAsync();
            List<FoodViewModel> fm = new List<FoodViewModel>();
            foreach (var f in s)
            {
                Guid guid = f.FoodClassId;
                var st = _context.FoodClass.Single(x => x.Id == guid);
                var tt = new FoodViewModel { Id=f.Id, Name = f.Name, Detail = f.Detail, picture = f.picture, Price = f.Price, ClassName = st.Name };
                fm.Add(tt);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                s = await _context.Foods.Where(x=>x.Name==searchString).OrderBy(x => x.FoodClass.Name).ToArrayAsync();
                fm = new List<FoodViewModel>();
                foreach (var f in s)
                {
                    Guid guid = f.FoodClassId;
                    var st = _context.FoodClass.Single(x => x.Id == guid);
                    var tt = new FoodViewModel { Id = f.Id, Name = f.Name, Detail = f.Detail, picture = f.picture, Price = f.Price, ClassName = st.Name };
                    fm.Add(tt);
                }               
            }
            return View(fm);
        }

        // GET: Foods/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var food = await _context.Foods
                .FirstOrDefaultAsync(m => m.Id == id);
            Guid Id = food.flavorId;
            var dge =  _context.Degrees.Where(x=>x.Flavors.Id==food.flavorId).ToList();        
          
            FoodOrderViewModel fo = new FoodOrderViewModel { foodid = food.Id, picture = food.picture,Price=food.Price,Name=food.Name,Number="1",Remarks="",FoodState=new FoodStateEnum(),degree=dge};
            return View(fo);
        }

        // GET: Foods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Detail,SaleState,picture")] Food food)
        {
            if (ModelState.IsValid)
            {
                food.Id = Guid.NewGuid();
                _context.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: Foods/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Price,Detail,SaleState,picture")] Food food)
        {
            if (id != food.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(food);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.Id))
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
            return View(food);
        }

        // GET: Foods/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var food = await _context.Foods.FindAsync(id);
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(Guid id)
        {
            return _context.Foods.Any(e => e.Id == id);
        }

        public IActionResult FoodOrderCreate()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FoodOrderCreate( FoodOrderViewModel foodorder)
        {
            var food = _context.Foods.Single(x=>x.Id== foodorder.foodid);
            var foodorders = new FoodOrder { Food= food,Number=foodorder.Number,Remarks=foodorder.Remarks,FoodState=foodorder.FoodState,FlarNames=foodorder.degrees,OrderStatus=true };
            _context.FoodOrders.Add(foodorders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
