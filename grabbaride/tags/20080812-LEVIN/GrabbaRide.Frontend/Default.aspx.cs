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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String search = "Search.aspx?fromloc=" + drpFrom.SelectedValue.ToString();
            search += "&toloc=" + drpTo.SelectedValue.ToString();
            if (calDate.SelectedDate >= DateTime.Now)
                search += "&date=" + calDate.SelectedDate.ToShortDateString();
            Response.Redirect(search);
        }
    }
}
