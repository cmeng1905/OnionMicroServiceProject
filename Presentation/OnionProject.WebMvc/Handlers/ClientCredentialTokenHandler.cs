using OnionProject.WebMvc.Services.Abstractions;
using System.Net.Http.Headers;

namespace OnionProject.WebMvc.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _clientCredentialTokenService.GetToken());

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return null;
            }

            return response;
        }
    }
}
