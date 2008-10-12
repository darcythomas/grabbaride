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

namespace GrabbaRide.Frontend
{
    public partial class CreateRide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // must be logged in to view this page
            if (!Request.IsAuthenticated)
            {
                string me = Uri.EscapeDataString(Request.Url.PathAndQuery);
                Response.Redirect(String.Format("Login.aspx?RedirectUrl={0}", me));
            }

            if (!Page.IsPostBack)
            {
                // dynamically choose which google maps script to load
                GoogleMaps.LoadGoogleMapsScripts(this.Page);
            }

            // hide or show the calendar?
            if (StartDateRadioList.SelectedIndex == 0)
            {
                calstart.Visible = false;
                calstart.SelectedDate = DateTime.Now;
            }
            else
            {
                calstart.Visible = true;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            // all of our inputs get checked for validity client-side before this code gets run
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            Ride newRide = new Ride();

            // ride owner and availability
            newRide.Available = true;
            newRide.User = dataContext.GetUserByUsername(User.Identity.Name);

            // start and end dates
            newRide.StartDate = calstart.SelectedDate;
            int advLengthDays = Int32.Parse(AdvLengthDropDown.SelectedValue);
            newRide.EndDate = newRide.StartDate.AddDays(advLengthDays);

            // ride seats & days
            newRide.NumSeats = int.Parse(drpSeats.Text);
            newRide.RecurMon = chkmon.Checked;
            newRide.RecurTue = chktue.Checked;
            newRide.RecurWed = chkwed.Checked;
            newRide.RecurThu = chkthurs.Checked;
            newRide.RecurFri = chkfri.Checked;
            newRide.RecurSat = chksat.Checked;
            newRide.RecurSun = chksun.Checked;

            // get time
            int hrs = Int32.Parse(drphours.SelectedValue);
            if (drpdayhalf.SelectedValue == "pm") { hrs += 12; }
            int mins = Int32.Parse(drpmins.SelectedValue);
            newRide.DepartureTime = new TimeSpan(hrs, mins, 0);

            // get the longitude and latitude data
            String[] fromLocation = hfstart.Value.Split(',');
            String[] toLocation = hfend.Value.Split(',');

            if (fromLocation.Length > 1)
            {
                newRide.LocationFromLat = Double.Parse(fromLocation[0]);
                newRide.LocationFromLong = Double.Parse(fromLocation[1]);
            }
            if (toLocation.Length > 1)
            {
                newRide.LocationToLat = Double.Parse(toLocation[0]);
                newRide.LocationToLong = Double.Parse(toLocation[1]);
            }

            newRide.Details = txtDescription.Text;

            // finally, add the ride
            dataContext.AttachRide(newRide);

            // redirect to the search results page ;)
            Response.Redirect("Search.aspx" +
                String.Format("?fromloc={0}&toloc={1}", hfstart.Value, hfend.Value) +
                String.Format("&hours={0}&mins={1}", newRide.DepartureTime.Hours, newRide.DepartureTime.Minutes) +
                String.Format("&mon={0}&tue={1}&wed={2}&thu={3}&fri={4}&sat={5}&sun={6}",
                newRide.RecurMon, newRide.RecurTue, newRide.RecurWed, newRide.RecurThu,
                newRide.RecurFri, newRide.RecurSat, newRide.RecurSun));
        }
    }
}
