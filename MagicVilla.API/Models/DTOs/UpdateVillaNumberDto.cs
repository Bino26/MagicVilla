using System.ComponentModel.DataAnnotations;

namespace MagicVilla.API.Models.DTOs
{
    public class UpdateVillaNumberDto
    {
        
        [Required]
        public Guid VillaID { get; set; }
        public string SpecialDetails { get; set; }
       
    }
}
