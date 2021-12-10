using BenivoJob.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BenivoJob.Application.Features.Bookmark.Commands
{
    public class RemoveBookmarkCommandHandler : IRequestHandler<RemoveBookmarkCommand, bool>
    {
        private readonly IBookmarkRpository _bookmarkRpository;
        public RemoveBookmarkCommandHandler(IBookmarkRpository bookmarkRpository)
        {
            _bookmarkRpository = bookmarkRpository;
        }
        public async Task<bool> Handle(RemoveBookmarkCommand request, CancellationToken cancellationToken)
        {
            return await _bookmarkRpository.RemoveBookmark(request.Id);
              
        }
    }
}
