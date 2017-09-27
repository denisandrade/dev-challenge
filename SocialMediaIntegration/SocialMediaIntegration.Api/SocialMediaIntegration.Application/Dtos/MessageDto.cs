using SocialMediaIntegration.Domain.Entities;
using System;

namespace SocialMediaIntegration.Application.Dtos
{
    public class MessageDto
    {
        public string SocialMedia { get; private set; }
        public string Author { get; private set; }
        public string Text { get; private set; }
        public DateTime Date { get; private set; }

        public MessageDto(Message message)
        {
            SocialMedia = message.SocialMedia.ToString();
            Author = message.Author;
            Text = message.Text;
            Date = message.Date;
        }
    }
}
