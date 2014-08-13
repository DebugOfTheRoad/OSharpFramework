using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using ODeer.Plugin.Mvc;



namespace ODeer.Plugin.Admin.Helper
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle(BundleUrlHelper.Content(BundleActivator.Bundle, "~/Content/themes/gray/css")).Include(
                BundleUrlHelper.Content(BundleActivator.Bundle, "~/Content/themes/gray/easyui.css")
                ));

            bundles.Add(new StyleBundle(BundleUrlHelper.Content(BundleActivator.Bundle, "~/Content/themes/css")).Include(
                BundleUrlHelper.Content(BundleActivator.Bundle, "~/Content/themes/icon.css")
                ));

            bundles.Add(new StyleBundle(BundleUrlHelper.Content(BundleActivator.Bundle, "~/Content/css")).Include(
                BundleUrlHelper.Content(BundleActivator.Bundle, "~/Content/osharp-admin.css")
                ));

            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
                BundleUrlHelper.Content(BundleActivator.Bundle, "~/Scripts/jquery.easyui-{version}.js"),
                BundleUrlHelper.Content(BundleActivator.Bundle, "~/Scripts/locale/easyui-lang-zh_CN.js")
                //BundleUrlHelper.Content(BundleActivator.Bundle, "~/Scripts/easyloader.js")
                ));

            bundles.Add(new ScriptBundle("~/bundles/osharp-admin").Include(
                BundleUrlHelper.Content(BundleActivator.Bundle, "~/Scripts/osharp.data.js"),
                BundleUrlHelper.Content(BundleActivator.Bundle, "~/Scripts/osharp.easyui.js")
                ));
        }
    }
}