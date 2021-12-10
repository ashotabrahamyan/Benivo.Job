using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistence.Entities
{
    public class Categories
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get;  set; }

        [Required]
        [MaxLength(50)]
        public string Name { get;  set; }

        [Required]
        public DateTime CreateDate { get;  set; }

        public DateTime LastUpdate { get;  set; }

        [Required]
        [DefaultValue(0)]
        public bool IsDeleted { get;  set; }
    }
}
