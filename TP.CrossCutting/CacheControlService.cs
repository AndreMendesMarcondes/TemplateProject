using Microsoft.Extensions.Caching.Memory;
using TP.Domain.Interfaces.Services;

namespace TP.CrossCutting
{
    public class CacheControlService : ICacheControlService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheControlService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SettingTimeAndCache(object cacheObject, string cacheKey, int timeToLive = 10)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                               .SetAbsoluteExpiration(TimeSpan.FromMinutes(timeToLive));

            _memoryCache.Set(cacheKey, cacheObject, cacheEntryOptions);
        }
    }
}