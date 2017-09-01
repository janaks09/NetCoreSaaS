using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreSaaS.Data.Contexts;

namespace NetCoreSaaS.WebHost.Infrastructures.Extensions
{
    public static class DbContextExtension
    {

        public static IServiceCollection AddSystemDataContext(this IServiceCollection services, IConfiguration configuration, string migrationAssembly)
        {
            services.AddDbContext<SystemDbContext>(builder =>
                builder.UseSqlServer(configuration.GetConnectionString("SystemConnection"),
                    options => options.MigrationsAssembly(migrationAssembly)));
            return services;
        }


        public static IServiceCollection AddCustomerDataContext(this IServiceCollection services, IConfiguration configuration, string migrationAssembly)
        {
            services.AddDbContext<CatalogDbContext>(builder =>
                builder.UseSqlServer(configuration.GetConnectionString("CatalogConnection"),
                    options => options.MigrationsAssembly(migrationAssembly)));
            return services;
        }


        public static IServiceCollection AddTenantDbContext(this IServiceCollection services, IConfiguration configuration, string migrationAssembly)
        {

            services.AddDbContext<TenantDbContext>();
            return services;
        }


    }
}
