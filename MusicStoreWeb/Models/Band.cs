using System.ComponentModel.DataAnnotations;

namespace MusicStoreWeb.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Members { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? Products { get; set; }
        public DateTime? InitiatedOn { get; set; }
    }
}
