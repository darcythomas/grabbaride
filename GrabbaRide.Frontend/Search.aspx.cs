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

using GrabbaRide.Database;
using System.Collections.Generic;

namespace GrabbaRide.Frontend
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        String returnValue;

        protected void Page_Load(object sender, EventArgs e)
        {
            String fromLoc = Request.QueryString["fromloc"];
            String toLoc = Request.QueryString["toloc"];
            Boolean[] days = new Boolean[7];
            days[0] = Convert.ToBoolean(Request.QueryString["mon"]);
            days[1] = Convert.ToBoolean(Request.QueryString["tue"]);
            days[2] = Convert.ToBoolean(Request.QueryString["wed"]);
            days[3] = Convert.ToBoolean(Request.QueryString["thu"]);
            days[4] = Convert.ToBoolean(Request.QueryString["fri"]);
            days[5] = Convert.ToBoolean(Request.QueryString["sat"]);
            days[6] = Convert.ToBoolean(Request.QueryString["sun"]);

            TimeSpan departure = new TimeSpan(0,0,0);
            if (drpdayhalf.SelectedValue == "am")
                departure = new TimeSpan(Convert.ToInt32(Request.QueryString["hours"]), Convert.ToInt32(Request.QueryString["mins"]), 0);
            else if (drpdayhalf.SelectedValue == "pm")
                departure = new TimeSpan(Convert.ToInt32(Request.QueryString["hours"]) + 12, Convert.ToInt32(Request.QueryString["mins"]), 0);

            if (String.IsNullOrEmpty(fromLoc) &&
                String.IsNullOrEmpty(toLoc))
            {
                GridView1.Visible = false;
            }
            else
            {
                queryDB(fromLoc, toLoc, departure, days);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String search = "Search.aspx?fromloc=" + hfstart.Value;
            search += "&toloc=" + hfend.Value;
            search += "&mon=" + chkmon.Checked;
            search += "&tue=" + chktue.Checked;
            search += "&wed=" + chkwed.Checked;
            search += "&thu=" + chkthu.Checked;
            search += "&fri=" + chkfri.Checked;
            search += "&sat=" + chksat.Checked;
            search += "&sun=" + chksun.Checked;
            search += "&hours=" + drphours.SelectedValue;
            search += "&mins=" + drpmins.SelectedValue;
            search += "&daytime=" + drpdayhalf.SelectedValue;
            Response.Redirect(search);
        }

        private void queryDB(String fromLoc, String toLoc, TimeSpan deptime, Boolean[] days)
        {
            Double[] start = new Double[2];
            Double[] end = new Double[2];
            String[] strstart = fromLoc.Split(',');
            String[] strend = toLoc.Split(',');
            start[0] = Convert.ToDouble(strstart[0]);
            start[1] = Convert.ToDouble(strstart[1]);
            end[0] = Convert.ToDouble(strend[0]);
            end[1] = Convert.ToDouble(strend[1]);
            Ride searchride = new Ride();
            GrabbaRideDBDataContext db = new GrabbaRideDBDataContext();
            
            searchride.RecurMon = days[0];
            searchride.RecurTue = days[1];
            searchride.RecurWed = days[2];
            searchride.RecurThu = days[3];
            searchride.RecurFri = days[4];
            searchride.RecurSat = days[5];
            searchride.RecurSun = days[6];

            searchride.DepartureTime = deptime;
            
            if (!String.IsNullOrEmpty(fromLoc))
            {
                if (start != null)
                {
                    searchride.LocationFromLat = start[0];
                    searchride.LocationFromLong = start[1];
                }
            }
            if (!String.IsNullOrEmpty(toLoc))
            {
                if (end != null)
                {
                    searchride.LocationToLat = end[0];
                    searchride.LocationToLong = end[1];
                }
            }
            GridView1.DataSource = db.FindSimilarRides(searchride);
            GridView1.DataBind();
        }
    }
}
