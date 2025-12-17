using Microsoft.AspNetCore.Mvc;

namespace MVCPustokApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
