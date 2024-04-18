using System.ComponentModel.DataAnnotations;

namespace MagicVilla.API.Models.DTOs
{
    public class UpdateUserDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must contains 3 characters")]
        public string Username { get; set; }
        
    }
}
