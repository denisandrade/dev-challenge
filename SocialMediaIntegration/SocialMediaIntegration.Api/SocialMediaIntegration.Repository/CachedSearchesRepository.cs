using SocialMediaIntegration.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.Redis;
using System.Configuration;

namespace SocialMediaIntegration.Repository
{
    public class CachedSearchesRepository : ICachedSearchesRepository
    {
        private RedisEndpoint _redisEndPoint;
        private string redisHost = ConfigurationManager.AppSettings["redis-host@socialMediaIntegration"].ToString();
        private int redisPort = int.Parse(ConfigurationManager.AppSettings["redis-port@socialMediaIntegration"]);
        private int redisDatabaseId = int.Parse(ConfigurationManager.AppSettings["redis-databaseId@socialMediaIntegration"]);
        
        public CachedSearchesRepository()
        {
            _redisEndPoint = new RedisEndpoint(redisHost, redisPort, null, redisDatabaseId);
        }

        public IEnumerable<T> GetAll<T>(int maxResult)
        {
            var result = default(IEnumerable<T>);

            using (var redisClient = new RedisClient(_redisEndPoint))
            {
                var allKeys = redisClient.GetAllKeys();
                result = redisClient.As<T>().GetValues(allKeys).Take(maxResult);
            }

            return result;
        }
        
        public bool IsInCache(string key)
        {
            bool isInCache = false;

            using (var redisClient = new RedisClient(_redisEndPoint))
            {
                isInCache = redisClient.ContainsKey(key);
            }

            return isInCache;
        }

        public void Set<T>(string key, T value, TimeSpan timeout)
        {
            using (var redisClient = new RedisClient(_redisEndPoint))
            {
                redisClient.As<T>().SetValue(key, value, timeout);
            };
        }
    }
}
