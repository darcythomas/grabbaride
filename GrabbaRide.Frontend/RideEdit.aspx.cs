using System;
using System.Web.UI;
using GrabbaRide.Database;

namespace GrabbaRide.Frontend
{
    public partial class RideEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // must be logged in to view this page
                if (!Request.IsAuthenticated)
                {
                    string me = Uri.EscapeDataString(Request.Url.PathAndQuery);
                    Response.Redirect(String.Format("Login.aspx?RedirectUrl={0}", me));
                }

                // need a ride id
                if (String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    Response.Redirect("Search.aspx");
                }

                // get the ride object
                GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
                Ride ride = context.GetRideByID(Int32.Parse(Request.QueryString["id"]));

                // check that ride exists
                if (ride == null)
                {
                    Response.Redirect("Search.aspx");
                }

                // check that current user owns ride
                User currentUser = context.GetUserByUsername(Page.User.Identity.Name);
                if (ride.UserID != currentUser.UserID)
                {
                    Response.Redirect(String.Format("RideDetails.aspx?id={0}", ride.RideID));
                }

                // display existing ride details
                DisplayRideDetails(ride);
            }
        }

        private void DisplayRideDetails(Ride ride)
        {
            // display number of seats and departure time
            SeatsDropDown.SelectedValue = ride.NumSeats.ToString();
            int hours = ride.DepartureTime.Hours;
            if (hours >= 12)
            {
                drpdayhalf.SelectedValue = "p.m.";
                hours -= 12;
            }
            drphours.SelectedValue = hours.ToString();
            drpmins.SelectedValue = ride.DepartureTime.Minutes.ToString();

            // display days available
            chkmon.Checked = ride.RecurMon;
            chktue.Checked = ride.RecurTue;
            chkwed.Checked = ride.RecurWed;
            chkthurs.Checked = ride.RecurThu;
            chkfri.Checked = ride.RecurFri;
            chksat.Checked = ride.RecurSat;
            chksun.Checked = ride.RecurSun;

            // lat and long data
            hfstart.Value = ride.HiddenFieldStart;
            hfend.Value = ride.HiddenFieldEnd;

            // show google map
            GoogleMaps.LoadGoogleMapsScripts(this.Page);
        }

        protected void UpdateRideButton_Click(object sender, EventArgs e)
        {
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            Ride ride = context.GetRideByID(Int32.Parse(Request.QueryString["id"]));

            // update the ride details
            ride.NumSeats = Int32.Parse(SeatsDropDown.SelectedValue);
            int hours = Int32.Parse(drphours.SelectedValue);
            if (drpdayhalf.SelectedValue == "p.m.")
            {
                drpdayhalf.SelectedValue = "p.m.";
                hours += 12;
            }
            TimeSpan newDepartTime = new TimeSpan(hours, Int32.Parse(drpmins.SelectedValue), 0);
            if (!ride.DepartureTime.Equals(newDepartTime))
                ride.DepartureTime = newDepartTime;

            // update days available
            ride.RecurMon = chkmon.Checked;
            ride.RecurTue = chktue.Checked;
            ride.RecurWed = chkwed.Checked;
            ride.RecurThu = chkthurs.Checked;
            ride.RecurFri = chkfri.Checked;
            ride.RecurSat = chksat.Checked;
            ride.RecurSun = chksun.Checked;

            // lat and long data
            ride.HiddenFieldStart = hfstart.Value;
            ride.HiddenFieldEnd = hfend.Value;

            // save back to the db
            context.SubmitChanges();

            // redirect to ride details page
            Response.Redirect(String.Format("RideDetails.aspx?id={0}", ride.RideID));
        }
    }
}
