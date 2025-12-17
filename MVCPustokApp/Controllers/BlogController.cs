using Microsoft.AspNetCore.Mvc;

namespace MVCPustokApp.Controllers
{
    public class BlogController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
