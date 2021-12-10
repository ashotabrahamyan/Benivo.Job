using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistence.Entities
{
    public class Location
    {
        //public long Id { get; set; }
        //public string Country { get; set; }
        //public string City { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime LastUpdate { get; set; }
        //public bool IsDeleted { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get;  set; }

        [Required]
        [MaxLength(100)]
        public string City { get;  set; }

        [Required]
        public DateTime CreateDate { get;  set; }

        public DateTime LastUpdate { get;  set; }

        [Required]
        [DefaultValue(0)]
        public bool IsDeleted { get;  set; }
    }
}
