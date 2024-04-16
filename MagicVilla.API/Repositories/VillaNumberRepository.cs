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

        public async Task<VillaNumber> AddDetailsAsync(VillaNumber villaNumber)
        {
            var villa= await villaDbContext.VillaNumbers.AddAsync(villaNumber);
            await villaDbContext.SaveChangesAsync();
            return villaNumber;
        }

        public async Task<List<VillaNumber>> GetAllDetailsAsync()
        {
            var villas = await villaDbContext.VillaNumbers.Include("Villa").ToListAsync();
            return villas;
                
        }

        public async Task<VillaNumber> GetVillaDetailsByNoAsync(int No)
        {
            var villa = await villaDbContext.VillaNumbers.Include("Villa").FirstOrDefaultAsync(x => x.VillaNo==No);
            if(villa is null){
                return null;
            }
            return villa;
        }

        public async Task<VillaNumber> UpdateDetailsAsync(int No, VillaNumber villaNumber)
        {
            var existingVilla = await villaDbContext.VillaNumbers.Include("Villa").FirstOrDefaultAsync(x => x.VillaNo == No);
            if(villaNumber is null)
            {
                return null;
            }
            
            existingVilla.VillaID = villaNumber.VillaID;
            existingVilla.SpecialDetails = villaNumber.SpecialDetails;

            await villaDbContext.SaveChangesAsync();

            return existingVilla;
           

        }
    }
}
