using MagicVilla.API.Models.Domains;

namespace MagicVilla.API.Repositories.IRepository
{
    public interface IVillaRepository
    {
        public Task<List<Villa>> GetAllAsync(string? filterOn=null,string?filterQuery=null, string?sortBy=null,bool isAscending=true, int pageNumber = 1, int pageSize = 1000);
        public Task<Villa> GetByIdAsync(Guid id);

        public Task<Villa> CreateVillaAsync(Villa villa);

        public Task<Villa> UpdateVillaAsync(Guid id, Villa villa);

        public Task<Villa> DeleteByIdAsync(Guid id);

        public Task<List<Villa>> DeleteAllVillaAsync();
    }
}
