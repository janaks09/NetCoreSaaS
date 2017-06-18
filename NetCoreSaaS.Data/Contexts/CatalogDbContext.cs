using Microsoft.EntityFrameworkCore;

namespace NetCoreSaaS.Data.Contexts
{
    public class CatalogDbContext : DbContext
    {

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
