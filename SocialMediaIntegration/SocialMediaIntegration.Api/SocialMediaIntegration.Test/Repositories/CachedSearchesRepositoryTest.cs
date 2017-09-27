using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialMediaIntegration.Domain.Entities;
using SocialMediaIntegration.Domain.Entities.Enums;
using SocialMediaIntegration.Domain.Interfaces.Repositories;
using SocialMediaIntegration.Repository;
using FluentAssertions;
using System;
using System.Linq;

namespace SocialMediaIntegration.Test.Repositories
{
    [TestClass]
    public class CachedSearchesRepositoryTest
    {
        ICachedSearchesRepository _cachedSearchesRespository;
        const string _tag = "tagTest1";

        [TestInitialize]
        public void Initialize()
        {
            _cachedSearchesRespository = new CachedSearchesRepository();
        }

        [TestMethod]
        public void Should_Set_Tag_InCache()
        {
            var search = new Search(_tag, SocialMedia.Twitter);
            _cachedSearchesRespository.Set(_tag, search, TimeSpan.FromMinutes(20));
        }

        [TestMethod]
        public void Should_Get_Searches_FromCache()
        {
            var cachedSearches = _cachedSearchesRespository.GetAll<Search>(10);

            cachedSearches.Count().Should().BeGreaterThan(0, "cached searches should be greater than 0");
            cachedSearches.Where(search => search.Tag == _tag).Any().Should().BeTrue("cached searches should contain any key equal " + _tag);
        }
    }
}
