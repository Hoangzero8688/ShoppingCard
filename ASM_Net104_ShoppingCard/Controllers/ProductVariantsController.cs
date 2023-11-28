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
    public class ProductVariantsController : Controller
    {
        private readonly MyDbContext _context;

        public ProductVariantsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ProductVariants
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.productVariants.Include(p => p.ImgUrl).Include(p => p.Origin).Include(p => p.Product).Include(p => p.Size).Include(p => p.color);

            //ViewData["OriginId"] = new SelectList(_context.origins, "Id", "OriginName");
            //ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            //ViewData["SizeId"] = new SelectList(_context.sizes, "Id", "SizeName");
            //ViewData["ColorId"] = new SelectList(_context.colors, "Id", "ColorName");

            return View(await myDbContext.ToListAsync());
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var myDbContext = _context.productVariants
                .Where(c => c.Id == id)
                .Include(p => p.ImgUrl)
                .Include(p => p.Origin)
                .Include(p => p.Product.Category.Brand)
                .Include(p => p.Size)
                .Include(p => p.color)
                .Include(p => p.Product)
                ;

            var product = await myDbContext.FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Index1(int? page)
        {
            List<ProductVariant> productVariants = _context.productVariants.Include(p => p.color).Include(c => c.ImgUrl).Include(d => d.Origin).Include(g => g.Product).Include(f => f.Origin).ToList();
            ViewData["abc"] = productVariants;

            const int productsPerPage = 9;
            int currentPage = page ?? 1;

            // Calculate total pages
            int totalPages = (int)Math.Ceiling((double)productVariants.Count / productsPerPage);

            // Get the subset of products for the current page
            var productsForPage = productVariants.Skip((currentPage - 1) * productsPerPage).Take(productsPerPage).ToList();

            // Pass products and pagination information to the view
            ViewData["Products"] = productsForPage;
            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = currentPage;
            return View();
        }



        // GET: ProductVariants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.productVariants == null)
            {
                return NotFound();
            }

            var productVariant = await _context.productVariants
                .Include(p => p.ImgUrl)
                .Include(p => p.Origin)
                .Include(p => p.Product)
                .Include(p => p.Size)
                .Include(p => p.color)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productVariant == null)
            {
                return NotFound();
            }

            return View(productVariant);
        }

        // GET: ProductVariants/Create
        public IActionResult Create()
        {
            ViewData["ImgUrlId"] = new SelectList(_context.imgUrls, "Id", "Id");
            ViewData["OriginId"] = new SelectList(_context.origins, "Id", "OriginName");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            ViewData["SizeId"] = new SelectList(_context.sizes, "Id", "SizeName");
            ViewData["ColorId"] = new SelectList(_context.colors, "Id", "ColorName");
            return View();
        }

        // POST: ProductVariants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,ImgUrlId,SizeId,ColorId,OriginId,Quantity")] ProductVariant productVariant)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(productVariant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImgUrlId"] = new SelectList(_context.imgUrls, "Id", "Id", productVariant.ImgUrlId);
            ViewData["OriginId"] = new SelectList(_context.origins, "Id", "OriginName", productVariant.OriginId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productVariant.ProductId);
            ViewData["SizeId"] = new SelectList(_context.sizes, "Id", "SizeName", productVariant.SizeId);
            ViewData["ColorId"] = new SelectList(_context.colors, "Id", "ColorName", productVariant.ColorId);
            return View(productVariant);
        }

        // GET: ProductVariants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.productVariants == null)
            {
                return NotFound();
            }

            var productVariant = await _context.productVariants.FindAsync(id);
            if (productVariant == null)
            {
                return NotFound();
            }
            ViewData["ImgUrlId"] = new SelectList(_context.imgUrls, "Id", "Id", productVariant.ImgUrlId);
            ViewData["OriginId"] = new SelectList(_context.origins, "Id", "OriginName", productVariant.OriginId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productVariant.ProductId);
            ViewData["SizeId"] = new SelectList(_context.sizes, "Id", "SizeName", productVariant.SizeId);
            ViewData["ColorId"] = new SelectList(_context.colors, "Id", "ColorName", productVariant.ColorId);
            return View(productVariant);
        }

        // POST: ProductVariants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,ImgUrlId,SizeId,ColorId,OriginId,Quantity")] ProductVariant productVariant)
        {
            if (id != productVariant.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(productVariant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductVariantExists(productVariant.Id))
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
            ViewData["ImgUrlId"] = new SelectList(_context.imgUrls, "Id", "Id", productVariant.ImgUrlId);
            ViewData["OriginId"] = new SelectList(_context.origins, "Id", "OriginName", productVariant.OriginId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productVariant.ProductId);
            ViewData["SizeId"] = new SelectList(_context.sizes, "Id", "SizeName", productVariant.SizeId);
            ViewData["ColorId"] = new SelectList(_context.colors, "Id", "ColorName", productVariant.ColorId);
            return View(productVariant);
        }

        // GET: ProductVariants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.productVariants == null)
            {
                return NotFound();
            }

            var productVariant = await _context.productVariants
                .Include(p => p.ImgUrl)
                .Include(p => p.Origin)
                .Include(p => p.Product)
                .Include(p => p.Size)
                .Include(p => p.color)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productVariant == null)
            {
                return NotFound();
            }

            return View(productVariant);
        }

        // POST: ProductVariants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.productVariants == null)
            {
                return Problem("Entity set 'MyDbContext.productVariants'  is null.");
            }
            var productVariant = await _context.productVariants.FindAsync(id);
            if (productVariant != null)
            {
                _context.productVariants.Remove(productVariant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductVariantExists(int id)
        {
            return (_context.productVariants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
