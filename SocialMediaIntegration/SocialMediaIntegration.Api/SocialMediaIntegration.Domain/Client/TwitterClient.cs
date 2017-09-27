using Twitter = SocialMediaIntegration.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Parameters;
using Tweetinvi.Models;
using SocialMediaIntegration.Domain.Interfaces.Client;
using System.Configuration;

namespace SocialMediaIntegration.Domain.Client
{
    public class TwitterClient : ITwitterClient
    {
        private string consumerKey = ConfigurationManager.AppSettings["consumerKey-twitter@socialMediaIntegration"];
        private string consumerSecret = ConfigurationManager.AppSettings["consumerSecret-twitter@socialMediaIntegration"];
        private string consumuserAccessTokenerKey = ConfigurationManager.AppSettings["userAccessToken-twitter@socialMediaIntegration"];
        private string userAccessSecret = ConfigurationManager.AppSettings["userAccessSecret-twitter@socialMediaIntegration"];
        
        public TwitterClient()
        {
            Auth.SetUserCredentials(consumerKey, consumerSecret, consumuserAccessTokenerKey, userAccessSecret);
        }

        public IEnumerable<Twitter.Message> GetMessage(string tag, int maxMessagesResult)
        {
            var user = User.GetAuthenticatedUser();

            var searchParameter = new SearchTweetsParameters(tag)
            {
                SearchType = SearchResultType.Mixed,
                MaximumNumberOfResults = maxMessagesResult,
                Filters = TweetSearchFilters.Hashtags,
                TweetSearchType = TweetSearchType.All
            };

            var searchResult = Search.SearchTweets(searchParameter);

            return searchResult.Select(tweet =>
            {
                return new Twitter.Message(tweet);

            }).OrderByDescending(tweet => tweet.Date); 
        }
    }
}
