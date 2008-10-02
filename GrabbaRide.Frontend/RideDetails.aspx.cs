using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Data.Linq;
using GrabbaRide.Database;

namespace GrabbaRide.Frontend
{
    public partial class RideDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // must be logged in to view this page
                if (!Request.IsAuthenticated)
                {
                    Response.Redirect("Login.aspx?RedirectUrl=RideDetails.aspx");
                }

                try
                {
                    
                    int rideID = Int32.Parse(Request.QueryString["id"]);
                    GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
                    Ride ride = dataContext.GetRideByID(rideID);

                    List<Ride> rideList = new List<Ride>();
                    rideList.Add(ride);

                    DetailsView1.DataSource = rideList;
                    DetailsView1.DataBind();

                    hfstart.Value = String.Format("{0},{1}",
                        ride.LocationFromLat, ride.LocationFromLong);
                    hfend.Value = String.Format("{0},{1}",
                        ride.LocationToLat, ride.LocationToLong);

                    GoogleMaps.LoadGoogleMapsScripts(this.Page);
                }
                catch (ArgumentNullException)
                {
                    // show the invalid ride id div
                    RideInvalidDiv.Visible = true;
                    RideDetailsDiv.Visible = false;
                }
            }
        }
    }
}
