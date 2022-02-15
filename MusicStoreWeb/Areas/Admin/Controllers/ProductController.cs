using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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


        /// *************************    Edit Section       ********************
        //Get
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            IEnumerable<SelectListItem> categoryList = _unitOfWork!.CategoryRepository.GetAll().Select(
                    i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }
                );

            IEnumerable<SelectListItem> coverTypeList = _unitOfWork.CoverTypeRepository.GetAll().Select(
                    i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }
                );

            if(id == null || id == 0)
            {
                // Crate new product.
                //ViewBag.CategoryList = categoryList;
                ViewData["categoryList"] = categoryList;
                ViewBag.CoverTypeList = coverTypeList;
                return View(product);
            }
            else
            {
                //Update product.
            }
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product product)
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
