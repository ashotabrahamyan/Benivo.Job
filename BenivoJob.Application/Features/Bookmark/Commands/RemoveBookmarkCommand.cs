using MediatR;

namespace BenivoJob.Application.Features.Bookmark.Commands
{
    public class RemoveBookmarkCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

}
