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

        /// *************************    Create Section       ********************
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
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        /// *************************    Edit Section       ********************
        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var foundCategory = _dbContext?.Categories?.Find(id);
            if (foundCategory == null)
            {
                return NotFound();
            }
            return View(foundCategory);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name",
                    "The Display Order Cannot Exactly Match The Name");
            }
            if (ModelState.IsValid)
            {
                _dbContext?.Categories?.Update(category);
                _dbContext?.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // ****************************   Delete section   ******************

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var foundCategory = _dbContext?.Categories?.Find(id);
            if (foundCategory == null)
            {
                return NotFound();
            }
            return View(foundCategory);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            _dbContext?.Categories?.Remove(category);
            _dbContext?.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
