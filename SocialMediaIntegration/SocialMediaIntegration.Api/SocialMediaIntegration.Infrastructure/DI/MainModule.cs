using Autofac;
using SocialMediaIntegration.Application;
using SocialMediaIntegration.Application.Interface;
using SocialMediaIntegration.Domain.Client;
using SocialMediaIntegration.Domain.Interfaces.Client;
using SocialMediaIntegration.Domain.Interfaces.Repositories;
using SocialMediaIntegration.Domain.Interfaces.Services;
using SocialMediaIntegration.Domain.Services;
using SocialMediaIntegration.Repository;

namespace SocialMediaIntegration.Infrastructure.DI
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SocialMediaService>()
                .As<ISocialMediaService>();

            builder
               .RegisterType<CachedSearchesService>()
               .As<ICachedSearchesService>();

            builder
               .RegisterType<SocialMediaAppService>()
               .As<ISocialMediaAppService>();

            builder
               .RegisterType<TwitterClient>()
               .As<ITwitterClient>();

            builder
               .RegisterType<CachedSearchesRepository>()
               .As<ICachedSearchesRepository>();
        }
    }
}
