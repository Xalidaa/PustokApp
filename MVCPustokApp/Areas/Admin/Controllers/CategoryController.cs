using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPustokApp.Areas.Admin.ViewModels.Category;
using MVCPustokApp.DAL;
using MVCPustokApp.Models;
using MVCPustokApp.Utilities.Enums;
using MVCPustokApp.Utilities.Extensions;

namespace MVCPustokApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController:Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CategoryController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<ActionResult> Index()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Create(CreateCategoryVM createCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!createCategoryVM.Photo.ValidateType("image/"))
            {
                ModelState.AddModelError("Photo", "Please select image file");
                return View();
            }

            if (createCategoryVM.Photo.ValidateSize(FileSize.MB, 10))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 10MB");
                return View();
            }

            bool result = await _context.Categories.AnyAsync(c => c.Name == createCategoryVM.Name);
            if (result)
            {
                ModelState.AddModelError("Name", "This category already exists");
                return View();
            }

            Category category = new Category()
            { 
                Name = createCategoryVM.Name,
                Image = await createCategoryVM.Photo.CreateFile(_env.WebRootPath, "assets", "image", "bg-images")
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Update(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            UpdateCategoryVM updateCategoryVM = new UpdateCategoryVM() 
            {
                Name = category.Name,
                Image = category.Image
            };
            return View(updateCategoryVM);
        }
        [HttpPost]

        public async Task<ActionResult> Update(int? id, UpdateCategoryVM updateCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View(updateCategoryVM);
            }
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if(updateCategoryVM.Photo is not null)
            {
                if (!updateCategoryVM.Photo.ValidateType("image/"))
                {
                    ModelState.AddModelError(nameof(updateCategoryVM.Photo), "The input must be an image");
                    return View(updateCategoryVM);
                }
                if (updateCategoryVM.Photo.ValidateSize(FileSize.MB, 20))
                {
                    ModelState.AddModelError(nameof(updateCategoryVM.Photo), "The input must be of 20MB size");
                    return View(updateCategoryVM);
                }
                string filename = await updateCategoryVM.Photo.CreateFile(_env.WebRootPath, "assets", "image", "bg-images");
                category.Image.DeleteFile(_env.WebRootPath, "assets", "image", "bg-images");
                category.Image = filename;
            }

            category.Name = updateCategoryVM.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
      
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            category.Image.DeleteFile(_env.WebRootPath, "assets", "image", "bg-images");
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public async Task<ActionResult> Detail(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}
