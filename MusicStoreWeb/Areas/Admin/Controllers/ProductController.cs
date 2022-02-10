using Microsoft.AspNetCore.Mvc;
using MusicStoreWeb.Models;
using MusicStoreWeb.Repository.IRepository;

namespace MusicStoreWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IProductRepository? _repo;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.ProductRepository;
        }

        /// /////////////////////////     Get All Section   ////////////////////////////////////
        
        public IActionResult Index()
        {
            IEnumerable<Product>? productList = _repo?.GetAll();
            return View();
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
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo?.Add(product);
                _unitOfWork?.Save();
                TempData["success"] = "Product Created";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        /// *************************    Edit Section       ********************
        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var foundProduct = _repo?.GetFirstOrDefault(p => p.Id == id);
            if (foundProduct == null)
            {
                return NotFound();
            }
            return View(foundProduct);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo?.Update(product);
                _unitOfWork?.Save();
                TempData["success"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // ****************************   Delete section   ******************

        //Get
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var foundProduct = _repo?.GetFirstOrDefault(p => p.Id == id);
            if(foundProduct == null)
            {
                return NotFound();
            }
            return View(foundProduct);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var foundProduct = _repo?.GetFirstOrDefault(p => p.Id == id)!;
            _repo?.Remove(foundProduct);
            _unitOfWork?.Save();
            TempData["success"] = "Product Successfully Removed";
            return RedirectToAction("Index");
        }
    }
}
