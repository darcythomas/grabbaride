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
            else
            {
                
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            
            Ride newRide = new Ride();
            String[] loctemp;    // temp location for location when splitting long/late up
            String fromloc;
            String toloc;

            if (hfstart.Value == null)
            {
                // display message to user "enter a location(s)"
                
                return;
            }
            else
            {
                 fromloc = hfstart.Value;                 
            }

            if (hfend.Value == null)
            {
                // display message to user "enter a location(s)"                
                return;
            }
            else
            {
                toloc = hfend.Value;
            }
                          
            newRide.UserID = int.Parse(Request.QueryString["id"]);   // assumed to be a valid id string if the page_loads ^^^^
            newRide.Available = true;
            newRide.CreationDate = DateTime.Now;
            //newRide.DepartureTime = 0.0f;
            if (calstart.SelectedDate == null)
            {
                
                return;
            }
            else
            {
                newRide.StartDate = calstart.SelectedDate;
            }

            if (calEnd.SelectedDate == null)
            {
                //display error msg
            }
            else
            {
                newRide.EndDate = calEnd.SelectedDate;
            }
            
            newRide.NumSeats = int.Parse(drpSeats.Text); // seats is at least 1 always
            newRide.RecurMon = chkmon.Checked;  // safe inputs
            newRide.RecurTue = chktue.Checked;
            newRide.RecurWed = chkwed.Checked;
            newRide.RecurThu = chkthurs.Checked;
            newRide.RecurFri = chkfri.Checked;
            newRide.RecurSat = chksat.Checked;
            newRide.RecurSun = chksun.Checked;
           
            // add the longitude and latitude data
            loctemp = fromloc.Split(',');         // formatting the from location into 2 strings in loctemp   
            newRide.LocationFromLat = double.Parse(loctemp[0]);  // adding the location          
            newRide.LocationFromLong = double.Parse(loctemp[1]);
            loctemp = toloc.Split(',');         // formatting the to location into 2 strings in loctemp
            newRide.LocationToLat = double.Parse(loctemp[0]);  
            newRide.LocationToLong = double.Parse(loctemp[1]);              


            // finally, add the ride
            dataContext.AttachRide(newRide);            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
        }
    }
}
