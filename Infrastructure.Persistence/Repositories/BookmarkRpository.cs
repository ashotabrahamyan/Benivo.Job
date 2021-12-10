using BenivoJob.Domain.Entities;
using BenivoJob.Domain.Repositories;
using Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


namespace Infrastructure.Persistence.Repositories
{
    public class BookmarkRpository : IBookmarkRpository
    {
        private readonly JobDbContext _jobDbContext;

        public BookmarkRpository(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext ?? throw new ArgumentNullException(nameof(jobDbContext));

        }
        public async Task<bool> AddToBookmark(Bookmark bookmark)
        {
            try
            {
                var a = bookmark.MapToBookmark();
                _jobDbContext.Add(a);
                await _jobDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RemoveBookmark(long id)
        {
            var bookmark = await _jobDbContext.Bookmark.FirstOrDefaultAsync(x => x.Id == id);
            if (bookmark == null)
            {
                return false;
            } 
            _jobDbContext.Remove(bookmark);
            await _jobDbContext.SaveChangesAsync();
            return true;

        }
    }
}
