using System.Web;
using System.Web.Optimization;

namespace HCI
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

            bundles.Add(new StyleBundle("~/Content/fullcalendar_css")
                .Include("~/Content/fullcalendar.css"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar_js")
                .Include("~/Scripts/fullcalendar.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-datepicker")
                .Include("~/Content/datepicker3.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker")
                .Include("~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-clockpicker")
                .Include("~/Content/bootstrap-clockpicker.css")
                .Include("~/Content/clockpicker.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-clockpicker")
                .Include("~/Scripts/bootstrap-clockpicker.css")
                .Include("~/Scripts/clockpicker.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
