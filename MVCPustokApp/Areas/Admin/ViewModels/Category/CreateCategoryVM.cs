using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPustokApp.Areas.Admin.ViewModels.Category
{
    public class CreateCategoryVM
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}
