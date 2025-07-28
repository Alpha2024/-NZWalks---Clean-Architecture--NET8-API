

using Microsoft.AspNetCore.Identity;

namespace NZwalks.Core.Domain.RepositorieInterface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
