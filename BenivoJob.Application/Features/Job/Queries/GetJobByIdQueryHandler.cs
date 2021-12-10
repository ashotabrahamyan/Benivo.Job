using BenivoJob.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BenivoJob.Application.Features.Job.Queries
{
    public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, Domain.Entities.Job>
    {
        private readonly IJobRpository _jobRpository;
        public GetJobByIdQueryHandler(IJobRpository jobRpository)
        {
            _jobRpository = jobRpository;
        }
        public async Task<Domain.Entities.Job> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            return await _jobRpository.GeJobById(request.Id);
        }
    }
}
