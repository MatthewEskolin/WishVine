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

    public UserInfo()
    {

    }


    public bool IsAuthenticated { get; }
    public string UserName { get; } = string.Empty;
    public Dictionary<string, string> ExposedClaims { get; } = new();

}