using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Abstractions.UnitOfWork;
using OnionProject.Application.Repositories.User;
using OnionProject.Persistence.Configurations;
using OnionProject.Persistence.Contexts;
using OnionProject.Persistence.Repositories.User;
using OnionProject.Persistence.Services;
using OnionProject.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CmengDbContext>(options =>
            {
                options.UseSqlServer(Configuration.MssqlConnectionString);
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUserAuthService, UserAuthService>();
            services.AddScoped<IAspNetUserService, UserService>();
            services.AddScoped<IUnitOfWorkRepo, UnitOfWorkRepo>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
