using MagicVilla.API.Data;
using MagicVilla.API.Repositories.IRepository;
using Microsoft.AspNetCore.Identity;

namespace MagicVilla.API.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string CreateJwtToken(IdentityUser user, List<string> roles)
        {
            throw new NotImplementedException();
        }
    }
}
