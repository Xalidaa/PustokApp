using MVCPustokApp.Models;
namespace MVCPustokApp.Areas.Admin.ViewModels.Feature
{
    public class CreateFeatureVM
    {
        public IFormFile Photo { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; }
        public decimal PriceOld { get; set; }
        public int PriceDiscount { get; set; }
        public int? CategoryId { get; set; }
        public List<Models.Category>? Categories { get; set; }
    }
}
