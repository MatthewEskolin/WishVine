using System.Net.Http.Headers;
using System.Net.Http.Json;
using WishVine.Shared;
using WishVine.Shared.Identity;

namespace WishVine.Client.Services.Internal
{
    public class IdentityAPI
    {
        private readonly HttpClient _httpClient;

        public IdentityAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResult> Login(LoginModel loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("identity/login", loginRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return LoginResult.Failure(await result.Content.ReadAsStringAsync());
            }

            result.EnsureSuccessStatusCode();

            return LoginResult.Success();
        }

        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("identity/Logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task<RegisterResult> Register(RegisterParameters registerParameters)
        {
            //var stringContent = new StringContent(JsonSerializer.Serialize(registerParameters), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsJsonAsync("identity/Register", registerParameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return RegisterResult.Failure(await result.Content.ReadAsStringAsync());
            }
            result.EnsureSuccessStatusCode();

            return RegisterResult.Success();
        }

        public async Task<UserInfo> GetUserInfo()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "identity/UserInfo");
            requestMessage.Headers.CacheControl = new CacheControlHeaderValue { NoCache = true };

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<UserInfo>();
            return result;


        }
    }
}
