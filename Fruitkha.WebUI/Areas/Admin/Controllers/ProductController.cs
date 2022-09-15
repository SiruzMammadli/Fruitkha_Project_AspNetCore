using Fruitkha.DataAccess.Context;
using Fruitkha.DataAccess.Entity;
using Fruitkha.WebUI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fruitkha.WebUI.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(x => x.Category).ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = await _context.Categories.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, int categoryId, IFormFile ImageUrl)
        {
            product.ImageUrl = await FileHelper.UploadImage(ImageUrl, _environment);
            product.CategoryId = categoryId;
            product.CreatedDate = DateTime.Now;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var currentProduct = await _context.Products.Where(i => i.Id == id).SingleOrDefaultAsync();
            return View(currentProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            var currentProduct = await _context.Products.FindAsync(product.Id);
            if (currentProduct.ImageUrl != null)
            {
                string ExitingFile = _environment.WebRootPath + currentProduct.ImageUrl;
                System.IO.File.Delete(ExitingFile);
            }
            _context.Products.Remove(currentProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.Where(c => c.Id == id).SingleOrDefaultAsync();
            ViewData["Categories"] = await _context.Categories.ToListAsync();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, int categoryId, IFormFile ImageUrl)
        {

            product.CategoryId = categoryId;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
