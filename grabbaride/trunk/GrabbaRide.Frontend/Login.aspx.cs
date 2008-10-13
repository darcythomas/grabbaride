using System;
using System.Web;
using System.Web.UI;
using DotNetOpenId.RelyingParty;
using GrabbaRide.Database;
using GrabbaRide.UserManagement;
using System.Web.Security;

namespace GrabbaRide.Frontend
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // set the returnurl
                GrabbaRideLogin.DestinationPageUrl = Request.QueryString["RedirectUrl"];
                GrabbaRideLogin.CreateUserUrl += Request.Url.Query;
            }
        }

        /// <summary>
        /// Fired upon login.
        /// Note, that straight after login, forms auth will redirect the user to their original page. So this page may never be rendererd.
        /// </summary>
        protected void OpenIdLogin1_LoggedIn(object sender, OpenIdEventArgs e)
        {
            // look for an existing openid in our db
            OpenIDUserResponseState responseState = new OpenIDUserResponseState(e);
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            OpenID openID = context.GetOpenIDByUrl(responseState.OpenIDLoginName);

            if (openID == null)
            {
                // user needs to be registered
                Session.Add("MissingClaims", responseState);
                Response.Redirect("OpenIDError.aspx");
            }
            else
            {
                // log in the user
                FormsAuthentication.RedirectFromLoginPage(openID.User.Username, false);

                // redirect to next page
                Response.Redirect(GrabbaRideLogin.DestinationPageUrl);
            }
        }

        protected void OpenIdLogin1_Failed(object sender, OpenIdEventArgs e)
        {
            loginFailedLabel.Visible = true;
            loginFailedLabel.Text += ": " + e.Response.Exception.Message;
        }

        protected void OpenIdLogin1_Canceled(object sender, OpenIdEventArgs e)
        {
            loginCanceledLabel.Visible = true;
            loginCanceledLabel.Text = ": " + e.Response.Exception.Message;
        }

        protected void OpenIdLogin1_SetupRequired(object sender, OpenIdEventArgs e)
        {
            loginFailedLabel.Text = "Not a valid OpenID!";
            loginFailedLabel.Visible = true;
        }
    }
}
