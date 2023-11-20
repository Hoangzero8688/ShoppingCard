using ASM_Net104_ShoppingCard.Models;
using ASM_Net104_ShoppingCard.Service;
using ASM_Net104_ShoppingCard.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace ASM_Net104_ShoppingCard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategorySV _ICategorySV;
        private readonly IBrandSV _IbrandSV;

        public CategoryController(ICategorySV categorySV,IBrandSV brandSV)
        {
            _ICategorySV = categorySV;
            _IbrandSV = brandSV;
        }
        [HttpGet]


        public IActionResult Index()
        {
            var categories = _ICategorySV.GetAll();

            // Load thông tin về thương hiệu cho mỗi Category
            foreach (var category in categories)
            {
                category.Brand = _IbrandSV.GetById(category.IdBrand);
            }

            // Lấy danh sách thương hiệu từ Service
            List<Brand> brands = _IbrandSV.GetAll();

            // Tạo SelectList từ danh sách thương hiệu
            ViewBag.Brands = new SelectList(brands, "Id", "Name");

            return View(categories);
        }


        [HttpGet]
        public IActionResult Add()
        {
           List<Brand> brands = _IbrandSV.GetAll();
            var brandSelectList = new SelectList(brands, "id", "name");
            ViewBag.Brands = brandSelectList;
           return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (!ModelState.IsValid)
            {
                _ICategorySV.Add(category);
            }
            return RedirectToAction("Index");

            //// Nếu ModelState không hợp lệ, in ra lỗi để kiểm tra
            //foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            //{
            //    Console.WriteLine(error.ErrorMessage);
            //}

            //var brands = _IbrandSV.GetAll();
            //ViewBag.Brands = new SelectList(brands, "id", "name", category.IdBrand);
            //return View(category);
        }
        public IActionResult Delete(int id)
        {
            var CategoryId = _ICategorySV.GetById(id);

            if (CategoryId == null) { return View("NotFound"); };
            return View(CategoryId);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteId(int id)
        {
            var CategoryId = _ICategorySV.GetById(id);

        if (CategoryId == null) { return View("NotFound"); };

            _ICategorySV.Delete(id);

            return RedirectToAction("Index");
        }
        
        //edit 

       public IActionResult Edit( int id )
        {
            var categoryDetails = _ICategorySV.GetById(id);
            List<Brand> brands = _IbrandSV.GetAll();
            var brandSelectList = new SelectList(brands, "id", "name");
            ViewBag.Brands = brandSelectList;

            return View(categoryDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                return View(category);
            }
            _ICategorySV.Update(id, category);

            var brands = _IbrandSV.GetAll();
            ViewBag.Brands = new SelectList(brands, "id", "name", category.IdBrand);
            return RedirectToAction("Index");
        }

    }
}
