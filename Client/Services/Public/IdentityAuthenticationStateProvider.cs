using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using WishVine.Client.Services.Internal;
using WishVine.Shared;
using WishVine.Shared.Identity;

namespace WishVine.Client.Services.Public


{
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private UserInfo? _userInfoCache;
        private readonly IdentityAPI _authorizeApi;

        public IdentityAuthenticationStateProvider(IdentityAPI identityAPI)
        {
            this._authorizeApi = identityAPI;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var result = await _authorizeApi.Login(loginModel);
            if (result.LoginSuccess)
            {
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            }
            return result;
        }

        public async Task<RegisterResult> Register(RegisterParameters registerParameters)
        {
            RegisterResult result = await _authorizeApi.Register(registerParameters);
            if (result.RegisterSuccess)
            {

                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            }

            return result;
        }

        public async Task Logout()
        {
            await _authorizeApi.Logout();
            _userInfoCache = null!;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private async Task<UserInfo> GetUserInfo()
        {
            if (_userInfoCache != null && _userInfoCache.IsAuthenticated) return _userInfoCache;
            _userInfoCache = await _authorizeApi.GetUserInfo();
            return _userInfoCache;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await GetUserInfo();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, userInfo.UserName) }.Concat(userInfo.ExposedClaims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}







