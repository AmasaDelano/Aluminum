using System;
using System.Collections.Generic;
using System.Linq;

namespace Aluminum.Web.Extensions
{
    public class EnumExtensions
    {
        public static List<Enum> GetEnumMembers(Type enumType)
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