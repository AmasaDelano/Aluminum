using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aluminum.Extensions
{
    public static class HtmlHelperExtensions
    {
        private static readonly string _version = DateTime.Now.ToString();
        //Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static string Version(this HtmlHelper htmlHelper)
        {
            return _version;
        }

        public static List<Enum> GetEnumMembers(this HtmlHelper htmlHelper, Type propertyEnumType)
        {
            return EnumExtensions.GetEnumMembers(propertyEnumType);
        }

        public static string GetCostumesImagesPath(this HtmlHelper htmlHelper)
        {
            return ConfigurationExtensions.GetCostumeImagesPath();
        }
    }
}