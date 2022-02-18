using System.ComponentModel.DataAnnotations;

namespace MusicStoreWeb.Models.ViewModels
{
    public class ShoppingCart
    {
        public Product? Product { get; set; }
        [Range(1,100, ErrorMessage ="Must Be A Number Between 1 and 1000.")]
        public int Count { get; set; } = 0;

    }
}
