using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreSaaS.Data.Entities.Catalog;
using NetCoreSaaS.Data.Entities.Tenant;
using NetCoreSaaS.Data.Infrastrutures.Extensions;

namespace NetCoreSaaS.Data.Contexts
{
    public sealed class TenantDbContext : IdentityDbContext<TenantUser>
    {

        private readonly Tenant _currentTenant;
        public TenantDbContext(Tenant currentTenant)
        {
            _currentTenant = currentTenant;

            Database.EnsureCreated();

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_currentTenant != null)
            {
                optionsBuilder.UseSqlServer(_currentTenant.GetConnectionString(), options => options.MigrationsAssembly("NetCoreSaaS.WebHost"));
            }

            base.OnConfiguring(optionsBuilder);
        }

    }
}
