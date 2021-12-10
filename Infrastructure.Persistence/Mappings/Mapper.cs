using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Mappings
{
    public static class Mapper
    {
        public static Infrastructure.Persistence.Entities.Bookmark MapToBookmark(this BenivoJob.Domain.Entities.Bookmark model)
        {
            return new Infrastructure.Persistence.Entities.Bookmark
            {
                Id = model.Id,
                JobId = model.JobId,
                UserId = model.UserId,
                CreateDate = model.CreateDate,
                LastUpdate = model.LastUpdate,
                IsDeleted = model.IsDeleted
            };
        }
        public static BenivoJob.Domain.Entities.Job MapToJob(this Infrastructure.Persistence.Entities.Job model)
        {
            return new BenivoJob.Domain.Entities.Job
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                LocationId = model.LocationId,
                EmploymentType = model.EmploymentType,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                CreateDate = model.CreateDate,
                LastUpdate = model.LastUpdate,
                IsDeleted = model.IsDeleted
            };
        }
        public static List<BenivoJob.Domain.Entities.Job> MapToJobList(this List<Infrastructure.Persistence.Entities.Job> models)
        {
            return models.Select(x => x.MapToJob()).ToList();
        } 
    }
}
