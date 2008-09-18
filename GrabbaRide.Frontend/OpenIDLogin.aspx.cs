using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ExtremeSwank.OpenId;
using ExtremeSwank.OpenId.PlugIns.Discovery;




namespace GrabbaRide.Frontend
{
    public partial class OpenIDLogin : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // If this is not a postback, start up the Consumer
            // and handle any OpenID response messages, if present
            if (!IsPostBack)
            {

                OpenIdClient openid = GetClient();
                openid.DetectAndHandleResponse();
            }


        }

        protected void Bttn_OpenIDLogin_Click(object sender, EventArgs e)
        {
            OpenIdClient openid = GetClient();
           
              openid.Identity = textBox_openIDidentity.Text;

              textBox_openIDidentity.Text = "Attempting to contact provider";
            
              openid.CreateRequest();
              
           // openid.begin
        }


        private String normaliseInput(String input)
        {
            StateContainer stateContainer = setStateContainer();
            NormalizationEntry norm = new NormalizationEntry();
            norm.DiscoveryUrl = new Uri(input);
            return norm.NormalizedId;

        
        }

        static StateContainer setStateContainer()
        {
            StateContainer props = new StateContainer();

           // new Xrds(props);
          //  new Yadis(props);
         //  new Html(props);
         //   new IdentityAuthentication(props);

            return props;
        }

       


        private OpenIdClient GetClient()
        {
            
            
            OpenIdClient openid = new OpenIdClient();

            openid.ReturnUrl = Request.Url;

            // Subscribe to all the events that could occur
           
            //events that could occur
            //Validation will be sweet
            openid.ValidationSucceeded += new EventHandler(provider_ValidationSucceeded);
            //Validation may be canceled at the provider by the user
            openid.ReceivedCancel += new EventHandler(provider_ValidationCanceld);
            //provider has no such user
            openid.ReceivedSetupNeeded += new EventHandler(provider_RequestSetup);
            //validation fail or timed out
            openid.ValidationFailed += new EventHandler(provider_ValidationFailed);

          

            return openid;
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void provider_ValidationCanceld(object sender, EventArgs e)
        {
            // Request has been cancelled. Respond appropriately.
            textBox_openIDidentity.Text = "Cancel";
        }

        protected void provider_RequestSetup(object sender, EventArgs e)
        {
            textBox_openIDidentity.Text = "need setup";
        }


        protected void provider_ValidationSucceeded(object sender, EventArgs e)
        {
            // User has been validated!  Respond appropriately.
            OpenIdUser user = ((OpenIdClient)sender).RetrieveUser();
          // user.
            textBox_openIDidentity.Text = "WINNING";
        }

        protected void provider_ValidationFailed(object sender, EventArgs e)
        {
            textBox_openIDidentity.Text = "burn and die";
            // Validating the user has failed.  Respond appropriately.
        }

      


       

       


    }

}