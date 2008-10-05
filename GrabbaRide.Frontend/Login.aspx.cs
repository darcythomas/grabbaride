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
using GrabbaRide.UserManagement;



namespace GrabbaRide.Frontend
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        /// <summary>
        /// Fired upon login.
        /// Note, that straight after login, forms auth will redirect the user to their original page. So this page may never be rendererd.
        /// </summary>
        protected void OpenIdLogin1_LoggedIn(object sender, OpenIdEventArgs e)
        {
            
            LoggedInLabel.Visible = true;
            LoggedInLabel.Text += " WELCOME" + e.Response.FriendlyIdentifierForDisplay;
       

            
           processResponse( new OpenIDUserResponseState(e));
           
         
         
           
         
        }

        private void processResponse(OpenIDUserResponseState response)
        {
            if (response.AllRequiredFeilds())
            {
                //continue as normal
            }
            else
            {
                //add the missing request to the session and redirect
             Session.Add("MissingClaimsRequest",response.ClaimsRequestMissing());
             Response.Redirect("OpenIDError.aspx?RedirectUrl=Defult.aspx");
             
            }
        }

        
       

    

        protected void OpenIDLogin1_LogginIn(object sender, OpenIdEventArgs e)
        {
            LogginInLable.Visible = true;
      //      LogginInLable.Text +=": " + e.Response.Exception.Message;
            
           
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
            loginFailedLabel.Text = "It seems you need to set up an openID account";
            loginFailedLabel.Visible = true;

        }



       

    }
}
