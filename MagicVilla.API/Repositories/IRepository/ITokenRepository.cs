using Microsoft.AspNetCore.Identity;

namespace MagicVilla.API.Repositories.IRepository
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user,List<string>roles);
    }
}
