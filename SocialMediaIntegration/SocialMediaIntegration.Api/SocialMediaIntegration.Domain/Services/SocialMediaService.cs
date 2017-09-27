using SocialMediaIntegration.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using SocialMediaIntegration.Domain.Entities;
using SocialMediaIntegration.Domain.Interfaces.Client;
using SocialMediaIntegration.Domain.Entities.Enums;
using System.Threading.Tasks;
using System.Configuration;

namespace SocialMediaIntegration.Domain.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ITwitterClient _twitterClient;
        private readonly ICachedSearchesService _cachedSearchesService;
        private int maxMessagesResult = int.Parse(ConfigurationManager.AppSettings["max-messages-result@socialMediaIntegration"]);

        public SocialMediaService(ITwitterClient twitterClient, ICachedSearchesService cachedSearchesService)
        {
            _twitterClient = twitterClient;
            _cachedSearchesService = cachedSearchesService;
        }
        
        public IEnumerable<Message> GetTwitter(string tag)
        {
            SetSearchInCache(tag, SocialMedia.Twitter);

            var twitterMessages = _twitterClient.GetMessage(tag, maxMessagesResult);

            return twitterMessages;
        }

        private void SetSearchInCache(string tag, SocialMedia socialMedia)
        {
            Task.Run(() => _cachedSearchesService.Set(new Search(tag, socialMedia)));
        }

        #region SocialMediaNotImplemented

        public IEnumerable<Message> GetInstagram(string tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetGooglePlus(string tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetFacebook(string tag)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
