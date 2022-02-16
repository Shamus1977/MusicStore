using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicStoreWeb.Repository;

namespace MusicStoreWeb.Models.ViewModels
{
    public class ProductViewModel
    {
        private readonly UnitOfWork? _unitOfWork;
        public Product? Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? CoverTypeList { get; set; }

    }
}
