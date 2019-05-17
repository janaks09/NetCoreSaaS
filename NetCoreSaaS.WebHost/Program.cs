using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCoreSaaS.Data.Contexts;
using NetCoreSaaS.WebHost.Infrastructures.Helpers.DbHelper;
using System.Linq;

namespace NetCoreSaaS.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            var serviceScope = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));//Apply migration and seeding for catalogDbContext
            ApplyCatalogDbMigrationAndSeedingAsync(serviceScope);
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
                            .UseUrls("http://*.localhost:6001")
                            .UseStartup<Startup>();
        }

        private static void ApplyCatalogDbMigrationAndSeedingAsync(IServiceScopeFactory serviceScope)
        {
            using (var scope = serviceScope.CreateScope())
            {
                var catalogDbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
                catalogDbContext.Database.Migrate();

                //Seeding code goes here
                if (!catalogDbContext.Tenants.Any())
                {
                    catalogDbContext.Tenants.AddRange(SeedData.GetTestTenants());
                    catalogDbContext.SaveChanges();
                }
            }
        }
    }
}
