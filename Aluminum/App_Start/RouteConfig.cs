﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Aluminum
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CostumeSelector",
                url: "CostumeSelector",
                defaults: new { controller = "Costume", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}",
                defaults: new { controller = "ColorClock", action = "Index" }
            );
        }
    }
}