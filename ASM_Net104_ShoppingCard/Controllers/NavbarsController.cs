using Microsoft.AspNetCore.Mvc;

namespace ASM_Net104_ShoppingCard.Controllers
{
	public class NavbarsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Blog()
        {
            return View();
        }

		public IActionResult Contact()
		{
			return View();
		}

        public IActionResult Cart()
        {
            return View();
        }

		public IActionResult CheckOut()
		{
			return View();
		}

        public IActionResult Login()
        {
            return View();
        }
    }
}
