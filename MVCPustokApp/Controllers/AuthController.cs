using Microsoft.AspNetCore.Mvc;

namespace MVCPustokApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
