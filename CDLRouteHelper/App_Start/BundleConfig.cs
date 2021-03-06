﻿using System.Web;
using System.Web.Optimization;

namespace CDLRouteHelper
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-ui-1.8.24.js"));

            bundles.Add(new ScriptBundle("~/js").Include(
                "~/Scripts/bootstrap.js"
                //"~/Content/unify/js/modernizr.custom.js",
                //"~/Content/unify/plugins/flexslider/jquery.flexslider-min.js",
                //"~/Content/unify/plugins/parallax-slider/js/modernizr.js",
                //"~/Content/unify/plugins/parallax-slider/js/jquery.cslider.js",
                //"~/Content/unify/plugins/back-to-top.js",
                //"~/Content/unify/js/app.js",
                //"~/Content/unify/js/pages/index.js"
                ));

            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-responsive.css"
                //"~/Content/unify/css/headers/header2.css",
                //"~/Content/unify/css/themes/headers/header2-red.css",
                //"~/Content/unify/css/style_responsive.css",
                //"~/Content/unity/plugins/flexslider/flexslider.css"
                //** May be needed for other home page templates **//
                //"~/Content/unity/plugins/bxslider/jquery.bxslider.css",
                //"~/Content/unity/plugins/horizontal-parallax/css/horizontal-parallax.css"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}