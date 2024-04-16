using MagicVilla.API.Data;
using MagicVilla.API.Models.Domains;
using MagicVilla.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicVilla.API.Repositories
{
    public class VillaNumberRepository : IVillaNumberRepository
    {
        private readonly VillaDbContext villaDbContext;

        public VillaNumberRepository(VillaDbContext villaDbContext)
        {
            this.villaDbContext = villaDbContext;
        }

        public async Task<VillaNumber> AddNumberAsync(VillaNumber number)
        {
            var villaNumber= await villaDbContext.VillaNumbers.AddAsync(number);
            await villaDbContext.SaveChangesAsync();
            return number;
        }

        public async Task<List<VillaNumber>> GetAllNumbersAsync()
        {
            var villas = await villaDbContext.VillaNumbers.Include("Villa").ToListAsync();
            return villas;
                
        }

        public async Task<VillaNumber> GetVillaNumberByIdAsync(int numberId)
        {
            var villa = await villaDbContext.VillaNumbers.Include("Villa").FirstOrDefaultAsync(x => x.VillaNo==numberId);
            return villa;
        }

        public async Task<VillaNumber> UpdateNumberAsync(int numberId, VillaNumber number)
        {
            var existingVilla = await villaDbContext.VillaNumbers.FirstOrDefaultAsync(x => x.VillaNo == numberId);
            if(number is null)
            {
                return null;
            }
            existingVilla.VillaID = number.VillaID;
            existingVilla.SpecialDetails = number.SpecialDetails;

            return existingVilla;
           

        }
    }
}
