using System;
using System.Collections.Generic;
using NetCoreSaaS.Core.Constants;
using NetCoreSaaS.Core.ENums;
using NetCoreSaaS.Data.Entities.Catalog;

namespace NetCoreSaaS.WebHost.Infrastructures.Helpers.DbHelper
{
    public static class SeedData
    {

        public static IEnumerable<Tenant> GetTestTenants()
        {
            var tenats = new List<Tenant>
            {
                new Tenant
                {
                    TenantId = "786931ff-d775-4606-b5ec-aef26e3f7420",
                    Name = "J-Shop",
                    HostName = "tenant1.localhost:6001",
                    Subscription = (int)TenantSubscription.Trial,
                    Server = TenantConstant.LocalServer,
                    Database = "NCS_786931ff-d775-4606-b5ec-aef26e3f7420",
                    SubscriptionExipreDate = DateTime.UtcNow.AddMonths(3), //3 month trial period
                    IsEnabled = true,
                    DbConnectionString = TenantConstant.LocalDbConnectionString,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },

                new Tenant
                {
                    TenantId = "14e0af40-3284-4914-bbb2-66330a24482e",
                    Name = "R-Shop",
                    HostName = "tenant2.localhost:6001",
                    IsEnabled = true,
                    Server = TenantConstant.LocalServer,
                    Database = "NCS_14e0af40-3284-4914-bbb2-66330a24482e",
                    Subscription = (int)TenantSubscription.Pro,
                    SubscriptionExipreDate = DateTime.UtcNow.AddYears(1), //1 year timeline for pro
                    DbConnectionString = TenantConstant.LocalDbConnectionString,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                }
            };

            return tenats;
        }
    }
}
