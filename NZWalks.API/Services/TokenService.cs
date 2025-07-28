using Microsoft.AspNetCore.Identity;
using NZwalks.Core.Domain.RepositorieInterface;
using NZWalks.API.ServiceContracts;

namespace NZWalks.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenrepository;

        public TokenService(ITokenRepository tokenrepository)
        {
            _tokenrepository = tokenrepository;
        }

        public string CreateJwtToken(IdentityUser user, List<string> roles)
        {
            return _tokenrepository.CreateJwtToken(user, roles);
        }
    }
}
