using System.Web.Optimization;

namespace Aluminum.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS bundles

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                    "~/Content/Styles/bootstrap/bootstrap.css",
                    "~/Content/Styles/bootstrap/bootstrap-theme.css"
                ));

            // Javascript bundles

            bundles.Add(new ScriptBundle("~/js/jquery").Include(
                    "~/Scripts/jquery/jquery-2.1.3.js",
                    "~/Scripts/jquery/jquery.validate.js",
                    "~/Scripts/validate.js",
                    "~/Scripts/jquery/jquery.cookie.js"
                ));

            bundles.Add(new ScriptBundle("~/js/bootstrap").Include(
                    "~/Scripts/jquery/jquery-2.1.3.js",
                    "~/Scripts/bootstrap/bootstrap.js"
                ));

            bundles.Add(new ScriptBundle("~/js/angular").Include(
                    "~/Scripts/angular/angular.js",
                    "~/Scripts/angular/angular-route.js"
                ));
        }
    }
}