using SocialMediaIntegration.Application.Dtos;
using System.Collections.Generic;

namespace SocialMediaIntegration.Application.Interface
{
    public interface ISocialMediaAppService 
    {
        IEnumerable<MessageDto> GetTwitter(string tag);
        IEnumerable<SearchDto> GetCachedSearches();
    }
}
