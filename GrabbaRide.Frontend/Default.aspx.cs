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
    public partial class Default : System.Web.UI.Page
    {      
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = "Search.aspx";
            Response.Redirect(search);
        }
    }
}
