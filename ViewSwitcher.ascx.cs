using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls.Resolvers;

namespace LegacyWebForms
{
    /// <summary>
    /// User control that provides a view switcher between Mobile and Desktop views.
    /// Allows users to toggle between different rendering modes based on device type.
    /// </summary>
    public partial class ViewSwitcher : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets the current view mode (Mobile or Desktop).
        /// </summary>
        protected string CurrentView { get; private set; }

        /// <summary>
        /// Gets the alternate view mode that the user can switch to.
        /// </summary>
        protected string AlternateView { get; private set; }

        /// <summary>
        /// Gets the URL for switching to the alternate view.
        /// </summary>
        protected string SwitchUrl { get; private set; }

        /// <summary>
        /// Handles the Page_Load event. Determines the current view mode,
        /// calculates the alternate view, and generates the switch URL.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Determine current view
            var isMobile = WebFormsFriendlyUrlResolver.IsMobileView(new HttpContextWrapper(Context));
            CurrentView = isMobile ? "Mobile" : "Desktop";

            // Determine alternate view
            AlternateView = isMobile ? "Desktop" : "Mobile";

            // Create switch URL from the route, e.g. ~/__FriendlyUrls_SwitchView/Mobile?ReturnUrl=/Page
            var switchViewRouteName = "AspNet.FriendlyUrls.SwitchView";
            var switchViewRoute = RouteTable.Routes[switchViewRouteName];
            if (switchViewRoute == null)
            {
                // Friendly URLs is not enabled or the name of the switch view route is out of sync
                this.Visible = false;
                return;
            }
            var url = GetRouteUrl(switchViewRouteName, new { view = AlternateView, __FriendlyUrls_SwitchViews = true });
            url += "?ReturnUrl=" + HttpUtility.UrlEncode(Request.RawUrl);
            SwitchUrl = url;
        }
    }
}