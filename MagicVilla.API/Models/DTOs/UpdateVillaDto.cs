using System.ComponentModel.DataAnnotations;

namespace MagicVilla.API.Models.DTOs
{
    public class UpdateVillaDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Details must contains only 50 characters")]
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public int Sqft { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Amenity { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
