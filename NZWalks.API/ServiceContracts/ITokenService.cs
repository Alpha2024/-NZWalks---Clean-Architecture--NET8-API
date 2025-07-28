using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.ServiceContracts
{
    public interface ITokenService
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
