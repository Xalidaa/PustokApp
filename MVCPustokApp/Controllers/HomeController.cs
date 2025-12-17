using Microsoft.AspNetCore.Mvc;
using MVCPustokApp.Models;
using MVCPustokApp.ViewModels;
namespace MVCPustokApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Feature> features = new List<Feature>
            {
                new Feature(1, "Zpple","Crystal Sound Wired Headphones", 29.00m, 39.00m, 25, "product-1.jpg"),
                new Feature(2,"Mpple","Wireless Bluetooth Headphones", 59.00m, 79.00m, 25, "product-2.jpg"),
                new Feature(3,"Tpple","Smart Watch Series 7", 199.00m, 249.00m, 20, "product-3.jpg"),
                new Feature(4,"Appple","Wireless Bluetooth Speaker", 49.00m, 69.00m, 30, "product-4.jpg"),
                new Feature(5,"Spple","Wireless Earbuds Pro", 99.00m, 129.00m, 23, "product-5.jpg"),
                new Feature(6,"Cpple","Fitness Tracker Band", 39.00m, 59.00m, 33, "product-6.jpg"),
                new Feature(7,"Dpple","Noise Cancelling Headphones", 89.00m, 119.00m, 25, "product-7.jpg"),
                new Feature(8,"Epple","4K Action Camera", 149.00m, 199.00m, 25, "product-8.jpg"),
                new Feature(9,"Fpple","Smart Home Hub", 79.00m, 99.00m, 20, "product-9.jpg"),
                new Feature(10,"Gpple","Portable Charger 20000mAh", 39.00m, 49.00m, 20, "product-10.jpg"),
                new Feature(11,"Hpple","Wireless Gaming Mouse", 49.00m, 69.00m, 28, "product-11.jpg"),
                new Feature(12,"Ipple","Mechanical Keyboard", 89.00m, 119.00m, 25, "product-12.jpg")
            };
            HomeVM homeVM = new HomeVM
            {
                Features = features
            };
            return View(homeVM);
        }
    }
}
