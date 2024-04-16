using MagicVilla.API.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla.API.Models.Domains
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public Guid VillaID { get; set; }
        public VillaDto Villa { get; set; }
        public string SpecialDetails { get; set; }
        
    }
}
