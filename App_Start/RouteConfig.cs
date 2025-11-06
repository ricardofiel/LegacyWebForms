using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace LegacyWebForms
{
    /// <summary>
    /// Configuration class for URL routing.
    /// Enables Friendly URLs for cleaner, more SEO-friendly URLs without file extensions.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Registers URL routes for the application.
        /// Configures Friendly URLs with permanent redirect mode to automatically
        /// redirect requests with .aspx extensions to their friendly URL equivalents.
        /// </summary>
        /// <param name="routes">The RouteCollection to which routes will be added.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
