using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace GrabbaRide.Frontend
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    // redirect to "my profile" page
                    Response.Redirect("User.aspx?id=" + User.Identity.Name);
                }
                else
                {
                    // display the profile of whoever it is
                }
            }
            else
            {
                // must be logged in to view this page
                Response.Redirect("Login.aspx?RedirectUrl=User.aspx");
            }
        }
    }
}
