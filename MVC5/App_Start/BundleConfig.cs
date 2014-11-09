using System.Web;
using System.Web.Optimization;

namespace MVC5
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(
                new ScriptBundle("~/bundles/woodply_js").Include(
                //"~/Scripts/jquery_woodply.js"
                //,
                                                            "~/Scripts/slider.js"
#if DEBUG
                                                            , "~/Scripts/superfish.js"
#else
                                                            , "~/Scripts/superfish.min.js"
#endif
                                                            , "~/Scripts/custom.js")
                          );

            bundles.Add(
                new StyleBundle("~/Content/woodply_css").Include("~/Content/reset.css"
                                                            , "~/Content/styles-woodply.css"
                                                            )
                          );

            bundles.Add(
                new StyleBundle("~/Content/flame_css").Include("~/Content/styles-flame.css")
                          );

            var bundle1 = new StyleBundle("~/Content/font-awesome_css_cdn");
            bundle1.CdnPath = "http://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css";
            bundles.Add(bundle1);

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
