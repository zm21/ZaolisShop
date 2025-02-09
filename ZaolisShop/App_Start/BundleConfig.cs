﻿using System.Web;
using System.Web.Optimization;

namespace ZaolisShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jQuery").Include(
                   "~/Scripts/jquery-3.4.1.js"));


            bundles.Add(new ScriptBundle("~/bundles/ZaolisShop/js").Include(
                     "~/Scripts/ZaolisShop/NavMenu.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/ZaolisShop/layoutCSS").Include(
                     "~/Content/ZaolisShop/NavMenu.css",
                     "~/Content/ZaolisShop/ZaolisFooter.css",

                     "~/Content/ZaolisShop/ZaolisInput.css",

                     "~/url/https://use.fontawesome.com/releases/v5.0.13/css/all.css"));

            bundles.Add(new StyleBundle("~/Content/ZaolisShop/SignInUp").Include(
                    "~/Content/ZaolisShop/SignInUp.css"));


        }
    }
}
