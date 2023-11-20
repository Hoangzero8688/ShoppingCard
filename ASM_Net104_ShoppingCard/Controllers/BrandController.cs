using ASM_Net104_ShoppingCard.Models;
using ASM_Net104_ShoppingCard.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Net104_ShoppingCard.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandSV _IbrandSV;

        public BrandController(IBrandSV brandSV)
        {
            _IbrandSV = brandSV;       
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_IbrandSV.GetAll());
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _IbrandSV.Add(brand);
            }
            return RedirectToAction("Index");
        }
    }
}
