using Microsoft.AspNetCore.Mvc;
using MusicStoreWeb.Models;
using MusicStoreWeb.Repository.IRepository;

namespace MusicStoreWeb.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork? _unitOfWork;
        private ICoverTypeRepository? _repo;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.CoverTypeRepository;
        }

        // //////////////// Get All Section ////////////////////////////////////////////////
        
        public IActionResult Index()
        {
            IEnumerable<CoverType> coverTypeList = _repo.GetAll();
            return View(coverTypeList);
        }

        //////////////////////////////////////////  Create Section //////////////////////////////
        
        // GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _repo?.Add(coverType);
                _unitOfWork?.Save();
                TempData["success"] = "Cover Type Created Successfully";
                return RedirectToAction("Index");
            }
            return View(coverType);
        }

    }
}
