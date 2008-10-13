using System;

using GrabbaRide.Database;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace GrabbaRide.Frontend
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // dynamically choose which google maps script to load
                GoogleMaps.LoadGoogleMapsScripts(this.Page);

                // redisplay the values that the user searched for
                LoadQueryStringValues();

                // display the results?
                if (!String.IsNullOrEmpty(Request.QueryString["fromloc"]) &&
                    !String.IsNullOrEmpty(Request.QueryString["toloc"]))
                {
                    DisplayResults();
                }
            }
        }

        /// <summary>
        /// Loads values from the query string back into the search fields,
        /// so that people can see what the searched for.
        /// </summary>
        protected void LoadQueryStringValues()
        {
            // load the google map with a location
            hfstart.Value = Request.QueryString["fromloc"];
            hfend.Value = Request.QueryString["toloc"];

            // update the time
            if (!String.IsNullOrEmpty(Request.QueryString["hours"]))
            {
                int hours = Int32.Parse(Request.QueryString["hours"]);
                if (hours >= 12)
                {
                    drpampm.SelectedValue = "p.m.";
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
            if (Page.IsValid)
            {
                // convert the hours to 24h time
                int hours = Int32.Parse(drphours.SelectedValue);
                if (drpampm.SelectedValue == "p.m.")
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
        }

        /// <summary>
        /// Displays search results, based on values in the query string.
        /// </summary>
        protected void DisplayResults()
        {
            // show results pane
            SearchResultsDiv.Visible = true;
            SearchDetailsTitle.Text = "Search again?";

            Ride searchedRide = new Ride();

            // location searched for
            if (!String.IsNullOrEmpty(Request.QueryString["fromloc"]))
            {
                string[] fromLoc = Request.QueryString["fromloc"].Split(',');
                if (fromLoc.Length == 2)
                {
                    searchedRide.LocationFromLat = Double.Parse(fromLoc[0]);
                    searchedRide.LocationFromLong = Double.Parse(fromLoc[1]);
                }
            }

            if (!String.IsNullOrEmpty(Request.QueryString["toloc"]))
            {
                string[] toLoc = Request.QueryString["toloc"].Split(',');
                if (toLoc.Length == 2)
                {
                    searchedRide.LocationToLat = Double.Parse(toLoc[0]);
                    searchedRide.LocationToLong = Double.Parse(toLoc[1]);
                }
            }

            // days of the week searched for
            if (!String.IsNullOrEmpty(Request.QueryString["mon"]))
                searchedRide.RecurMon = Boolean.Parse(Request.QueryString["mon"]);
            if (!String.IsNullOrEmpty(Request.QueryString["tue"]))
                searchedRide.RecurTue = Boolean.Parse(Request.QueryString["tue"]);
            if (!String.IsNullOrEmpty(Request.QueryString["wed"]))
                searchedRide.RecurWed = Boolean.Parse(Request.QueryString["wed"]);
            if (!String.IsNullOrEmpty(Request.QueryString["thu"]))
                searchedRide.RecurThu = Boolean.Parse(Request.QueryString["thu"]);
            if (!String.IsNullOrEmpty(Request.QueryString["fri"]))
                searchedRide.RecurFri = Boolean.Parse(Request.QueryString["fri"]);
            if (!String.IsNullOrEmpty(Request.QueryString["sat"]))
                searchedRide.RecurSat = Boolean.Parse(Request.QueryString["sat"]);
            if (!String.IsNullOrEmpty(Request.QueryString["sun"]))
                searchedRide.RecurSun = Boolean.Parse(Request.QueryString["sun"]);

            // time searched for
            if (!String.IsNullOrEmpty(Request.QueryString["hours"]) &&
                !String.IsNullOrEmpty(Request.QueryString["mins"]))
            {
                searchedRide.DepartureTime = new TimeSpan(
                    Int32.Parse(Request.QueryString["hours"]),
                    Int32.Parse(Request.QueryString["mins"]), 0);
            }

            // search for the ride & display results
            GrabbaRideDBDataContext dc = new GrabbaRideDBDataContext();
            List<Ride> results = dc.FindSimilarRides(searchedRide);
            ResultsGridView.DataSource = results;
            ResultsGridView.DataBind();

            if (results.Count == 0)
            {
                SearchResultsLabel.Text = "No rides found!";
                CreateRideLink.Visible = true;
            }
        }

        protected void StartEndLocationsValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (String.IsNullOrEmpty(hfstart.Value) || String.IsNullOrEmpty(hfend.Value))
            {
                args.IsValid = false;
            }
        }
    }
}
