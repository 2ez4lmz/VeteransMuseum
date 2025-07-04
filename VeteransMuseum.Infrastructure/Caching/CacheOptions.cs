﻿using Microsoft.Extensions.Caching.Distributed;

namespace VeteransMuseum.Infrastructure.Caching;

public static class CacheOptions
{
    public static DistributedCacheEntryOptions DefaultExpiration => new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
    };

    public static DistributedCacheEntryOptions Create(TimeSpan? expiration) =>
        expiration != null ?
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration }
            : DefaultExpiration;
}