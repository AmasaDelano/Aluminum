using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using Aluminum.Data;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace Aluminum.Web
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();

            container.RegisterPerWebRequest<DbContext>(() => new RoomOfRequirement());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}