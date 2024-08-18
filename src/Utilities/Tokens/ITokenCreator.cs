namespace ShooterLink.Utilities.Tokens;

public interface ITokenCreator
{
    string CreateToken(string userName, string userId, List<string> userRoles);
}
