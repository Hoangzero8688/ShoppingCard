using ASM_Net104_ShoppingCard.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Net104_ShoppingCard.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductSV _IproductSV;

        public ProductController(IProductSV productSV)
        {
            _IproductSV = productSV;
        }

        [HttpGet]               
        
        public IActionResult Index()
        {
            return View(_IproductSV.GetAll());
        }
    }
}
