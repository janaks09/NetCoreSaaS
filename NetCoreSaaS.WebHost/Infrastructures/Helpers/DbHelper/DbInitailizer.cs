using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCoreSaaS.Data.Contexts;
using System.Linq;

namespace NetCoreSaaS.WebHost.Infrastructures.Helpers.DbHelper
{
    public static class DbInitailizer
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var systemDbContext = serviceScope.ServiceProvider.GetRequiredService<SystemDbContext>();
                systemDbContext.Database.Migrate();


                var catalogDbContext = serviceScope.ServiceProvider.GetRequiredService<CatalogDbContext>();
                catalogDbContext.Database.Migrate();

                //Seeding code goes here

                if (!catalogDbContext.Tenants.Any())
                {
                    foreach (var tenant in SeedData.GetTestTenants())
                    {
                        catalogDbContext.Tenants.Add(tenant);
                    }

                    catalogDbContext.SaveChanges();
                }

            }
        }
    }
}
