using Microsoft.AspNetCore.Mvc;

namespace MVCPustokApp.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
