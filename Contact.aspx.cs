using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LegacyWebForms
{
    /// <summary>
    /// Code-behind class for the Contact page.
    /// Displays contact information for the organization.
    /// </summary>
    public partial class Contact : Page
    {
        /// <summary>
        /// Handles the Page_Load event, which fires when the page is loaded.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Store the submitted values
            lblFromValue.Text = txtFrom.Text;
            lblEmailValue.Text = txtEmail.Text;
            lblMessageValue.Text = txtMessage.Text;
            
            // Hide the form
            pnlForm.Visible = false;
            
            // Show the submitted values panel
            pnlSubmittedValues.Visible = true;
        }
    }
}