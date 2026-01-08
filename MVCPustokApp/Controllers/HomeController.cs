using Microsoft.AspNetCore.Mvc;
using MVCPustokApp.DAL;
using MVCPustokApp.Models;
using MVCPustokApp.ViewModels;
namespace MVCPustokApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
           
            //_context.Features.AddRange(features);
            //_context.SaveChanges();
            HomeVM homeVM = new HomeVM
            {
                Features = _context.Features.ToList()
            };
            return View(homeVM);
        }
    }
}
