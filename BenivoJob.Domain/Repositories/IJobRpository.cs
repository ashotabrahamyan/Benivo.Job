using Infrastructure.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenivoJob.Domain.Repositories
{
    public interface IJobRpository
    {
        Task<PageableCollection<Domain.Entities.Job>> GetJobsFiltered(
            dynamic filter,
            long? locationId,
            int? employmentType,
            long? categoryId,
            string text,
            short Offset,
            short limit
            );
        Task<Entities.Job> GeJobById(long id);
        Task<List<BenivoJob.Domain.Entities.Job>> GetJobs();
    }
}
