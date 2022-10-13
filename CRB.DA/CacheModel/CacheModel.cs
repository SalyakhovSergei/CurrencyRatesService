using System;
using System.Collections.Generic;
using System.Text;
using CRB.DA.AdjustedOptions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CRB.DA.CacheModel
{
    public class CacheModel: ICacheModel
    {
        private IMemoryCache _memoryCache;
        private CacheConfiguration _cacheConfiguration;

        public CacheModel(IMemoryCache memoryCache,
                            IOptions<CacheConfiguration> cacheConfigs)
        {
            _memoryCache = memoryCache;
            _cacheConfiguration = cacheConfigs.Value;
        }

        public void Add<T>(string key, T item)
        {
            _memoryCache.Set(key, item, 
                new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(_cacheConfiguration.CacheSlidingTime))
                .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheConfiguration.CacheExpirationTime)));
        }

        public bool Get<T>(string key, out T item)
        {
            return _memoryCache.TryGetValue(key, out item);
        }
        
    }
}
