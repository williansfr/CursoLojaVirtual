using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Willians.LojaVirtual.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-1.*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstraps").Include(
                "~/Scripts/jquery - 1.10.2.min.js",
                "~/Scripts/bootstrap.min.js*",
                "~/Scripts/modernizr - 2.6.2.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css",
                 "~/Content/bootstrap.min.css",
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/ErroEstilo.css"));

            BundleTable.EnableOptimizations = true;
        }            
    }
}