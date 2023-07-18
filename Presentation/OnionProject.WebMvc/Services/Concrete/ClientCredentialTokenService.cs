using Microsoft.AspNetCore.Authentication;
using OnionProject.WebMvc.Extensions;
using OnionProject.WebMvc.Services.Abstractions;

namespace OnionProject.WebMvc.Services.Concrete
{
    public class ClientCredentialTokenService: IClientCredentialTokenService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ClientCredentialTokenService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<string> GetToken()
        {
            //var token =  _contextAccessor.HttpContext.User.Identity.GetUserAuthAccessToken();
            var token =await _contextAccessor.HttpContext.GetTokenAsync("access_token");
            return token;
        }

        public string GetUserName()
        {
            return _contextAccessor.HttpContext.User.Identity.Name;
        }

        public async Task<string> GetRefreshToken()
        {
            //var token = _contextAccessor.HttpContext.User.Identity.GetUserAuthRefreshToken();
            var token = await _contextAccessor.HttpContext.GetTokenAsync("refresh_token");
            return token;
        }
    }
}
