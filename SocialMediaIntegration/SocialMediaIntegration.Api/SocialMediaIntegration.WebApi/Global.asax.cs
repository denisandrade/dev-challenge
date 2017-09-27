using Autofac;
using System.Web.Http;
using Autofac.Integration.WebApi;
using System.Reflection;
using System;
using SocialMediaIntegration.Infrastructure.DI;
using SocialMediaIntegration.WebApi.Controllers;

namespace SocialMediaIntegration.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            try
            {
                GlobalConfiguration.Configure(WebApiConfig.Register);

                var config = GlobalConfiguration.Configuration;

                var builder = new ContainerBuilder();
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
                builder.RegisterType<SocialMediaController>().AsSelf();
                builder.RegisterModule(new MainModule());
                var container = builder.Build();
                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inicializar o serviço", ex);
            }
        }
    }
}
