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
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("Login.aspx?RedirectUrl=CreateRide.aspx");
            }
            else if (!Page.IsPostBack)
            {
                // preselect some sensible start and end dates
                calstart.SelectedDate = DateTime.Now;
                calEnd.SelectedDate = DateTime.Now.AddMonths(3);
                calEnd.VisibleDate = calEnd.SelectedDate;
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
            newRide.EndDate = calEnd.SelectedDate;

            // ride seats & days
            newRide.NumSeats = int.Parse(drpSeats.Text);
            newRide.RecurMon = chkmon.Checked;
            newRide.RecurTue = chktue.Checked;
            newRide.RecurWed = chkwed.Checked;
            newRide.RecurThu = chkthurs.Checked;
            newRide.RecurFri = chkfri.Checked;
            newRide.RecurSat = chksat.Checked;
            newRide.RecurSun = chksun.Checked;

            // get the longitude and latitude data
            string[] fromLocation = hfstart.Value.Split(',');
            string[] toLocation = hfend.Value.Split(',');

            newRide.LocationFromLat = Double.Parse(fromLocation[0]);
            newRide.LocationFromLong = Double.Parse(fromLocation[1]);
            newRide.LocationToLat = Double.Parse(toLocation[0]);
            newRide.LocationToLong = Double.Parse(toLocation[1]);

            // finally, add the ride
            dataContext.AttachRide(newRide);

            // redirect to the search results page ;)
            Response.Redirect("Search.aspx" +
                String.Format("?fromloc={0}&toloc={1}", hfstart.Value, hfend.Value) +
                String.Format("&hours={0}&mins={1}", "9", "00") +
                String.Format("&mon={0}&tue={1}&wed={2}&thu={3}&fri={4}&sat={5}&sun={6}",
                newRide.RecurMon, newRide.RecurTue, newRide.RecurWed, newRide.RecurThu,
                newRide.RecurFri, newRide.RecurSat, newRide.RecurSun));
        }
    }
}
