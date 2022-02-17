using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicStoreWeb.Models;
using MusicStoreWeb.Models.ViewModels;
using MusicStoreWeb.Repository.IRepository;

namespace MusicStoreWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IProductRepository? _repo;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.ProductRepository;
            _environment = environment;
        }

        /// /////////////////////////     Get All Section   ////////////////////////////////////
        
        public IActionResult Index()
        {
            return View();
        }


        /// *************************    Upsert Section       ********************
        //Get
        public IActionResult Upsert(int? id)
        {
            ProductViewModel product = new()
            {
                Product = new(),
                CategoryList = _unitOfWork?.CategoryRepository.GetAll().Select(
                        i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        }
                    ),
                CoverTypeList = _unitOfWork?.CoverTypeRepository.GetAll().Select(
                        i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        }
                    ),
            };

            if(id == null || id == 0)
            {
                // Crate new product.
                return View(product);
            }
            else
            {
                product.Product = _repo?.GetFirstOrDefault(i => i.Id == id);
                //Update product.
                return View(product);
            }
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductViewModel obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath =_environment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Products");
                    var extension = Path.GetExtension(file.FileName);
                    if(obj?.Product?.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath,obj.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);    
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), 
                        FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        };
                    obj!.Product!.ImageUrl = @"\Images\Products\" + fileName + extension;
                }
                if(obj?.Product?.Id == 0)
                {
                    _repo?.Add(obj.Product!);
                }
                else
                {
                    _repo?.Update(obj?.Product!);
                }
                
                _unitOfWork?.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
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

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _repo?.GetAll(includeProperties:"Category");
            return Json(new {data = productList});
        }
        #endregion
    }
}
