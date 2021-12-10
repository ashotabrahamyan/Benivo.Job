using System;

namespace BenivoJob.Domain.Entities
{
    public class Job
    {
        public Job()
        {
        }

        public Job(string title, string description, long locationId, int employmentType, string imageUrl, long categoryId,
           DateTime createDate, DateTime lastUpdate, bool isDeleted)
        {
            
            Title = title;
            Description = description;
            LocationId = locationId;
            EmploymentType = employmentType;
            ImageUrl = imageUrl;
            CategoryId = categoryId;
            CreateDate = createDate;
            LastUpdate = lastUpdate;
            IsDeleted = isDeleted;
        }

        public long Id { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public long LocationId { get;  set; }
        public int EmploymentType { get;  set; }
        public string ImageUrl { get;  set; }
        public long CategoryId { get;  set; }
        public DateTime CreateDate { get;  set; }
        public DateTime LastUpdate { get;  set; }
        public bool IsDeleted { get;  set; }

        public static Job Load(long id, string title, string description, long locationId, int employmentType, string imageUrl, long categoryId,
           DateTime createDate, DateTime lastUpdate, bool isDeleted)
        {
            var job = new Job
            {
                Id = id,
                Title = title,
                Description = description,
                LocationId = locationId,
                EmploymentType = employmentType,
                ImageUrl = imageUrl,
                CategoryId = categoryId,
                CreateDate = createDate,
                LastUpdate = lastUpdate,
                IsDeleted = isDeleted
            };
            return job;
        }
    }
}
