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
    public class OriginsController : Controller
    {
        private readonly MyDbContext _context;

        public OriginsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Origins
        public async Task<IActionResult> Index()
        {
              return _context.origins != null ? 
                          View(await _context.origins.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.origins'  is null.");
        }

        // GET: Origins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.origins == null)
            {
                return NotFound();
            }

            var origin = await _context.origins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origin == null)
            {
                return NotFound();
            }

            return View(origin);
        }

        // GET: Origins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Origins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OriginName")] Origin origin)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(origin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(origin);
        }

        // GET: Origins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.origins == null)
            {
                return NotFound();
            }

            var origin = await _context.origins.FindAsync(id);
            if (origin == null)
            {
                return NotFound();
            }
            return View(origin);
        }

        // POST: Origins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OriginName")] Origin origin)
        {
            if (id != origin.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(origin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OriginExists(origin.Id))
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
            return View(origin);
        }

        // GET: Origins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.origins == null)
            {
                return NotFound();
            }

            var origin = await _context.origins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origin == null)
            {
                return NotFound();
            }

            return View(origin);
        }

        // POST: Origins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.origins == null)
            {
                return Problem("Entity set 'MyDbContext.origins'  is null.");
            }
            var origin = await _context.origins.FindAsync(id);
            if (origin != null)
            {
                _context.origins.Remove(origin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OriginExists(int id)
        {
          return (_context.origins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
