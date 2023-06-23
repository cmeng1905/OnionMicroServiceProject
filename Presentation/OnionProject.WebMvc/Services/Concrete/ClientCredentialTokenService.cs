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

        public string GetToken()
        {
            var token =  _contextAccessor.HttpContext.User.Identity.GetUserAuthAccessToken();
            return token;
        }

        public string GetUserName()
        {
            return _contextAccessor.HttpContext.User.Identity.Name;
        }

        public string GetRefreshToken()
        {
            var token = _contextAccessor.HttpContext.User.Identity.GetUserAuthRefreshToken();
            return token;
        }
    }
}
