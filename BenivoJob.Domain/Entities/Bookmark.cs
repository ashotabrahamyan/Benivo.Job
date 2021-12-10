using System;

namespace BenivoJob.Domain.Entities
{
    public class Bookmark
    {
        public Bookmark()
        { 
        }
        public Bookmark(long jobId, long userId, DateTime createDate, DateTime lastUpdate, bool isDeleted)
        { 
            JobId = jobId;
            UserId = userId;
            CreateDate = createDate;
            LastUpdate = lastUpdate;
            IsDeleted = isDeleted;
        }
        public long Id { get; set; }
        public long JobId { get; set; }
        public long UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }

        public static Bookmark Load(long id, long jobId, long userId, DateTime createDate, DateTime lastUpdate, bool isDeleted)
        {
            var bookmark = new Bookmark
            {
                Id = id,
                JobId = jobId,
                UserId = userId,
                CreateDate = createDate,
                LastUpdate = lastUpdate,
                IsDeleted = isDeleted
            };
            return bookmark;
        } 
    }  
}
