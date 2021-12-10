using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BenivoJob.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }
        //  userid from by claims from token
        public long UserId { get { return 123; } }
        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected MediatR.IMediator Mediator { get; private set; }


    }
}
