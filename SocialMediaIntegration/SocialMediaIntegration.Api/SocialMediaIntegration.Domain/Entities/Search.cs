using SocialMediaIntegration.Domain.Entities.Enums;
using System;

namespace SocialMediaIntegration.Domain.Entities
{
    public class Search
    {
        public string Tag { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public DateTime Date { get; set; }

        public Search (string tag, SocialMedia socialMedia)
        {
            Tag = tag;
            SocialMedia = SocialMedia;
            Date = DateTime.Now;
        }
    }
}
