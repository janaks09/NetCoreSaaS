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


                var customerDbContext = serviceScope.ServiceProvider.GetRequiredService<CatalogDbContext>();
                customerDbContext.Database.Migrate();


                //Seeding code goes here

                if (!customerDbContext.Tenants.Any())
                {
                    foreach (var tenant in SeedData.GetTestTenants())
                    {
                        customerDbContext.Tenants.Add(tenant);
                    }

                    customerDbContext.SaveChanges();
                }

            }
        }
    }
}
