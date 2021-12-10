using BenivoJob.Application.Interfaces;
using BenivoJob.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence
{
    public class InMemoryCachedJobItemsService : ICachedJobItemsService
    {
        private readonly IMemoryCache _cache;
        public InMemoryCachedJobItemsService(IMemoryCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        public void DeleteCachedJobItems(string key)
        {
            _cache.Remove(key);
        }

        public IEnumerable<Job> GetCachedJobItems(string key)
        {
            IEnumerable<Job> jotItems;

            _cache.TryGetValue<IEnumerable<Job>>(key, out jotItems);

            return jotItems;
        }

        public void SetCachedJobItems(string key,object entry)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions() 
                .SetSlidingExpiration(TimeSpan.FromDays(1));

            _cache.Set(key, entry, cacheEntryOptions);
        }
    }
}
