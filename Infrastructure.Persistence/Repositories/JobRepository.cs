using AutoMapper;
using BenivoJob.Domain.Entities;
using BenivoJob.Domain.Repositories;
using Infrastructure.Persistence.Mappings;
using Infrastructure.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class JobRepository : IJobRpository
    {
        private readonly JobDbContext _jobDbContext;
        private readonly IMapper _mapper;
        public JobRepository(JobDbContext jobDbContext, IMapper mapper)
        {
            _jobDbContext = jobDbContext ?? throw new ArgumentNullException(nameof(jobDbContext));
            _mapper = mapper;
        }
        public async Task<List<BenivoJob.Domain.Entities.Job>> GetJobs()
        {
            return (await _jobDbContext.Job.ToListAsync())?.MapToJobList();
        }

        public async Task<PageableCollection<BenivoJob.Domain.Entities.Job>> GetJobsFiltered(dynamic filter, long? locationId, int? employmentType, long? categoryId, string text, short Offset, short limit)
        {
            var collection = filter as IQueryable<Infrastructure.Persistence.Entities.Job>;

            if (locationId.HasValue)
                collection = collection.Where(x => x.LocationId == locationId);
            if (employmentType.HasValue)
                collection = collection.Where(x => x.EmploymentType == employmentType);
            if (categoryId.HasValue)
                collection = collection.Where(x => x.CategoryId == categoryId);
            if (!string.IsNullOrEmpty(text))
                collection = collection.Where(x => x.Title.Contains(text));

            var queryResultPage = collection
                      .Skip(Offset * (limit - 1)).Take(limit);

            var result = await queryResultPage.ToListAsync();
            var res = result.MapToJobList();
            var pageableCollection = new PageableCollection<Job>();
            pageableCollection.Items = res;
            pageableCollection.Total = collection.Count();
            return pageableCollection; 
        }
        public async Task<Job> GeJobById(long id)
        {
            var job = await _jobDbContext.Job.FirstOrDefaultAsync(x => x.Id == id); 
            return job.MapToJob(); 
        }


    }
}
