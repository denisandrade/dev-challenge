using SocialMediaIntegration.Application.Interface;
using System;
using System.Collections.Generic;
using SocialMediaIntegration.Domain.Interfaces.Services;
using SocialMediaIntegration.Application.Dtos;
using System.Linq;

namespace SocialMediaIntegration.Application
{
    public class SocialMediaAppService : ISocialMediaAppService
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly ICachedSearchesService _cachedSearchesService;

        public SocialMediaAppService(ISocialMediaService socialMediaService, ICachedSearchesService cachedSearchesService)
        {
            _socialMediaService = socialMediaService;
            _cachedSearchesService = cachedSearchesService;
        }

        public IEnumerable<MessageDto> GetTwitter(string tag)
        {
            var result = _socialMediaService.GetTwitter(tag);

            return result.Select(message =>
            {
                return new MessageDto(message);

            }).OrderByDescending(tweet => tweet.Date);
        }

        public IEnumerable<SearchDto> GetCachedSearches()
        {
            var result = _cachedSearchesService.Get();

            return result.Select(search =>
            {
                return new SearchDto(search);

            }).OrderByDescending(search => search.Date);
        }
    }
}
