using MagicVilla.API.Models.Domains;

namespace MagicVilla.API.Repositories.IRepository
{
    public interface IVillaNumberRepository
    {
        Task<VillaNumber> AddNumberAsync(VillaNumber number);
        Task<VillaNumber>GetVillaNumberByIdAsync(int numberId);
        Task<List<VillaNumber>> GetAllNumbersAsync();
        Task<VillaNumber> UpdateNumberAsync(int numberId , VillaNumber number);

    }
}
