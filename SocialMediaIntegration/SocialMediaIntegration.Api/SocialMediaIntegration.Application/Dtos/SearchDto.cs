using SocialMediaIntegration.Domain.Entities;
using System;

namespace SocialMediaIntegration.Application.Dtos
{
    public class SearchDto
    {
        public string Tag { get; set; }
        public string SocialMedia { get; set; }
        public DateTime Date { get; set; }

        public SearchDto(Search search)
        {
            Tag = search.Tag;
            SocialMedia = search.SocialMedia.ToString();
            Date = search.Date;
        }
    }
}
