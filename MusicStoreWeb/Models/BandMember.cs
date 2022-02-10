using System.ComponentModel.DataAnnotations;

namespace MusicStoreWeb.Models
{
    public class BandMember
    {
        [Key]
        public int Id { get; set; }
        public string? ProductIds { get; set; }    
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Role { get; set; }
        public string? HomeTown { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
