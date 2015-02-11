﻿using System.Data.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Aluminum.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace Aluminum
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();

            container.RegisterPerWebRequest<DataContext>(() => new RoomOfRequirementDataContext());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}