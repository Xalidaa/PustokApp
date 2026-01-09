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


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1)
                return BadRequest();

            Feature feature = await _context.Features
                .FirstOrDefaultAsync(f => f.Id == id);

            if (feature == null)
                return NotFound();

            UpdateFeatureVM updateFeatureVM = new UpdateFeatureVM
            {
                Name = feature.Heading,
                ImageUrl = feature.ImageUrl,
                Detail = feature.Detail,
                Price = feature.Price,
                PriceOld = feature.PriceOld,
                PriceDiscount = feature.PriceDiscount,
                CategoryId = feature.CategoryId,
                Categories = await _context.Categories.ToListAsync() // ✅ IMPORTANT
            };

            return View(updateFeatureVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateFeatureVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _context.Categories.ToListAsync(); // ✅ REQUIRED
                return View(model);
            }

            Feature feature = await _context.Features.FirstOrDefaultAsync(f => f.Id == id);
            if (feature == null) return NotFound();

            feature.Heading = model.Name;
            feature.Detail = model.Detail;
            feature.Price = model.Price;
            feature.PriceOld = model.PriceOld;
            feature.PriceDiscount = model.PriceDiscount;
            feature.CategoryId = model.CategoryId;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Feature feature = await _context.Features.FirstOrDefaultAsync(c => c.Id == id);
            if (feature == null)
            {
                return NotFound();
            }

            feature.ImageUrl.DeleteFile(_env.WebRootPath, "assets", "image", "bg-images");
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public async Task<ActionResult> Detail(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }

            Feature feature = await _context.Features.FirstOrDefaultAsync(c => c.Id == id);
            if (feature is null)
            {
                return NotFound();
            }

            return View(feature);
        }
    }
}
