using SocialMediaIntegration.Domain.Entities.Enums;
using System;
using Tweetinvi.Models;

namespace SocialMediaIntegration.Domain.Entities
{
    public class Message
    {
        public SocialMedia SocialMedia { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Message(ITweet tweet)
        {
            SocialMedia = SocialMedia.Twitter;
            Author = tweet.CreatedBy.Name;
            Text = tweet.FullText;
            Date = tweet.CreatedAt;
        }

    }
}
