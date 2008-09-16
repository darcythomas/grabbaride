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
using ExtremeSwank.OpenID;
using ExtremeSwank.OpenID.PlugIns.Extensions;


namespace GrabbaRide.Frontend
{
    public partial class OpenIDLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OpenIDConsumer openid = GetConsumer();

                // Read the arguments in the current request and
                // automatically validate any OpenID responses,
                // firing events when actions occur.
                openid.HandleResponses();

            }
        }

        private OpenIDConsumer GetConsumer()
        {
            throw new NotImplementedException();
        }



    }
}
