using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreSaaS.Data.Entities.Catalog;
using NetCoreSaaS.Data.Entities.Tenant;

namespace NetCoreSaaS.Data.Contexts
{
    public sealed class TenantDbContext : IdentityDbContext<TenantUser>
    {

        private readonly Tenant _currentTenant;
        public TenantDbContext(Tenant currentTenant)
        {
            _currentTenant = currentTenant;

            //TODO: Made Database.Migrate() Compatible.
            //tenant Database is always growing so new migration will happen time to time so Database.Migrate is necessary
            var dbstatus = Database.EnsureCreated();

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_currentTenant.DbConnectionString, options => options.MigrationsAssembly("AspNetCoreMultitenantSample.Web"));

            base.OnConfiguring(optionsBuilder);
        }

    }
}
