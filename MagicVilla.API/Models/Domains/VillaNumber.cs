using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla.API.Models.Domains
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }
        
        public Guid VillaID { get; set; }

        public Villa Villa { get; set; }

        public string SpecialDetails { get; set; }
       
    }
}
