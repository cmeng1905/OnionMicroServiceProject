using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnionProject.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(s => s.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
