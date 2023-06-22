using OnionProject.WebMvc.Handlers;
using OnionProject.WebMvc.Models;
using OnionProject.WebMvc.Services.Abstractions;
using OnionProject.WebMvc.Services.Concrete;

namespace OnionProject.WebMvc.Extensions
{
    public static class ServiceExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services,IConfiguration configuration)
        {
            var appSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
            services.AddSingleton(appSettings);
            services.AddHttpContextAccessor();

            services.AddScoped<ClientCredentialTokenHandler>();
            services.AddScoped<IAuthApiService, AuthApiService>();
            services.AddScoped<IProductApiService, ProductApiService>();
            services.AddScoped<IClientCredentialTokenService, ClientCredentialTokenService>();

            services.AddHttpClient<IAuthApiService, AuthApiService>(opt =>
            {
                opt.BaseAddress = new Uri($"{appSettings.GatewayBaseUri}/{appSettings.Auth.Path}");
            });

            services.AddHttpClient<IProductApiService, ProductApiService>(opt =>
            {
                opt.BaseAddress = new Uri($"{appSettings.GatewayBaseUri}/{appSettings.Product.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
        }
    }
}
