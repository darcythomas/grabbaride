using System;
using System.Collections.Generic;
using System.Web.UI;
using GrabbaRide.Database;

using Google.GData.Calendar;
using Google.GData.Client;
using Google.GData.Extensions;
using System.Net;

namespace GrabbaRide.Frontend
{
 
    public partial class RideDetails : System.Web.UI.Page
    {
        static String tempToken2;
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

                // make sure we have a ride id
                if (String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    Response.Redirect("Search.aspx");
                }


                // If this is a redirect back from the google authentation 
                if (Request.QueryString["token"] != null)
                {
                    try
                    {
                        String token = Request.QueryString["token"];
                        String NewToken = AuthSubUtil.exchangeForSessionToken(token, null).ToString();
                         
                        Session.Remove("token"); // just to be sure

                        Session.Add("token", NewToken);
                        String test = Session["token"].ToString();

                      
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error processing request: " + ex.ToString());
                    }
                    //This gets us our session authcation
                    GAuthSubRequestFactory authFactory = new GAuthSubRequestFactory("cl", "CalendarSampleApp"); // tidy this up
                    try
                    {

                        authFactory.Token = Session["token"].ToString();
                       
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error processing request: " + ex.ToString());
                    }
                    /*
                    CalendarService service = new CalendarService(authFactory.ApplicationName);
                    Google.GData.Calendar.EventEntry entry = new Google.GData.Calendar.EventEntry();

                    // Set the title and content of the entry.
                    entry.Title.Text = "Tennis with Beth";
                    entry.Content.Content = "Meet for a quick lesson.";

                    // Set a location for the event.
                    Where eventLocation = new Where();
                    eventLocation.ValueString = "South Tennis Courts";
                    entry.Locations.Add(eventLocation);

                    When eventTime = new When(DateTime.Now, DateTime.Now.AddHours(2));
                    entry.Times.Add(eventTime);

                    Uri postUri = new Uri("http://www.google.com/calendar/feeds/default/private/full");

                    try
                    {
                        // Send the request and receive the response:
                        AtomEntry insertedEntry = service.Insert(postUri, entry);
                    }
                    catch (GDataRequestException gdre)
                    {
                        HttpWebResponse response = (HttpWebResponse)gdre.Response;

                        //bad auth token, clear session and refresh the page
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            Session.Clear();
                            Response.Redirect(Request.Url.AbsolutePath, true);
                        }
                    }
                      */  

                //  /*
                    CalendarService service = new CalendarService( authFactory.ApplicationName);
                   
                    service.RequestFactory = authFactory;

                    Google.GData.Calendar.EventEntry calToPush = new Google.GData.Calendar.EventEntry();

                    String recurData =
                      "DTSTART;VALUE=DATE:20081007\r\n" +
                      "DTEND;VALUE=DATE:20090502\r\n" +
                      "RRULE:FREQ=WEEKLY;BYDAY=Tu;UNTIL=20090904\r\n";

                    Recurrence recurrence = new Recurrence();
                    recurrence.Value = recurData;
                    calToPush.Recurrence = recurrence;

                    /*
                    Reminder fifteenMinReminder = new Reminder();
                    fifteenMinReminder.Minutes = 15;
                    fifteenMinReminder.Method = Reminder.ReminderMethod.sms;
                    calToPush.Reminders.Add(fifteenMinReminder);
                    */

                      try
                    {
                        Uri postUri = new Uri("http://www.google.com/calendar/feeds/default/private/full");

                        // Send the request and receive the response:
                        AtomEntry insertedEntry = service.Insert(postUri, calToPush);
                        insertedEntry.Update();
                          
                       
                    }
                    catch (GDataRequestException gdre)
                    {
                        HttpWebResponse response = (HttpWebResponse)gdre.Response;

                        //bad auth token, clear session and refresh the page
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            Session.Clear();
                            Response.Redirect(Request.Url.AbsolutePath, true);
                           
                        }
                        else
                        {
                            Response.Write("Error processing request: " + gdre.ToString());
                        }
                   
                    }
                    Session.Remove("token");// note: rarther than deleting this session token 
                                            //  -as it doesn't expire- we could save it in the user table in the db
                                            // this works for now and means we dont have to worry about 
                                            // the security of the db so much at the cost of incovenence 
                                            // to the user having to conferm for each ride
                    Response.Redirect(Request.Url.AbsoluteUri);
  //*/
                }



                // get the ride details
                GoogleMaps.LoadGoogleMapsScripts(this.Page);
                GrabbaRideDBDataContext db = new GrabbaRideDBDataContext();
                int rideID = Convert.ToInt32(Request.QueryString["id"]);
                Ride thisride = db.GetRideByID(rideID);
                
                if (thisride != null)
                {
                    // set the hidden fields for google maps
                    hfstart.Value = String.Format("{0},{1}",
                        thisride.LocationFromLat, thisride.LocationFromLong);
                    hfend.Value = String.Format("{0},{1}",
                        thisride.LocationToLat, thisride.LocationToLong);

                    if (thisride.User.Username == User.Identity.Name)
                    {
                        // display "my profile", make editable
                        DetailsView1.AutoGenerateEditButton = true;

                        //TODO: display buton to remove ride

                        // hide email user box
                        EmailUserDiv.Visible = false;
                    }
                    else
                    {
                        // disallow editing
                        DetailsView1.AutoGenerateEditButton = false;
                        DetailsView1.AutoGenerateDeleteButton = false;
                    }
                }
            }
        }

        protected void addToGcalender_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(AuthSubUtil.getRequestUrl(Request.Url.AbsoluteUri,
                                                        "http://www.google.com/calendar/feeds/",
                                                        false,
                                                        true));
            
        }

        /// <summary>
        /// Sends an email to this user.
        /// </summary>
        protected void EmailMessageSend_Click(object sender, EventArgs e)
        {
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User userSend = dataContext.GetUserByUsername(Page.User.Identity.Name);
            User userRecv = dataContext.GetRideByID(Int32.Parse(Request.QueryString["id"])).User;
            userRecv.SendMessage(EmailMessage.Text, userSend);
        }
    }
}
