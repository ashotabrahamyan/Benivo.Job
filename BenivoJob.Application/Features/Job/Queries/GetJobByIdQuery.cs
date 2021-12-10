using MediatR;

namespace BenivoJob.Application.Features.Job.Queries
{
    public class GetJobByIdQuery : IRequest<Domain.Entities.Job>
    {
        public long Id { get; set; }
    }
}
