using Microsoft.EntityFrameworkCore;
using NetCoreSaaS.Data.Entities.Catalog;
using NetCoreSaaS.Data.Infrastrutures.Extensions;

namespace NetCoreSaaS.Data.Contexts
{
    public class CatalogDbContext : DbContext
    {

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.TenantConfiguration();
        }


    }
}
