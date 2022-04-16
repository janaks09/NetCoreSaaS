using System;
using System.ComponentModel.DataAnnotations;
using NetCoreSaaS.Data.Abstracts;

namespace NetCoreSaaS.Data.Entities.Catalog
{
    public class Tenant : EntityBase
    {
        [Required]
        public string TenantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string HostName { get; set; }

        [Required]
        public string Server { get; set; }

        [Required]
        public string Database { get; set; }

        public bool IsEnabled { get; set; }

        public int Subscription { get; set; }

        public DateTime SubscriptionExipreDate { get; set; }

        [Required]
        public string DbConnectionString { get; set; }
    }
}
