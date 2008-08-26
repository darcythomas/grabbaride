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
        String returnValue;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                queryDB(fromLoc, toLoc, date);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String search = "Search.aspx?fromloc=" + hfstart.Value;
            search += "&toloc=" + hfend.Value;
            search += "&date=" + calDate.SelectedDate.ToShortDateString();
            Response.Redirect(search);
        }

        private void queryDB(String fromLoc, String toLoc, String date)
        {
            Double[] start = new Double[2];
            Double[] end = new Double[2];
            GrabbaRideDataSource.Where = String.Empty;
            String[] strstart = fromLoc.Split(',');
            String[] strend = toLoc.Split(',');
            start[0] = Convert.ToDouble(strstart[0]);
            start[1] = Convert.ToDouble(strstart[1]);
            end[0] = Convert.ToDouble(strend[0]);
            end[1] = Convert.ToDouble(strend[1]);

            if (!String.IsNullOrEmpty(date))
            {
                String[] datecomponents = new String[3];
                char delim = '/';
                datecomponents = date.Split(delim);
                GrabbaRideDataSource.Where += "StartDate <= DateTime(" + datecomponents[2] + ", " + datecomponents[1] + ", " + datecomponents[0] + 
                                                ") && EndDate >= DateTime(" + datecomponents[2] + ", " + datecomponents[1] + ", " + datecomponents[0] + ")";
            }
            if (!String.IsNullOrEmpty(fromLoc))
            {
                if (start != null) {
                    if (!String.IsNullOrEmpty(GrabbaRideDataSource.Where))
                        GrabbaRideDataSource.Where += " && ";
                    GrabbaRideDataSource.Where += "LocationFromLat <= " + (start[0] + 1);
                    GrabbaRideDataSource.Where += " && ";
                    GrabbaRideDataSource.Where += "LocationFromLat >= " + (start[0] - 1);
                    GrabbaRideDataSource.Where += " && ";
                    GrabbaRideDataSource.Where += "LocationFromLong <= " + (start[1] + 1);
                    GrabbaRideDataSource.Where += " && ";
                    GrabbaRideDataSource.Where += "LocationFromLong >= " + (start[1] - 1);
                }
            }
            if (!String.IsNullOrEmpty(toLoc))
            {
                if (end != null)
                {
                    if (!String.IsNullOrEmpty(GrabbaRideDataSource.Where))
                        GrabbaRideDataSource.Where += " && ";
                    GrabbaRideDataSource.Where += "LocationToLat <= " + (start[0] + 1);
                    GrabbaRideDataSource.Where += " && ";
                    GrabbaRideDataSource.Where += "LocationToLat >= " + (start[0] - 1);
                    GrabbaRideDataSource.Where += " && ";
                    GrabbaRideDataSource.Where += "LocationToLong <= " + (start[1] + 1);
                    GrabbaRideDataSource.Where += " && ";
                    GrabbaRideDataSource.Where += "LocationToLong >= " + (start[1] - 1);
                }
            }
        }
    }
}
