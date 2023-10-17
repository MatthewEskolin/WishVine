using System.Security.Claims;

namespace WishVine.Shared.Identity;

public class UserInfo
{
    public UserInfo(ClaimsPrincipal claimsPrincipal)
    {
        IsAuthenticated = claimsPrincipal.Identity?.IsAuthenticated ?? false;

        UserName = claimsPrincipal.Identity?.Name ?? string.Empty;

        ExposedClaims = claimsPrincipal.Claims.ToDictionary(c => c.Type, c => c.Value);
    }

    public bool IsAuthenticated { get; }
    public string UserName { get; }
    public Dictionary<string, string> ExposedClaims { get; }

}