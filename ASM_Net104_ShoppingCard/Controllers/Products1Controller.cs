using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASM_Net104_ShoppingCard.Context;
using ASM_Net104_ShoppingCard.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASM_Net104_ShoppingCard.Controllers
{
    public class Products1Controller : Controller
    {
        private readonly MyDbContext _context;

        public Products1Controller(MyDbContext context)
        {
            _context = context;
        }

        // GET: Products1
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Products.Include(p => p.Category);
            return View(await myDbContext.ToListAsync());
        }

        public async Task<IActionResult> ListProduct(int? page)
        {
            List<Product> products = _context.Products.Include(p => p.Category).Include(c => c.ProductVariants).ToList();
            ViewData["abc"] = products;

            const int productsPerPage = 9;
            int currentPage = page ?? 1;

            // Calculate total pages
            int totalPages = (int)Math.Ceiling((double)products.Count / productsPerPage);

            // Get the subset of products for the current page
            var productsForPage = products.Skip((currentPage - 1) * productsPerPage).Take(productsPerPage).ToList();

            // Pass products and pagination information to the view
            ViewData["Products"] = productsForPage;
            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = currentPage;
            return View();
        }

        // GET: Products1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
               .Include(p => p.Category)
               .ThenInclude(p=>p.Brand)
               .Include(p => p.ProductVariants)
                   .ThenInclude(pv => pv.ImgUrl)  // Nối quan hệ với ImgUrl
               .Include(p => p.ProductVariants)
                   .ThenInclude(pv => pv.Size)  // Nối quan hệ với Size
               .Include(p => p.ProductVariants)
                   .ThenInclude(pv => pv.color)  // Nối quan hệ với Color
               .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products1/Create
        public IActionResult Create()
        {
            ViewData["categoryid"] = new SelectList(_context.categories, "Id", "Id");
            return View();
        }

        // POST: Products1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,MaSp,ProductionYear,Price,Material,Image,Description,Status,categoryid")] Product product)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoryid"] = new SelectList(_context.categories, "Id", "Id", product.categoryid);
            return View(product);
        }

        // GET: Products1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["categoryid"] = new SelectList(_context.categories, "Id", "Id", product.categoryid);
            return View(product);
        }

        // POST: Products1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MaSp,ProductionYear,Price,Material,Image,Description,Status,categoryid")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["categoryid"] = new SelectList(_context.categories, "Id", "Id", product.categoryid);
            return View(product);
        }

        // GET: Products1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'MyDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
