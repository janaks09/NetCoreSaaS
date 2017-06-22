using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

            services.AddIdentity<TenantUser, IdentityRole>
                (
                    options =>
                    {
                        options.Cookies.ApplicationCookie.CookieName = "Cookies";
                    }
                )
                .AddEntityFrameworkStores<TenantDbContext>()
                .AddDefaultTokenProviders();


            return services;
        }


        public static IServiceCollection AddContexts(this IServiceCollection services, IConfigurationRoot configuration, string migrationsAssembly)
        {

            services.AddSystemDataContext(configuration, migrationsAssembly)
                .AddCustomerDataContext(configuration, migrationsAssembly)
                .AddTenantDbContext(configuration, migrationsAssembly);

            return services;
        }

    }
}
