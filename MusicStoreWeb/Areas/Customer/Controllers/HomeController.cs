using Microsoft.AspNetCore.Mvc;
using MusicStoreWeb.Models;
using MusicStoreWeb.Models.ViewModels;
using MusicStoreWeb.Repository.IRepository;
using System.Diagnostics;

namespace MusicStoreWeb.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepo;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this._unitOfWork = unitOfWork;
            this._productRepo = _unitOfWork.ProductRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _productRepo.GetAll(includeProperties: "Category,CoverType");   
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            ShoppingCart cart = new() { 
                Product = _productRepo.GetFirstOrDefault(p => p.Id == id, "Category, CoverType"),
                Count = 1
            };  
            return View(cart);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}