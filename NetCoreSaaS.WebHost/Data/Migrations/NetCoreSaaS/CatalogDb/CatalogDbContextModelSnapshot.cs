using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetCoreSaaS.Data.Contexts;

namespace NetCoreSaaS.WebHost.Data.Migrations.NetCoreSaaS.CatalogDb
{
    [DbContext(typeof(CatalogDbContext))]
    partial class CatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCoreSaaS.Data.Entities.Catalog.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Database")
                        .IsRequired();

                    b.Property<string>("DbConnectionString")
                        .IsRequired();

                    b.Property<string>("HostName")
                        .IsRequired();

                    b.Property<bool>("IsEnabled");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Server")
                        .IsRequired();

                    b.Property<int>("Subscription");

                    b.Property<DateTime>("SubscriptionExipreDate");

                    b.Property<string>("TenantId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tenant");
                });
        }
    }
}
