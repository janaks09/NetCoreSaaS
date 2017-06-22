using System;
using System.Collections.Generic;
using NetCoreSaaS.Data.Entities.Catalog;

namespace NetCoreSaaS.WebHost.Infrastructures.Helpers.DbHelper
{
    public static class SeedData
    {

        public static List<Tenant> GetTestTenants()
        {
            var tenats = new List<Tenant>
            {
                new Tenant
                {
                    TenantId = "786931ff-d775-4606-b5ec-aef26e3f7420",
                    Name = "J-Shop",
                    HostName = "localhost:6001",
                    IsEnabled = true,
                    DbConnectionString = @"Server=(localdb)\mssqllocaldb;Database=Tenant_786931ff-d775-4606-b5ec-aef26e3f7420;Trusted_Connection=True;MultipleActiveResultSets=true",
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },

                new Tenant
                {
                    TenantId = "14e0af40-3284-4914-bbb2-66330a24482e",
                    Name = "R-Shop",
                    HostName = "localhost:6002",
                    IsEnabled = true,
                    DbConnectionString = @"Server=(localdb)\mssqllocaldb;Database=Tenant_14e0af40-3284-4914-bbb2-66330a24482e;Trusted_Connection=True;MultipleActiveResultSets=true",
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                }
            };
            return tenats;
        }



    }
}
