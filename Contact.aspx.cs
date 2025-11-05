using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LegacyWebForms
{
    public partial class Contact : Page
    {
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