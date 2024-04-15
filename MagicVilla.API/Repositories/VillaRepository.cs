using MagicVilla.API.Data;
using MagicVilla.API.Models.Domains;
using MagicVilla.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.API.Repositories
{
    public class VillaRepository : IVillaRepository
    {
        private readonly VillaDbContext villaDbContext;

        public VillaRepository(VillaDbContext villaDbContext)
        {
            this.villaDbContext = villaDbContext;
        }

        public async Task<Villa> CreateVillaAsync(Villa villa)
        {
            if (villa is null)
            {
                return null;
            }
            await villaDbContext.Villas.AddAsync(villa);
            await villaDbContext.SaveChangesAsync();
            return villa;
            
        }

        public async Task<List<Villa>> DeleteAllVillaAsync()
        {
            var villas = await villaDbContext.Villas.ToListAsync();
              villaDbContext.Villas.RemoveRange(villas);
            return villas;
        }

        public async Task<Villa> DeleteByIdAsync(Guid id)
        {
            var villa = await villaDbContext.Villas.FirstOrDefaultAsync(x => x.Id == id);
             villaDbContext.Villas.Remove(villa);
            await villaDbContext.SaveChangesAsync();
            return villa;
        }

        public async Task<List<Villa>> GetAllAsync()
        {
            var villas = await villaDbContext.Villas.ToListAsync();
            return villas;
        }

        public async Task<Villa> GetByIdAsync(Guid id)
        {
            return await villaDbContext.Villas.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public Task<Villa> UpdateVillaAsync(Guid id, Villa villa)
        {
            throw new NotImplementedException();
        }
    }
}
