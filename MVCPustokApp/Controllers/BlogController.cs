using Microsoft.AspNetCore.Mvc;

namespace MVCPustokApp.Controllers
{
    public class BlogController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
