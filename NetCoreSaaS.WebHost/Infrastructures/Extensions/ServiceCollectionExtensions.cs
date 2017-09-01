using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreSaaS.Data.Contexts;
using NetCoreSaaS.Data.Entities.Tenant;

namespace NetCoreSaaS.WebHost.Infrastructures.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {

            services.AddIdentity<TenantUser, IdentityRole>()
                .AddEntityFrameworkStores<TenantDbContext>()
                .AddDefaultTokenProviders();


            return services;
        }


        public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration, string migrationsAssembly)
        {

            services.AddSystemDataContext(configuration, migrationsAssembly)
                .AddCustomerDataContext(configuration, migrationsAssembly)
                .AddTenantDbContext(configuration, migrationsAssembly);

            return services;
        }

    }
}
