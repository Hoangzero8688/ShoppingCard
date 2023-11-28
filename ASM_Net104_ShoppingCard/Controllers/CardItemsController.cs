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
    public class CardItemsController : Controller
    {
        private readonly MyDbContext _context;

        public CardItemsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: CardItems
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.cardItems.Include(c => c.card).Include(c => c.productVariant);
            return View(await myDbContext.ToListAsync());
        }
        public async Task<IActionResult> Card()
        {
            var myDbContext = _context.cardItems.Include(c => c.card).Include(c => c.productVariant);
            return View(await myDbContext.ToListAsync());
        }

        // GET: CardItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cardItems == null)
            {
                return NotFound();
            }

            var cardItem = await _context.cardItems
                .Include(c => c.card)
                .Include(c => c.productVariant)
                .FirstOrDefaultAsync(m => m.ProductVariantId == id);
            if (cardItem == null)
            {
                return NotFound();
            }

            return View(cardItem);
        }

        // GET: CardItems/Create
        public IActionResult Create()
        {
            ViewData["CardId"] = new SelectList(_context.cards, "Id", "Id");
            ViewData["ProductVariantId"] = new SelectList(_context.productVariants, "Id", "Id");
            return View();
        }

        // POST: CardItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductVariantId,CardId,Quantity,AddedAt")] CardItem cardItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CardId"] = new SelectList(_context.cards, "Id", "Id", cardItem.CardId);
            ViewData["ProductVariantId"] = new SelectList(_context.productVariants, "Id", "Id", cardItem.ProductVariantId);
            return View(cardItem);
        }

        // GET: CardItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cardItems == null)
            {
                return NotFound();
            }

            var cardItem = await _context.cardItems.FindAsync(id);
            if (cardItem == null)
            {
                return NotFound();
            }
            ViewData["CardId"] = new SelectList(_context.cards, "Id", "Id", cardItem.CardId);
            ViewData["ProductVariantId"] = new SelectList(_context.productVariants, "Id", "Id", cardItem.ProductVariantId);
            return View(cardItem);
        }

        // POST: CardItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductVariantId,CardId,Quantity,AddedAt")] CardItem cardItem)
        {
            if (id != cardItem.ProductVariantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardItemExists(cardItem.ProductVariantId))
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
            ViewData["CardId"] = new SelectList(_context.cards, "Id", "Id", cardItem.CardId);
            ViewData["ProductVariantId"] = new SelectList(_context.productVariants, "Id", "Id", cardItem.ProductVariantId);
            return View(cardItem);
        }

        // GET: CardItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cardItems == null)
            {
                return NotFound();
            }

            var cardItem = await _context.cardItems
                .Include(c => c.card)
                .Include(c => c.productVariant)
                .FirstOrDefaultAsync(m => m.ProductVariantId == id);
            if (cardItem == null)
            {
                return NotFound();
            }

            return View(cardItem);
        }

        // POST: CardItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cardItems == null)
            {
                return Problem("Entity set 'MyDbContext.cardItems'  is null.");
            }
            var cardItem = await _context.cardItems.FindAsync(id);
            if (cardItem != null)
            {
                _context.cardItems.Remove(cardItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardItemExists(int id)
        {
          return (_context.cardItems?.Any(e => e.ProductVariantId == id)).GetValueOrDefault();
        }
    }
}
