using System;
using System.Collections.Generic;
using System.Linq;

namespace Aluminum.Extensions
{
    public class EnumExtensions
    {
        public static List<Enum> GetEnumMembers(Type propertyEnumType)
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