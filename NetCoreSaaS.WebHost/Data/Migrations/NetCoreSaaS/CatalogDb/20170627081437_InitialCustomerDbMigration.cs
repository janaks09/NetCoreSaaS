using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetCoreSaaS.WebHost.Data.Migrations.NetCoreSaaS.CatalogDb
{
    public partial class InitialCustomerDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Database = table.Column<string>(nullable: false),
                    DbConnectionString = table.Column<string>(nullable: false),
                    HostName = table.Column<string>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Server = table.Column<string>(nullable: false),
                    Subscription = table.Column<int>(nullable: false),
                    SubscriptionExipreDate = table.Column<DateTime>(nullable: false),
                    TenantId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
