using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Aluminum.Web.Extensions;

namespace Aluminum.Web.ViewModels
{
    public class EnumList
    {
        private Type _enumType;
        private List<IConvertible> _options;
        private string _propertyName;

        public void Init<TEnum>(
            CostumeViewModel costume,
            Expression<Func<CostumeViewModel, List<TEnum>>> enumListExpression)
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            _enumType = typeof(TEnum);
            _options = enumListExpression.Compile().Invoke(costume).Cast<IConvertible>().ToList();
            _propertyName = ((MemberExpression) enumListExpression.Body).Member.Name;
        }

        public List<Enum> GetEnumMembers()
        {
            return EnumExtensions.GetEnumMembers(_enumType);
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public List<IConvertible> Options
        {
            get { return _options; }
        }
    }
}