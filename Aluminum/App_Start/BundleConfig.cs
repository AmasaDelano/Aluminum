using System.Web.Optimization;

namespace Manor
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS bundles

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                    "~/Content/Styles/bootstrap/bootstrap.min.css",
                    "~/Content/Styles/bootstrap/bootstrap-theme.min.css"
                ));

            // Javascript bundles

            bundles.Add(new ScriptBundle("~/js/bootstrap").Include(
                    "~/Scripts/bootstrap/bootstrap.min.js",
                    "~/Scripts/jquery/jquery-2.1.3.min.js"
                ));

            bundles.Add(new ScriptBundle("~/js/angular").Include(
                    "~/Scripts/angular/angular.min.js",
                    "~/Scripts/angular/angular-route.min.js"
                ));
        }
    }
}