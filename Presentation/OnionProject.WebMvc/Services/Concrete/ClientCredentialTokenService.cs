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
    }
}
