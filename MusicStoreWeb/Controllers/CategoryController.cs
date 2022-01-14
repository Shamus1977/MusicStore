using Microsoft.AspNetCore.Mvc;
using MusicStoreWeb.Data;
using MusicStoreWeb.Models;

namespace MusicStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext? _dbContext;

        public CategoryController(AppDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category>? categoryList = _dbContext?.Categories;
            return View(categoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", 
                    "The Display Order Cannot Exactly Match The Name");
            }
            if (ModelState.IsValid)
            {
                _dbContext?.Categories?.Add(category);
                _dbContext?.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
