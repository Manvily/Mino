using System.Web.Optimization;

namespace Mino
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/Scripts/app/services/tasksService.js",
                    "~/Scripts/app/services/projectsService.js",
                    "~/Scripts/app/services/tagsService.js",
                    "~/Scripts/app/services/notificationsService.js",
                    "~/Scripts/app/controllers/tasksController.js",
                    "~/Scripts/app/controllers/projectsController.js",
                    "~/Scripts/app/controllers/tagsController.js",
                    "~/Scripts/app/controllers/notificationsController.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/underscore-min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/respond.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.min.css",
                      "~/Content/animate.css"));
        }
    }
}
