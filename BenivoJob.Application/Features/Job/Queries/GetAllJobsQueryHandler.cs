using BenivoJob.Application.Helpers;
using BenivoJob.Application.Interfaces;
using BenivoJob.Domain.Repositories;
using Infrastructure.Shared.DTOs;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BenivoJob.Application.Features.Job.Queries
{
    public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, PageableCollection<Domain.Entities.Job>>
    {
        private readonly IJobRpository _jobRpository;
        private readonly ICachedJobItemsService _cachedJobItemsService;

        public GetAllJobsQueryHandler(IJobRpository jobRpository, ICachedJobItemsService cachedJobItemsService)
        {
            _jobRpository = jobRpository;
            _cachedJobItemsService = cachedJobItemsService ?? throw new ArgumentNullException(nameof(cachedJobItemsService));
        }
        public async Task<PageableCollection<Domain.Entities.Job>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            var data = _cachedJobItemsService.GetCachedJobItems(Constants.Jobs).ToList();
            if (data == null)
            {
                data = await _jobRpository.GetJobs();
                _cachedJobItemsService.SetCachedJobItems(Constants.Jobs, data);
            }

            return await _jobRpository.GetJobsFiltered(
                  data,
                   request.LocationId,
                   request.EmploymentType,
                   request.CategoryId,
                   request.Text,
                   request.Offset,
                   request.Limit);
        }
    }
}