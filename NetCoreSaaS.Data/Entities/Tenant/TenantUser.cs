using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NetCoreSaaS.Data.Entities.Tenant
{
    public class TenantUser : IdentityUser
    {
        [Required]
        public string TenantId { get; set; }

        public int Status { get; set; } //1=> All Good, 2=> Blocked

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
