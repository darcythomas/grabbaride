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
            // WHERE THE HELL IS MY RESPONSE FEILDS... .. using this for testing at the mo.... 
            // back in 5 haha going to read more about sessions and why my session is being
            // garbage collected...
            ClaimsResponse profile =HttpContext.Current.Session["ProfileFields"] as ClaimsResponse;

            
            OpenIDUserResponseState response = new OpenIDUserResponseState(e);
            // currently this line bugged coz profile feilds lost in response...
            //aids leave this if your at massey youll do more harm than good trying to fuck around
            //blind behind a proxy... you shouldnt even enter this method coz
            //it just times out... ending at OpenIdLogin1_Failed()
            //System.Diagnostics.Debug.WriteLine(response.Profile.Email);
         
           
         
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
