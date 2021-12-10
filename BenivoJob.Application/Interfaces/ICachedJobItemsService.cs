using BenivoJob.Domain.Entities;
using System.Collections.Generic;

namespace BenivoJob.Application.Interfaces
{
    public interface ICachedJobItemsService
    {
        IEnumerable<Job> GetCachedJobItems(string key);
        void DeleteCachedJobItems(string key);
        void SetCachedJobItems(string key ,object entry);
    }
}
