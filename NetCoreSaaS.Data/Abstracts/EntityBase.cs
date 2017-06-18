using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreSaaS.Data.Abstracts
{
    public abstract class EntityBase
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public virtual DateTime CreatedDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public virtual DateTime LastUpdated { get; set; }
    }
}
