namespace MVCPustokApp.Areas.Admin.ViewModels.Category
{
    public class UpdateCategoryVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public IFormFile? Photo { get; set; }

    }
}
