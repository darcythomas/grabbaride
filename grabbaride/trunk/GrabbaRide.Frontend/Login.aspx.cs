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
            if (!Page.IsPostBack)
            {
                // need to remember view state
                setDisplay(false, true);
                LoginSelect.SelectedIndex = 0;
            }

            // detect session data and respond acordingly
            OpenIDUserResponseState state = HttpContext.Current.Session["MissingClaims"] as OpenIDUserResponseState;
            //if there is a current login session, and that login session has all required feilds 
            if (state != null && state.AllRequiredFeilds())
            {
                //inject into database
            }
           
        }

        private void setDisplay(Boolean openIDshow, Boolean normalShow)
        {
            if (openIDshow)
            {
                OpenIDPanel.Visible = true;
                NormalLoginPanel.Visible = false;
               
            
                
            }
            else
            {
                OpenIDPanel.Visible = false;
                NormalLoginPanel.Visible = true;
              
            }
           
        }

        protected void LoginSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LoginSelect.SelectedItem.Value == "GrabbaRide")
                setDisplay(false, true);
            else
                setDisplay(true, false);
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
               Response.Redirect("Default.aspx");
              

            }
            else
            {
                //add the missing request to the session and redirect
             Session.Add("MissingClaims",response);
             Response.Redirect("OpenIDError.aspx?RedirectUrl=Login.aspx");
             
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
            loginFailedLabel.Text = "It seems you need to set up an openID account";
            loginFailedLabel.Visible = true;

        }

      

      



       

    }
}
