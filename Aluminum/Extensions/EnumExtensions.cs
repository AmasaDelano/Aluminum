using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Aluminum.Web.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumMember)
        {
            if (enumMember == null)
            {
                return string.Empty;
            }

            Type enumType = enumMember.GetType();
            var display = enumMember.GetType()
                .GetMember(enumMember.ToString())
                .First()
                .GetCustomAttributes(false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();

            if (display == null)
            {
                return enumMember.ToString();
            }

            return display.Name;
        }

        public static List<Enum> GetEnumMembers(this Type enumType)
        {
            var propertyEnumType = enumType;

            if (Nullable.GetUnderlyingType(propertyEnumType) != null && Nullable.GetUnderlyingType(propertyEnumType).IsEnum)
            {
                propertyEnumType = Nullable.GetUnderlyingType(propertyEnumType);
            }

            if (!propertyEnumType.IsEnum)
            {
                throw new ArgumentException(
                    string.Format("enumType must be a type of Enum, not a {0}.", propertyEnumType.Name),
                    "enumType");
            }

            var enumMembers = Enum.GetValues(propertyEnumType)
                .Cast<Enum>()
                .ToList();

            return enumMembers;
        }
    }
}