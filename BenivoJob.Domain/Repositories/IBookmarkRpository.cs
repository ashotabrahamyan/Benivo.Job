using BenivoJob.Domain.Entities;
using System.Threading.Tasks;

namespace BenivoJob.Domain.Repositories
{
    public interface IBookmarkRpository
    {
        Task<bool> AddToBookmark(Bookmark bookmark);
        Task<bool> RemoveBookmark(long id);

    }
}
