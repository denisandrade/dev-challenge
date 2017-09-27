using SocialMediaIntegration.Domain.Entities;
using System.Collections.Generic;

namespace SocialMediaIntegration.Domain.Interfaces.Services
{
    public interface ICachedSearchesService
    {
        IEnumerable<Search> Get();
        void Set(Search search);
    }
}
