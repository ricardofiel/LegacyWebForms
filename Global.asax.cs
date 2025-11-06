using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace LegacyWebForms
{
    /// <summary>
    /// Global application class that handles application-level events and configuration.
    /// Inherits from HttpApplication to provide application lifecycle management.
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Handles the Application_Start event, which fires when the application starts.
        /// This method is called once during the application's lifetime to configure
        /// routing and bundling.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}