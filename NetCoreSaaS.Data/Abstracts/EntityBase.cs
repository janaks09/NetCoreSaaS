using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreSaaS.Data.Abstracts
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual DateTime CreatedDate { get; set; }

        [Required]
        public virtual DateTime LastUpdated { get; set; }
    }
}
