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
    public class SocialMediaServiceTest
    {
        Mock<ISocialMediaService> _mock;
        List<Message> _message;
        private const string _tag = "Ola";

        [TestInitialize]
        public void Initialize()
        {
            _message = new List<Message> { };
            _mock = new Mock<ISocialMediaService>();

            _mock.Setup(x => x.GetTwitter(_tag)).Returns(_message);
        }

        [TestMethod]
        public void ShouldGetTwitter()
        {
            var socialMediaService = _mock.Object;
            var result = socialMediaService.GetTwitter(_tag);

            result.Should().NotBeNull();
            result.Count().Should().Be(0);

            _mock.Verify(x => x.GetTwitter(_tag));
        }
    }
}
