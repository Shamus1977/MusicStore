using Microsoft.AspNetCore.Mvc;
using MusicStoreWeb.Models;
using MusicStoreWeb.Repository.IRepository;

namespace MusicStoreWeb.Controllers
{
    [Area("Admin")]
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

        //////////////////////////////////////////    Edit Section ////////////////////////////
        
        // GET
        public IActionResult Edit( int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var foundCoverType = _repo?.GetFirstOrDefault(c => c.Id == id);
            if (foundCoverType == null)
            {
                return NotFound();
            }
            return View(foundCoverType);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _repo?.Update(coverType);
                _unitOfWork?.Save();
                TempData["success"] = "Cover Type Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(coverType);
        }

        ///////////////////////////////////// Delete Section  ///////////////////////////////////
        
        //GET
        public IActionResult Delete(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var foundCoverType = _repo?.GetFirstOrDefault(c => c.Id == id);
            if(foundCoverType == null)
            {
                return NotFound();
            }
            return View(foundCoverType);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var foundCoverType = _repo?.GetFirstOrDefault(c=>c.Id == id)!;
            _repo?.Remove(foundCoverType);
            _unitOfWork?.Save();
            TempData["success"] = "Cover Type Successfully Removed";
            return RedirectToAction("Index");
        }
    }
}
