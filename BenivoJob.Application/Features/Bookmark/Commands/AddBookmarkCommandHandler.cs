using BenivoJob.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BenivoJob.Application.Features.Bookmark.Commands
{
    public class AddBookmarkCommandHandler : IRequestHandler<AddBookmarkCommand,bool>
    {
        private readonly IBookmarkRpository _bookmarkRpository;
        public AddBookmarkCommandHandler(IBookmarkRpository bookmarkRpository)
        {
            _bookmarkRpository = bookmarkRpository;
        }

        public async Task<bool> Handle(AddBookmarkCommand request, CancellationToken cancellationToken)
        {
             var bookmark = new Domain.Entities.Bookmark(
                request.JobId, request.UserId, DateTime.UtcNow, DateTime.UtcNow, false);
              
            return await _bookmarkRpository.AddToBookmark(bookmark);
        }
    }
}
