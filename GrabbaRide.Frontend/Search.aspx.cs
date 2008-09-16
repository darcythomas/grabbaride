using System;

using GrabbaRide.Database;

namespace GrabbaRide.Frontend
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadQueryStringValues();

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

        /// <summary>
        /// Loads values from the query string back into the search fields,
        /// so that people can see what the searched for.
        /// </summary>
        protected void LoadQueryStringValues()
        {
            // TODO: load the google map with a location

            // update the time
            if (!String.IsNullOrEmpty(Request.QueryString["hours"]))
            {
                int hours = Int32.Parse(Request.QueryString["hours"]);
                if (hours >= 12)
                {
                    drpdayhalf.SelectedValue = "pm";
                    hours -= 12;
                }
                drphours.SelectedValue = hours.ToString();
            }

            if (!String.IsNullOrEmpty(Request.QueryString["mins"]))
            {
                drpmins.SelectedValue = Request.QueryString["mins"];
            }

            // update the days
            if (!String.IsNullOrEmpty(Request.QueryString["mon"]))
            { chkmon.Checked = Boolean.Parse(Request.QueryString["mon"]); }
            if (!String.IsNullOrEmpty(Request.QueryString["tue"]))
            { chktue.Checked = Boolean.Parse(Request.QueryString["tue"]); }
            if (!String.IsNullOrEmpty(Request.QueryString["wed"]))
            { chkwed.Checked = Boolean.Parse(Request.QueryString["wed"]); }
            if (!String.IsNullOrEmpty(Request.QueryString["thu"]))
            { chkthu.Checked = Boolean.Parse(Request.QueryString["thu"]); }
            if (!String.IsNullOrEmpty(Request.QueryString["fri"]))
            { chkfri.Checked = Boolean.Parse(Request.QueryString["fri"]); }
            if (!String.IsNullOrEmpty(Request.QueryString["sat"]))
            { chksat.Checked = Boolean.Parse(Request.QueryString["sat"]); }
            if (!String.IsNullOrEmpty(Request.QueryString["sun"]))
            { chksun.Checked = Boolean.Parse(Request.QueryString["sun"]); }
        }

        /// <summary>
        /// Redirects the user to the search results page, based on the values they entered.
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // convert the hours to 24h time
            int hours = Int32.Parse(drphours.SelectedValue);
            if (drpdayhalf.SelectedValue == "pm")
            {
                hours += 12;
            }

            // redirect to the search results
            string search = "Search.aspx?" +
                "fromloc=" + hfstart.Value +
                "&toloc=" + hfend.Value +
                "&hours=" + hours.ToString() +
                "&mins=" + drpmins.SelectedValue +
                "&mon=" + chkmon.Checked +
                "&tue=" + chktue.Checked +
                "&wed=" + chkwed.Checked +
                "&thu=" + chkthu.Checked +
                "&fri=" + chkfri.Checked +
                "&sat=" + chksat.Checked +
                "&sun=" + chksun.Checked;

            Response.Redirect(search);
        }

        /// <summary>
        /// Displays search results, based on values in the query string.
        /// </summary>
        protected void DisplayResults()
        {
            Ride searchedRide = new Ride();

            // location searched for
            string[] fromLoc = Request.QueryString["fromloc"].Split(',');
            if (fromLoc.Length == 2)
            {
                searchedRide.LocationFromLat = Double.Parse(fromLoc[0]);
                searchedRide.LocationFromLong = Double.Parse(fromLoc[1]);
            }

            string[] toLoc = Request.QueryString["toloc"].Split(',');
            if (toLoc.Length == 2)
            {
                searchedRide.LocationToLat = Double.Parse(toLoc[0]);
                searchedRide.LocationToLong = Double.Parse(toLoc[1]);
            }

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
