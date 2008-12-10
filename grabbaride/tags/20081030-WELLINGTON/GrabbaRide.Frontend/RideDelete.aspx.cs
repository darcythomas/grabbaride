using System;
using System.Web.UI;
using GrabbaRide.Database;

namespace GrabbaRide.Frontend
{
    public partial class RideDelete : System.Web.UI.Page
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
                CreatedLabel.Text = ride.CreationDate.ToString("d MMM yyyy");
                EndDateLabel.Text = ride.EndDate.ToString("d MMM yyyy");
                NumSeatsLabel.Text = ride.NumSeats.ToString();
                RecurDaysLabel.Text = ride.DaysAvailable;

                // set the hidden fields and show google maps
                hfstart.Value = ride.HiddenFieldStart;
                hfend.Value = ride.HiddenFieldEnd;
                GoogleMaps.LoadGoogleMapsScripts(this.Page);
            }
        }

        protected void DeleteConfirmNo_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("RideDetails.aspx?id={0}", Request.QueryString["id"]));
        }

        protected void DeleteConfirmYes_Click(object sender, EventArgs e)
        {
            // set the ride to unavailable
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            Ride ride = dataContext.GetRideByID(Int32.Parse(Request.QueryString["id"]));
            ride.Available = false;
            dataContext.SubmitChanges();

            // show the success label
            DeleteConfirmNo.Visible = false;
            DeleteConfirmYes.Visible = false;
            DeleteSuccessLabel.Visible = true;
            DeleteSuccessContinue.Visible = true;
        }

        protected void DeleteSuccessContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetails.aspx");
        }
    }
}
