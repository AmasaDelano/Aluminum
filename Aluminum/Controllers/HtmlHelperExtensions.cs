using System.Reflection;
using System.Web.Mvc;

namespace Aluminum
{
    public static class HtmlHelperExtensions
    {
        private static readonly string _version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static string Version(this HtmlHelper htmlHelper)
        {
            return _version;
        }
    }
}