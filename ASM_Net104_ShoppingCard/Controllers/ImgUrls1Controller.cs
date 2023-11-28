using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASM_Net104_ShoppingCard.Context;
using ASM_Net104_ShoppingCard.Models;
using Microsoft.Extensions.Hosting;

namespace ASM_Net104_ShoppingCard.Controllers
{
    public class ImgUrls1Controller : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ImgUrls1Controller(MyDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: ImgUrls1
        public async Task<IActionResult> Index()
        {
              return _context.imgUrls != null ? 
                          View(await _context.imgUrls.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.imgUrls'  is null.");
        }

        // GET: ImgUrls1/Details/5
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

        // GET: ImgUrls1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImgUrls1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImgUrl imgUrl, IFormFile url1, IFormFile url2, IFormFile url3, IFormFile url4)
        {
            if (!ModelState.IsValid)
            {
                imgUrl.Url1 = await ProcessImage(url1);
                imgUrl.Url2 = await ProcessImage(url2);
                imgUrl.Url3 = await ProcessImage(url3);
                imgUrl.Url4 = await ProcessImage(url4);

                _context.Add(imgUrl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imgUrl);
        }

        // GET: ImgUrls1/Edit/5
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

        // POST: ImgUrls1/Edit/5
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

            if (ModelState.IsValid)
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

        // GET: ImgUrls1/Delete/5
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

        // POST: ImgUrls1/Delete/5
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

        private async Task<string> ProcessImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null; // Không có tệp hoặc tệp trống
            }

            // Đổi tên tệp để tránh trùng lặp và xử lý các kí tự đặc biệt
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var fileExtension = Path.GetExtension(file.FileName);
            var newFileName = $"{Guid.NewGuid()}{fileExtension}";

            // Đường dẫn thư mục lưu trữ ảnh (chỉ là một ví dụ, bạn cần thay đổi tùy thuộc vào cấu trúc thư mục của bạn)
            var uploadPath = Path.Combine(_environment.WebRootPath, "uploads");

            // Đường dẫn đầy đủ của tệp mới
            var filePath = Path.Combine(uploadPath, newFileName);

            // Kiểm tra xem thư mục lưu trữ đã tồn tại chưa, nếu chưa thì tạo mới
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Lưu tệp vào thư mục lưu trữ
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Trả về đường dẫn của tệp mới
            return $"/uploads/{newFileName}";
        }
    }
}
