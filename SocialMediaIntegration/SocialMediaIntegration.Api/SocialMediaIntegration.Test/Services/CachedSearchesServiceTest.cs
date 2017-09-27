using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialMediaIntegration.Domain.Entities;
using SocialMediaIntegration.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace SocialMediaIntegration.Test.Services
{
    [TestClass]
    public class CachedSearchesServiceTest
    {
        Mock<ICachedSearchesService> _mock;
        Search _search;

        [TestInitialize]
        public void Initialize()
        { 
            _search = new Search() { };
            _mock = new Mock<ICachedSearchesService>();

            _mock.Setup(x => x.Set(_search));
            _mock.Setup(x => x.Get()).Returns(new List<Search> { });
        }

        [TestMethod]
        public void ShouldSetInCache()
        {
            var setCacheService = _mock.Object;
            setCacheService.Set(_search);

            _mock.Verify(x => x.Set(_search));
        }

        [TestMethod]
        public void ShouldGetInCache()
        {
            var getCacheService = _mock.Object;
            var result = getCacheService.Get();

            result.Should().NotBeNull();
            result.Count().Should().Be(0);

            _mock.Verify(x => x.Get());
        }
    }
}
