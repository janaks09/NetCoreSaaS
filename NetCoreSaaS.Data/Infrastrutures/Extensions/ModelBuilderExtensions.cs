using Microsoft.EntityFrameworkCore;
using NetCoreSaaS.Data.Entities.Catalog;

namespace NetCoreSaaS.Data.Infrastrutures.Extensions
{
    public static class ModelBuilderExtensions
    {

        public static ModelBuilder TenantConfiguration(this ModelBuilder builder)
        {
            builder.Entity<Tenant>()
                .ToTable("Tenant");

            return builder;

        }

    }
}
