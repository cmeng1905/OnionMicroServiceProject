using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json.Linq;
using OnionProject.Application.Dtos.Response;
using OnionProject.Application.Features.Queries.LoginUser;
using OnionProject.WebMvc.Services.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace OnionProject.WebMvc.Services.Concrete
{
    public class AuthApiService : IAuthApiService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthApiService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var authenticateResult = await _client.PostAsJsonAsync("Auth", new LoginUserQueryRequest
            {
                Username = username,
                Password = password
            });
            if (authenticateResult.IsSuccessStatusCode)
            {
                var response = await authenticateResult.Content.ReadFromJsonAsync<Response<LoginUserQueryResponse>>();
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(response.Data.Token);
                var claims = new List<Claim> { new Claim("UserAuthToken", response.Data.Token) };
                claims.AddRange(jwt.Claims);
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "unique_name", "role");
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                    IsPersistent = true
                };
                await _httpContextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return true;
            }
            return false;
        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }

}
