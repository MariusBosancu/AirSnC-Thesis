using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirSnC.Models;

namespace AirSnC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsDbContext _context;

        public ProductsController(ProductsDbContext context)
        {
            _context = context;
            //ViewBag.name = HttpContext.Session.GetString("user");
        }

      
        public IActionResult Index(int p = 1)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            PagedResult<Products> Items = this._context.Productss.GetPaged(p, 3);
            return View(Items);
        }



        //// GET: Products
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Productss != null ? 
        //                  View(await _context.Productss.ToListAsync()) :
        //                  Problem("Entity set 'ProductsDbContext.Productss'  is null.");
        //}

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (id == null || _context.Productss == null)
            {
                return NotFound();
            }

            var products = await _context.Productss
                .FirstOrDefaultAsync(m => m.Name == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Description,Picture1,Picture2,Picture3")] Products products)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (id == null || _context.Productss == null)
            {
                return NotFound();
            }

            var products = await _context.Productss.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Price,Description,Picture1,Picture2,Picture3")] Products products)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (id != products.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Name))
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
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (id == null || _context.Productss == null)
            {
                return NotFound();
            }

            var products = await _context.Productss
                .FirstOrDefaultAsync(m => m.Name == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (_context.Productss == null)
            {
                return Problem("Entity set 'ProductsDbContext.Productss'  is null.");
            }
            var products = await _context.Productss.FindAsync(id);
            if (products != null)
            {
                _context.Productss.Remove(products);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(string id)
        {
          return (_context.Productss?.Any(e => e.Name == id)).GetValueOrDefault();
        }
    }
}
