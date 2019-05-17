using Microsoft.AspNetCore.Builder;

namespace NetCoreSaaS.WebHost.Infrastructures.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseTenantDbMigrator(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TenantDbMigratorMiddleware>();
        }

        //Add other here
    }
}
