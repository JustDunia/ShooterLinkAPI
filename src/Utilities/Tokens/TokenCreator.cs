using FastEndpoints.Security;
using Microsoft.Extensions.Options;
using ShooterLink.Utilities.ApplicationOptions;

namespace ShooterLink.Utilities.Tokens;

public class TokenCreator(IOptions<KeysOptions> options) : ITokenCreator
{
    public string CreateToken(string userName, string userId, List<string> userRoles)
    {
        return JwtBearer.CreateToken(
            o =>
            {
                o.SigningKey = options.Value.SigningKey;
                o.ExpireAt = DateTime.UtcNow.AddDays(1);
                o.User.Roles.Add([.. userRoles]);
                o.User.Claims.Add(("UserName", userName));
                o.User["UserId"] = userId;
            });
    }
}
