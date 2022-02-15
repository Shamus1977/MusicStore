using Microsoft.AspNetCore.Mvc.Rendering;
using MusicStoreWeb.Repository;

namespace MusicStoreWeb.Models.ViewModels
{
    public class ProductViewModel
    {
        private readonly UnitOfWork? _unitOfWork;
        public Product? Product { get; set; }
        
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
        public IEnumerable<SelectListItem>? CoverTypeList { get; set; }

    }
}
