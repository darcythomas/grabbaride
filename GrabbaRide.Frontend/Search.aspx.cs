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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //GrabbaRide.Database.GrabbaRideDBDataContext gdb = new GrabbaRide.Database.GrabbaRideDBDataContext();

            //ListView1.DataSource = gdb.Rides;

            
            
            string date = Request.QueryString["date"];
            string fromLoc = Request.QueryString["fromloc"];
            string toLoc = Request.QueryString["toloc"];

            if (String.IsNullOrEmpty(date) &&
                String.IsNullOrEmpty(fromLoc) &&
                String.IsNullOrEmpty(toLoc))
            {
                GridView1.Visible = false;
            }
            else
            {
                GrabbaRideDataSource.Where = String.Empty;

                if (!String.IsNullOrEmpty(date))
                {
                    GrabbaRideDataSource.Where += "Date = " + date;
                }
                if (!String.IsNullOrEmpty(fromLoc))
                {
                    if (!String.IsNullOrEmpty(GrabbaRideDataSource.Where))
                        GrabbaRideDataSource.Where += " && ";
                    GrabbaRideDataSource.Where += "FromLocationID = " + fromLoc;
                }
                if (!String.IsNullOrEmpty(toLoc))
                {
                    if (!String.IsNullOrEmpty(GrabbaRideDataSource.Where))
                        GrabbaRideDataSource.Where += " && ";
                    GrabbaRideDataSource.Where += "ToLocationID = " + toLoc;
                }
            }
        }
    }
}
