using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPustokApp.Areas.Admin.ViewModels.Category;
using MVCPustokApp.Areas.Admin.ViewModels.Feature;
using MVCPustokApp.DAL;
using MVCPustokApp.Models;
using MVCPustokApp.Utilities.Extensions;

namespace MVCPustokApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FeatureController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<GetFeatureVM> featureVMs = await _context.Features
                .Include(c=> c.Category)
                .Select(p => new GetFeatureVM
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Heading,
                    Price = p.Price,
                    CategoryName = p.Category.Name

                })
                .ToListAsync();
            return View(featureVMs);
        }

        public async Task<ActionResult> Create()
        {
            CreateFeatureVM createFeatureVM = new CreateFeatureVM()
            {
                Categories = await _context.Categories.ToListAsync()
            };
            return View(createFeatureVM);
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateFeatureVM createFeatureVM)
        {
            createFeatureVM.Categories = await _context.Categories.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View(createFeatureVM);
            }

            bool result = await _context.Categories.AnyAsync(c => c.Id == createFeatureVM.CategoryId);
            if (!result)
            {
                ModelState.AddModelError(nameof(createFeatureVM.CategoryId), "Category not found");
                return View(createFeatureVM);
            }

            Feature feature = new Feature()
            {
                Heading = createFeatureVM.Name,
                Detail = createFeatureVM.Detail,
                Price = createFeatureVM.Price,
                PriceOld = createFeatureVM.PriceOld,
                PriceDiscount = createFeatureVM.PriceDiscount,
                CategoryId = createFeatureVM.CategoryId.Value,
                ImageUrl = await createFeatureVM.Photo.CreateFile(_env.WebRootPath, "assets", "image", "bg-images")

            };

            await _context.Features.AddAsync(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
