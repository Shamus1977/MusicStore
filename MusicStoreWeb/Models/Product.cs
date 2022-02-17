using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStoreWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ValidateNever]
        [Display(Name = "Media Type")]
        public string? MediaType { get; set; }
        [Required]
        public string? Title { get; set; }
        [ValidateNever]
        public int? BandId { get; set; }
        public Band? Band { get; set; }
        [Required]
        public string? Label { get; set; }
        [Required]
        public string? Length { get; set; }
        [Required]
        [Display(Name = "Number Of Tracks")]
        public int NumberOfTracks { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime Released { get; set; }
        [Required]
        public string? Tracks { get; set; }
        [Required]
        public string? Members { get; set; }
        [Required]
        [ValidateNever]
        [Display(Name = "Image File")]
        public string?  ImageUrl { get; set; }
        [Display(Name = "Date Added")]
        public DateTime AddedDate { get; set; } = DateTime.Now;
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        [ValidateNever]
        public Category? Category { get; set; }
        [ValidateNever]
        [Display(Name = "Cover Type")]
        public int? CoverTypeId { get; set; }
        [Display(Name = "Cover Type")]
        public Category? CoverType { get; set; }
    }
}

// When Band is addded it adds the product name to the string on the bands products
    // if not already there. If Band does not exist in database it will redirect to 
    // have the Admin put the band in the database.
// Store menmbers as string. Enter in format: Name - Position, . Split on ','.
    // at entry check if member is in database, if so check if product Id is in
    // Members list of products. If not, add Member to database and/or add Product
    // Id to list of Members prodects. Offer input of additional info, such as
    // image, birthdate, home town, role, description.
// Store Tracks as string. Enter format: 1) Name, . Split on ','.
