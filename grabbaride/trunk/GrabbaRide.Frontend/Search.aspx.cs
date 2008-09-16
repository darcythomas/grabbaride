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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request.QueryString["fromloc"]) &&
                String.IsNullOrEmpty(Request.QueryString["toloc"]))
            {
                GridView1.Visible = false;
            }
            else
            {
                DisplayResults();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // convert the hours to 24h time
            int hours = Int32.Parse(drphours.SelectedValue);
            if (drpdayhalf.SelectedValue != "am")
            {
                hours += 12;
            }

            // redirect to the search results
            String search = "Search.aspx?" +
                "fromloc=" + hfstart.Value +
                "&toloc=" + hfend.Value +
                "&mon=" + chkmon.Checked +
                "&tue=" + chktue.Checked +
                "&wed=" + chkwed.Checked +
                "&thu=" + chkthu.Checked +
                "&fri=" + chkfri.Checked +
                "&sat=" + chksat.Checked +
                "&sun=" + chksun.Checked +
                "&hours=" + hours.ToString() +
                "&mins=" + drpmins.SelectedValue;

            Response.Redirect(search);
        }

        protected void DisplayResults()
        {
            Ride searchedRide = new Ride();

            // location searched for
            string[] fromLoc = Request.QueryString["fromloc"].Split(',');
            string[] toLoc = Request.QueryString["toloc"].Split(',');

            searchedRide.LocationFromLat = Double.Parse(fromLoc[0]);
            searchedRide.LocationFromLong = Double.Parse(fromLoc[1]);
            searchedRide.LocationToLat = Double.Parse(toLoc[0]);
            searchedRide.LocationToLong = Double.Parse(toLoc[1]);

            // days of the week searched for
            searchedRide.RecurMon = Boolean.Parse(Request.QueryString["mon"]);
            searchedRide.RecurTue = Boolean.Parse(Request.QueryString["tue"]);
            searchedRide.RecurWed = Boolean.Parse(Request.QueryString["wed"]);
            searchedRide.RecurThu = Boolean.Parse(Request.QueryString["thu"]);
            searchedRide.RecurFri = Boolean.Parse(Request.QueryString["fri"]);
            searchedRide.RecurSat = Boolean.Parse(Request.QueryString["sat"]);
            searchedRide.RecurSun = Boolean.Parse(Request.QueryString["sun"]);

            // time searched for
            searchedRide.DepartureTime = new TimeSpan(
                Int32.Parse(Request.QueryString["hours"]),
                Int32.Parse(Request.QueryString["mins"]), 0);

            // search for the ride & display results
            GrabbaRideDBDataContext dc = new GrabbaRideDBDataContext();
            GridView1.DataSource = dc.FindSimilarRides(searchedRide);
            GridView1.DataBind();
        }
    }
}
