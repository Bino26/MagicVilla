using MagicVilla.API.Data;
using MagicVilla.API.Models.Domains;
using MagicVilla.API.Models.DTOs;
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

        public async Task<List<Villa>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var villas = villaDbContext.Villas.AsQueryable();
                

            //filtering

            if ((string.IsNullOrWhiteSpace(filterOn) == false && (string.IsNullOrWhiteSpace(filterQuery) == false))){
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    villas = villas.Where(x => x.Name.Contains(filterQuery));
                }
            }
            // Sorting 
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    villas = isAscending ? villas.OrderBy(x => x.Name) : villas.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Rate", StringComparison.OrdinalIgnoreCase))
                {
                    villas = isAscending ? villas.OrderBy(x => x.Rate) : villas.OrderByDescending(x => x.Rate);
                }
            }
            // Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await villas.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Villa> GetByIdAsync(Guid id)
        {
            return await villaDbContext.Villas.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Villa> UpdateVillaAsync(Guid id, Villa villa)
        {
            var existingVilla = await villaDbContext.Villas.FirstOrDefaultAsync(x => x.Id == id);
            if(villa is null)
            {
                return null;
            }
            existingVilla.Name = villa.Name;
            existingVilla.Details = villa.Details;
            existingVilla.Rate = villa.Rate;
            existingVilla.ImageUrl = villa.ImageUrl;
            existingVilla.Amenity = villa.Amenity;
            existingVilla.Sqft = villa.Sqft;
            existingVilla.UpdatedDate = DateTime.UtcNow;

            await villaDbContext.SaveChangesAsync();

            return existingVilla;

        }
    }
}
