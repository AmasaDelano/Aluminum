using System;
using System.Collections.Generic;
using System.Linq;
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
            var enumType = propertyEnumType;

            if (Nullable.GetUnderlyingType(enumType) != null && Nullable.GetUnderlyingType(enumType).IsEnum)
            {
                enumType = Nullable.GetUnderlyingType(enumType);
            }

            if (!enumType.IsEnum)
            {
                throw new ArgumentException(
                    string.Format("propertyEnumType must be a type of Enum, not a {0}.", enumType.FullName),
                    "propertyEnumType");
            }

            var enumMembers = Enum.GetValues(enumType)
                .Cast<Enum>()
                .ToList();

            return enumMembers;
        }
    }
}