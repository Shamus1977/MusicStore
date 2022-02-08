using System.ComponentModel.DataAnnotations;

namespace MusicStoreWeb.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name: ")]
        public string? Name { get; set; }
    }
}
