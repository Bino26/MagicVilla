using MagicVilla.API.Models.Domains;

namespace MagicVilla.API.Repositories.IRepository
{
    public interface IVillaNumberRepository
    {
        Task<VillaNumber>AddDetailsAsync(VillaNumber villaNumber);
        Task<VillaNumber>GetVillaDetailsByNoAsync(int No);
        Task<List<VillaNumber>>GetAllDetailsAsync();
        Task<VillaNumber>UpdateDetailsAsync(int No,VillaNumber villaNumber);

    }
}
