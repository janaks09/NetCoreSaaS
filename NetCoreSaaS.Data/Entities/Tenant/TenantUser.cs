using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NetCoreSaaS.Data.Entities.Tenant
{
    public class TenantUser : IdentityUser
    {

        [Required]
        public string TenantId { get; set; }

        [Required]
        public int Status { get; set; } //1=> All Good, 2=> Blocked

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

    }
}
