using Microsoft.AspNetCore.Mvc;

namespace MVCPustokApp.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
