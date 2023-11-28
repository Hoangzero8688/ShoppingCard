using ASM_Net104_ShoppingCard.Context;
using ASM_Net104_ShoppingCard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Diagnostics;

namespace ASM_Net104_ShoppingCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _dbcontext;


        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _dbcontext = context;
            _logger = logger;

        }

        public IActionResult Index()
        {
            List<ProductVariant> productVariants = _dbcontext.productVariants.Include(p=>p.color).Include(c=>c.ImgUrl).Include(d=>d.Origin).Include(g=>g.Product).Include(f=>f.Origin).ToList();
            ViewData["abc"] = productVariants;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}