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
using DotNetOpenId.RelyingParty;
using DotNetOpenId.Extensions.SimpleRegistration;
using System.Text;

namespace GrabbaRide.Frontend
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {


                //determine who done the post back

                // OpenIdLogin1.LoggingIn()
                string redirectUrl = Request.QueryString["RedirectUrl"];

                if (String.IsNullOrEmpty(redirectUrl))
                {
                    redirectUrl = "Default.aspx";
                }

                if (Request.IsAuthenticated)
                {
                    Response.Redirect(redirectUrl);
                }
                else
                {
                    GrabbaRideLogin.DestinationPageUrl = redirectUrl;
                    GrabbaRideLogin.CreateUserUrl += "?RedirectUrl=" + redirectUrl;
                }
            }
        }


        /// <summary>
        /// Fired upon login.
        /// Note, that straight after login, forms auth will redirect the user to their original page. So this page may never be rendererd.
        /// </summary>
        protected void OpenIdLogin1_LoggedIn(object sender, OpenIdEventArgs e)
        {

        }
        protected void OpenIdLogin1_Failed(object sender, OpenIdEventArgs e)
        {
            loginFailedLabel.Visible = true;
            loginFailedLabel.Text += ": " + e.Response.Exception.Message;
            ShowOpenIDSettingsScript();


        }
        protected void OpenIdLogin1_Canceled(object sender, OpenIdEventArgs e)
        {
            loginCanceledLabel.Visible = true;
            loginCanceledLabel.Text = ": " + e.Response.Exception.Message;
        }
        protected void OpenIdLogin1_SetupRequired(object sender, OpenIdEventArgs e)
        {
            loginFailedLabel.Text = "It seems you need to set up an openID account";
            loginFailedLabel.Visible = true;

        }



        private void ShowNormalSettingsScript()
        {
         StringBuilder script =new System.Text.StringBuilder();

        script.Append("<script language=\"javascript\">\n");
        script.AppendFormat("Radio_NormalLogIn_onclick()");
        script.Append("</script>\n");

        Type type = this.GetType();

       if(!ClientScript.IsClientScriptBlockRegistered(type, "divToggleSwitch"))
           ClientScript.RegisterClientScriptBlock(type, "divToggleSwitch",
            script.ToString());
          }


        private void ShowOpenIDSettingsScript()
        {
            StringBuilder script = new System.Text.StringBuilder();

            script.Append("<script language=\"javascript\">\n");
            script.AppendFormat("Radio_OpenID_onclick()");
            script.Append("</script>\n");

            Type type = this.GetType();

            if (!ClientScript.IsClientScriptBlockRegistered(type, "divToggleSwitch"))
                ClientScript.RegisterClientScriptBlock(type, "divToggleSwitch",
                 script.ToString());
        }

    }
}
