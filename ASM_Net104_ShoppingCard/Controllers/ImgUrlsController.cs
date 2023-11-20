using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASM_Net104_ShoppingCard.Context;
using ASM_Net104_ShoppingCard.Models;

namespace ASM_Net104_ShoppingCard.Controllers
{
    public class ImgUrlsController : Controller
    {
        private readonly MyDbContext _context;

        public ImgUrlsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ImgUrls
        public async Task<IActionResult> Index()
        {
              return _context.imgUrls != null ? 
                          View(await _context.imgUrls.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.imgUrls'  is null.");
        }

        // GET: ImgUrls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.imgUrls == null)
            {
                return NotFound();
            }

            var imgUrl = await _context.imgUrls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imgUrl == null)
            {
                return NotFound();
            }

            return View(imgUrl);
        }

        // GET: ImgUrls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImgUrls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Url1,Url2,Url3,Url4")] ImgUrl imgUrl)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(imgUrl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imgUrl);
        }

        // GET: ImgUrls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.imgUrls == null)
            {
                return NotFound();
            }

            var imgUrl = await _context.imgUrls.FindAsync(id);
            if (imgUrl == null)
            {
                return NotFound();
            }
            return View(imgUrl);
        }

        // POST: ImgUrls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url1,Url2,Url3,Url4")] ImgUrl imgUrl)
        {
            if (id != imgUrl.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(imgUrl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImgUrlExists(imgUrl.Id))
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
            return View(imgUrl);
        }

        // GET: ImgUrls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.imgUrls == null)
            {
                return NotFound();
            }

            var imgUrl = await _context.imgUrls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imgUrl == null)
            {
                return NotFound();
            }

            return View(imgUrl);
        }

        // POST: ImgUrls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.imgUrls == null)
            {
                return Problem("Entity set 'MyDbContext.imgUrls'  is null.");
            }
            var imgUrl = await _context.imgUrls.FindAsync(id);
            if (imgUrl != null)
            {
                _context.imgUrls.Remove(imgUrl);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImgUrlExists(int id)
        {
          return (_context.imgUrls?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
