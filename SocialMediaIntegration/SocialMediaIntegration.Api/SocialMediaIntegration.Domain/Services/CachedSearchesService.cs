using SocialMediaIntegration.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using SocialMediaIntegration.Domain.Entities;
using SocialMediaIntegration.Domain.Interfaces.Repositories;
using System.Configuration;

namespace SocialMediaIntegration.Domain.Services
{
    public class CachedSearchesService : ICachedSearchesService
    {
        private readonly ICachedSearchesRepository _cachedSearchesRespository;
        private int maxTagsResult = int.Parse(ConfigurationManager.AppSettings["max-tags-result@socialMediaIntegration"]);
        private int tagExpireIn = int.Parse(ConfigurationManager.AppSettings["tag-expireIn@socialMediaIntegration"]);

        public CachedSearchesService(ICachedSearchesRepository cachedSearchesRepository)
        {
            _cachedSearchesRespository = cachedSearchesRepository;
        }

        public IEnumerable<Search> Get()
        {
            return _cachedSearchesRespository.GetAll<Search>(maxTagsResult);
        }

        public void Set(Search search)
        {
            var key = search.Tag;
            var tagExpireInHours = TimeSpan.FromHours(tagExpireIn);

            var isKeyInCache = _cachedSearchesRespository.IsInCache(key);

            if (!isKeyInCache)
            {
                _cachedSearchesRespository.Set(key, search, tagExpireInHours);
            }
        }
    }
}
