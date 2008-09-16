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
using ExtremeSwank.OpenId.Plugins.Extensions;




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

                OpenIdClient client = new OpenIdClient();
                switch (client.RequestedMode)// switch the type of request
                {
                    case RequestedMode.IdResolution:
                        if (openid.ValidateResponse())
                        {
                            OpenIdUser thisuser = openid.RetrieveUser();
                            Session["OpenID_UserObject"] = thisuser;
                            // Authentication successful - Perform login here
                        }
                        else
                        {
                            // Authentication failure handled here
                        }
                        break;
                    case RequestedMode.CanceledByUser:
                        // User has cancelled authentication - handle here
                        break;
                }


                // Read the arguments in the current request and
                // automatically validate any OpenID responses,
                // firing events when actions occur.
                openid.HandleResponses();
            }


        }



       

        private OpenIDConsumer GetConsumer()
        {
            // Initialize a new OpenIDConsumer, reading arguments
            // from the current request, and using Session and
            // Application objects to store data.  For more
            // flexibility, see "Disabling Stateful Mode" and 
            // "Persisting Stateful Data" below for more information.
            OpenIDConsumer openid = new OpenIDConsumer();

            // Subscribe to all the events that could occur
            openid.ValidationSucceeded += new EventHandler();
            openid.ValidationFailed += new EventHandler();
           openid.ReceivedCancelResponse += new EventHandler();

            // Subscribing to SetupNeeded is only needed if using immediate authentication
            openid.SetupNeeded += new EventHandler();

            return openid;
           openid.
        }

        protected void LogInButton_Click(object sender, EventArgs e)
        {
            OpenIdClient openid = new OpenIdClient();
            openid.Identity = LoginBox1.Text;
            openid.CreateRequest();
        }

        

       

       
    }
}
