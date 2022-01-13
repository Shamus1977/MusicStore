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
    }
}
