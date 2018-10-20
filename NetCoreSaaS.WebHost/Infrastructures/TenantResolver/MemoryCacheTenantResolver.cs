using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NetCoreSaaS.Data.Contexts;
using NetCoreSaaS.Data.Entities.Catalog;
using SaasKit.Multitenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSaaS.WebHost.Infrastructures.TenantResolver
{
    public class MemoryCacheTenantResolver : MemoryCacheTenantResolver<Tenant>
    {
        private readonly CatalogDbContext _context;

        public MemoryCacheTenantResolver(IMemoryCache cache, ILoggerFactory loggerFactory, CatalogDbContext context)
            : base(cache, loggerFactory)
        {
            _context = context;
        }

        protected override string GetContextIdentifier(HttpContext context)
        {
            return context.Request.Host.Value.ToLower();
        }

        protected override IEnumerable<string> GetTenantIdentifiers(TenantContext<Tenant> context)
        {
            return new string[] { context.Tenant.HostName };
        }

        protected override MemoryCacheEntryOptions CreateCacheEntryOptions()
        {
            return new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(new TimeSpan(1, 0, 0, 0)); // Cache for a day
        }

        protected override Task<TenantContext<Tenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<Tenant> tenantContext = null;

            var tenant = _context.Tenants.FirstOrDefault(t =>
                t.HostName.Equals(context.Request.Host.Value.ToLower()));

            if (tenant != null)
            {
                tenantContext = new TenantContext<Tenant>(tenant);
            }

            return Task.FromResult(tenantContext);
        }
    }
}
