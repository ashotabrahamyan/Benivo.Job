using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistence.Entities
{
    public class Bookmark
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get;  set; }

        [Required]
        public long JobId { get;  set; }
        [ForeignKey(nameof(Bookmark.JobId))]
        public Job Job { get;  set; }

        [Required]
        public long UserId { get;  set; }

        [Required]
        public DateTime CreateDate { get;  set; }

        public DateTime LastUpdate { get;  set; }

        [Required]
        [DefaultValue(0)]
        public bool IsDeleted { get;  set; }
    }
}
