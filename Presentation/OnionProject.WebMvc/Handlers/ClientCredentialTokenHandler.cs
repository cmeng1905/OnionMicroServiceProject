using OnionProject.WebMvc.Exceptions;
using OnionProject.WebMvc.Services.Abstractions;
using System.Net.Http.Headers;

namespace OnionProject.WebMvc.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;
        private IAuthApiService _authApiService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService, IAuthApiService authApiService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
            _authApiService = authApiService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _clientCredentialTokenService.GetToken());

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var refreshToken = _clientCredentialTokenService.GetRefreshToken();
                var username = _clientCredentialTokenService.GetUserName();
                var result = await _authApiService.RefreshLoginAsync(username, refreshToken);
                if (result)
                {
                    var token = _clientCredentialTokenService.GetToken();
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    response = await base.SendAsync(request, cancellationToken);
                }
                else throw new UnAuthorizeException();
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnAuthorizeException();
            }

            return response;
        }
    }
}
