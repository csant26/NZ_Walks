using Microsoft.AspNetCore.Identity;

namespace NZWalks_API.Repository
{
    public interface IToken
    {
        string CreateJWTToken(IdentityUser identityUser, List<string> roles);
    }
}
