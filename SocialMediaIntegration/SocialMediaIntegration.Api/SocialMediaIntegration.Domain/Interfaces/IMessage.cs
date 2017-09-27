using SocialMediaIntegration.Domain.Entities;
using System.Collections.Generic;

namespace SocialMediaIntegration.Domain.Interfaces
{
    public interface IMessage
    {
        IEnumerable<Message> GetMessage(string tag, int maxResult);
    }
}
