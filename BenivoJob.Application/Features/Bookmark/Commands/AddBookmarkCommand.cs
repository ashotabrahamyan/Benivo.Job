using MediatR;
using System;

namespace BenivoJob.Application.Features.Bookmark.Commands
{
    public class AddBookmarkCommand :  IRequest<bool>
    {
        public long JobId { get; set; }
        public long UserId { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
