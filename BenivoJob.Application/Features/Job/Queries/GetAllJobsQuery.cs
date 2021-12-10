using Infrastructure.Shared.DTOs;
using MediatR;

namespace BenivoJob.Application.Features.Job.Queries
{
    public class GetAllJobsQuery : IRequest<PageableCollection<Domain.Entities.Job>>
    {

        public long? LocationId { get; set; }
        public int? EmploymentType { get; set; }
        public long? CategoryId { get; set; }
        public string Text { get; set; }
        public short Offset { get; set; }
        public short Limit { get; set; }
    }
}
