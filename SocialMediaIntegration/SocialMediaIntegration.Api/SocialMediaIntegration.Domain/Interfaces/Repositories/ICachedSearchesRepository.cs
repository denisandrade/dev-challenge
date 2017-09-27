using System;
using System.Collections.Generic;

namespace SocialMediaIntegration.Domain.Interfaces.Repositories
{
    public interface ICachedSearchesRepository
    {
        void Set<T>(string key, T value, TimeSpan timeout);
        IEnumerable<T> GetAll<T>(int maxResult);
        bool IsInCache(string key);
    }
}
