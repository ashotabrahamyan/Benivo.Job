using BenivoJob.Application.DTOs;
using BenivoJob.Application.Features.Job.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BenivoJob.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : BaseController
    {
        public JobController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("GetAllJobs")]
        public async Task<object> GetAllJobs([FromQuery]GetAllJobsRequest request)
        {
            var query = new GetAllJobsQuery
            {
                CategoryId = request.CategoryId,
                EmploymentType = request.EmploymentType,
                LocationId = request.LocationId,
                Text = request.SearchText,
                Limit = request.Limit,
                Offset = request.Offset
            };
           
            return await Mediator.Send(query);
        }
       
        [HttpGet]
        [Route("GetJobDetails")]
        public async Task<object> GetJobDetailsAsync(long id)
        {

            var query = new GetJobByIdQuery
            {
                Id = id ,
            };

            return await Mediator.Send(query);
        }


    }
}
