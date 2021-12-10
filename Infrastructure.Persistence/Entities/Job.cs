using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistence.Entities
{
    public class Job
    {
        //public long Id { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public long LocationId { get; set; }
        //public int EmploymentType { get; set; }
        //public string ImageUrl { get; set; }
        //public long CategoryId { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime LastUpdate { get; set; }
        //public bool IsDeleted { get; set; }
        [Key]
        public long Id { get;  set; }

        [Required]
        [MaxLength(100)]
        public string Title { get;  set; }

        [Required]
        [MaxLength(4500)]
        public string Description { get;  set; }

        [Required]
        public long LocationId { get;  set; }
        [ForeignKey(nameof(Job.LocationId))]
        public Location Location { get;  set; }

        [Required]
        public int EmploymentType { get;  set; }

        [Required]
        public string ImageUrl { get;  set; }

        [Required]
        public long CategoryId { get;  set; }
        [ForeignKey(nameof(Job.CategoryId))]
        public Categories Categories { get;  set; }

        [Required]
        public DateTime CreateDate { get;  set; }

        public DateTime LastUpdate { get;  set; }

        [Required]
        [DefaultValue(0)]
        public bool IsDeleted { get;  set; }
    }
}
