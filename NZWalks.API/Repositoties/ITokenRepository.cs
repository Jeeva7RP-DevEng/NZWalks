using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repositoties
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
