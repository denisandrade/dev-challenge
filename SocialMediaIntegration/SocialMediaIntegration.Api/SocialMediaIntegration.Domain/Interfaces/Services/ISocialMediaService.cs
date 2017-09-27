using SocialMediaIntegration.Domain.Entities;
using System.Collections.Generic;

namespace SocialMediaIntegration.Domain.Interfaces.Services
{
    public interface ISocialMediaService
    {
        IEnumerable<Message> GetTwitter(string tag);
        IEnumerable<Message> GetInstagram(string tag);
        IEnumerable<Message> GetGooglePlus(string tag);
        IEnumerable<Message> GetFacebook(string tag);
    }
}
