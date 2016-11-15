namespace VSTSInfoscreen
{
    using System.Web.Optimization;

    /// <summary>
    /// Defines all bundles used in this application.
    /// </summary>
    public static class BundleConfig
    {
        /// <summary>
        /// Registers the bundles.
        /// </summary>
        /// <param name="bundles">The bundle collection.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/data").Include(
                        "~/Scripts/materialize.css", "~/Scripts/dataService.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize.css", "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/vstsInfoScreen").Include(
                        "~/Scripts/vstsInfoScreen.js"));
        }
    }
}
