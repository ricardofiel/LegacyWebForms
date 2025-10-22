using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace LegacyWebForms
{
    /// <summary>
    /// Configuration class for script and style bundles.
    /// Handles bundling and minification of JavaScript and CSS resources to improve performance.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registers all script and style bundles for the application.
        /// This includes WebForms scripts, Microsoft Ajax scripts, and Modernizr.
        /// For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        /// </summary>
        /// <param name="bundles">The BundleCollection to which bundles will be added.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterJQueryScriptManager();

            // Register WebForms client-side scripts bundle
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));
        }

        /// <summary>
        /// Registers jQuery with the ScriptManager for use in WebForms pages.
        /// Configures both the regular and minified versions, as well as CDN paths
        /// for jQuery 3.7.0.
        /// </summary>
        public static void RegisterJQueryScriptManager()
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-3.7.0.min.js",
                    DebugPath = "~/scripts/jquery-3.7.0.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.min.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.js"
                });
        }
    }
}
