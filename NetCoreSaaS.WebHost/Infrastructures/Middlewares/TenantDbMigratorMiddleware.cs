using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NetCoreSaaS.Data.Contexts;
using NetCoreSaaS.Data.Entities.Catalog;
using NetCoreSaaS.Data.Entities.Tenant;
using NetCoreSaaS.Data.Infrastrutures.Extensions;
using NetCoreSaaS.Data.Migrations;
using System.Threading.Tasks;

namespace NetCoreSaaS.WebHost.Infrastructures.Middlewares
{
    public class TenantDbMigratorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public TenantDbMigratorMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context, Tenant currentTenant, UserManager<TenantUser> userManager, TenantDbContext tenantDbContext)
        {
            //TODO: Improve this implementation so each http request do not have to go through this. May be setup db version number for each tenant??
            //If DB Version number of a tenant is not equal to latest then run the upgrader else just skip this
            var currentTenantConnString = currentTenant.GetConnectionString();
            var result = await DbUpgrader.UpgardeAsync(currentTenantConnString);
            if (result.Successful)
                await _next(context);
            else
                await EndRequestAsync(context, "Unable to initialize database.");
        }

        private static async Task EndRequestAsync(HttpContext context, string message)
        {
            context.Abort();
            await context.Response.WriteAsync(message);
        }
    }
}
