using BenivoJob.Application.DTOs;
using BenivoJob.Application.Features.Bookmark.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BenivoJob.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookmarkController : BaseController
    {
        private readonly ILogger _logger; 
        public BookmarkController(IMediator mediator, ILogger<BookmarkController> logger) : base(mediator)
        {
            _logger = logger;
            
        } 
        [HttpPost]
        [Route("AddBookmark")]
        public async Task<bool> AddBookmark(AddBookmarkRequest request)
        {
            _logger.LogInformation($"Fetching all the Students from the storage");
           
            try
            {
                var command = new AddBookmarkCommand
                {
                    JobId = request.Id,
                    UserId = UserId

                };
                return await Mediator.Send(command) ;
            }
            catch (Exception ex)
            { 
                _logger.LogInformation(ex.ToString()); 
            } 
            return false; 
        }
        [HttpPost]
        [Route("RemoveBookmark")]
        public async Task<bool> RemoveBookmark(long id)
        {
            try
            {
                var command = new RemoveBookmarkCommand
                {
                    Id = id
                };
                return await Mediator.Send(command);
            }
            catch (Exception ex)
            { 
                _logger.LogInformation(ex.ToString()); 

            }
            return false;
        }
    }
}
