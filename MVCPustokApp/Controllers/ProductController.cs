using Microsoft.AspNetCore.Mvc;

namespace MVCPustokApp.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
