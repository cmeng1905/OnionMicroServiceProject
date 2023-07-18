using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json.Linq;
using OnionProject.Application.Dtos.Response;
using OnionProject.Application.Features.Commands.LoginUser;
using OnionProject.Application.Features.Commands.RefreshLoginUser;
using OnionProject.WebMvc.Services.Abstractions;
using System.Globalization;
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

        public async Task<bool> LoginAsync(string username, string password)
        {
            var authenticateResult = await _client.PostAsJsonAsync("Auth", new LoginUserCommandRequest
            {
                Username = username,
                Password = password
            });
            if (authenticateResult.IsSuccessStatusCode)
            {
                var response = await authenticateResult.Content.ReadFromJsonAsync<Response<LoginUserCommandResponse>>();
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(response.Data.TokenDto.Token);
                var claimsIdentity = new ClaimsIdentity(jwt.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "unique_name", "role");
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                    IsPersistent = true
                };

                authProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken{ Name="access_token",Value=response.Data.TokenDto.Token},
                   new AuthenticationToken{ Name="refresh_token",Value=response.Data.TokenDto.RefreshToken},
                      new AuthenticationToken{ Name="expires_in",Value= response.Data.TokenDto.RefreshTokenExpireDate.ToString("o",CultureInfo.InvariantCulture)}
            });


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

        public async Task<bool> RefreshLoginAsync(string username, string refreshToken)
        {
            var authenticateResult = await _client.PostAsJsonAsync("Refresh", new RefreshLoginUserCommandRequest
            {
                UserName = username,
                RefreshToken = refreshToken
            });
            if (authenticateResult.IsSuccessStatusCode)
            {
                var response = await authenticateResult.Content.ReadFromJsonAsync<Response<RefreshLoginUserCommandResponse>>();
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(response.Data.TokenDto.Token);
                var claimsIdentity = new ClaimsIdentity(jwt.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "unique_name", "role");
                //var authProperties = new AuthenticationProperties
                //{
                //    AllowRefresh = true,
                //    ExpiresUtc = DateTime.Now.AddDays(5),
                //    IsPersistent = true
                //};

                var authenticationResult = await _httpContextAccessor.HttpContext.AuthenticateAsync();

                var authProperties = authenticationResult.Properties;
                authProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken{ Name="access_token",Value=response.Data.TokenDto.Token},
                   new AuthenticationToken{ Name="refresh_token",Value=response.Data.TokenDto.RefreshToken},

                      new AuthenticationToken{ Name="expires_in",Value= response.Data.TokenDto.RefreshTokenExpireDate.ToString("o",CultureInfo.InvariantCulture)}
            });
                await _httpContextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return true;
            }
            return false;
        }
    }

}
