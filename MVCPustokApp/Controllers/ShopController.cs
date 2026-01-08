using Microsoft.AspNetCore.Mvc;

namespace MVCPustokApp.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
