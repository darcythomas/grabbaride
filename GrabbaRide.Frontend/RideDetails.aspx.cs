﻿using System;
using System.Net;
using System.Web.UI;
using Google.GData.Calendar;
using Google.GData.Client;
using Google.GData.Extensions;
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

                        //Take the single use token and exchange for a sessiontoken
                        String token = Request.QueryString["token"];
                        String NewToken = AuthSubUtil.exchangeForSessionToken(token, null).ToString();

                        Session.Remove("token"); // just to be sure
                        Session.Add("token", NewToken);


                        GrabbaRideDBDataContext GdataContext = new GrabbaRideDBDataContext();
                        var user = GdataContext.GetUserByUsername(Page.User.Identity.Name);
                        user.GAuthToken = Session["token"].ToString();
                        GdataContext.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error processing request: " + ex.ToString());
                    }

                    PostToGcal();
                }

                // is this a successfully added google calendar event
                if (Request.QueryString["gcadded"] == "true")
                {
                    addToGcalender.Visible = false;
                    addedToGcal.Visible = true;
                }

                // get the ride details
                GrabbaRideDBDataContext db = new GrabbaRideDBDataContext();
                int rideID = Convert.ToInt32(Request.QueryString["id"]);
                Ride thisride = db.GetRideByID(rideID);

                if (thisride != null)
                {
                    UserHyperLink.Text = thisride.User.Username;
                    UserHyperLink.NavigateUrl = String.Format("UserDetails.aspx?id={0}", thisride.User.Username);
                    CreatedLabel.Text = thisride.CreationDate.ToString("d MMM yyyy");
                    EndDateLabel.Text = thisride.EndDate.ToString("d MMM yyyy");
                    NumSeatsLabel.Text = thisride.NumSeats.ToString();
                    RecurDaysLabel.Text = thisride.DaysAvailable;
                    DepartureTimeLabel.Text = thisride.DepartureTimeString;
                    DistanceLabel.Text = String.Format("{0:f2} km", thisride.JourneyDistanceKm);
                    RideDetailsLabel.Text = thisride.Details;

                    // set the hidden fields for google maps
                    hfstart.Value = thisride.HiddenFieldStart;
                    hfend.Value = thisride.HiddenFieldEnd;

                    // load gmaps scripts
                    GoogleMaps.LoadGoogleMapsScripts(this.Page);

                    User currentUser = db.GetUserByUsername(Page.User.Identity.Name);
                    if (thisride.User.UserID == currentUser.UserID)
                    {
                        // show ride edit and delete buttons
                        EditDeleteRow.Visible = true;
                        EditRideHyperLink.NavigateUrl = String.Format("RideEdit.aspx?id={0}", thisride.RideID);
                        DeleteRideHyperLink.NavigateUrl = String.Format("RideDelete.aspx?id={0}", thisride.RideID);

                        // hide email user box
                        EmailUserRow.Visible = false;
                    }
                }
            }
        }

        private void PostToGcal()
        {
            GrabbaRideDBDataContext GdataContext = new GrabbaRideDBDataContext();
            Ride thisRide = GdataContext.GetRideByID(Int32.Parse(Request.QueryString["id"]));

            //This gets us our session authcation
            GAuthSubRequestFactory authFactory = new GAuthSubRequestFactory("cl", "Grabbaride");

            try
            {
                authFactory.Token = Session["token"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("Error processing request: " + ex.ToString());
            }

            CalendarService service = new CalendarService(authFactory.ApplicationName);

            service.RequestFactory = authFactory;

            Google.GData.Calendar.EventEntry calToPush = new Google.GData.Calendar.EventEntry();
           
            
            calToPush.Title.Text = "Grabbaride with " + thisRide.User.Username;
            calToPush.Content.Content = thisRide.Details;

            string departTime = new DateTime(thisRide.DepartureTime.Ticks).ToString("HHmmss");
           

            String recurData =
              "DTSTART;TZID=Pacific/Auckland:" + thisRide.StartDate.ToString("yyyyMMdd") + "T" + departTime  + "\r\n" +
              "DURATION:PT30M \r\n" +
              "RRULE:FREQ=WEEKLY;" + "BYDAY=" + thisRide.DaysAvailableICal + ";UNTIL=" + thisRide.EndDate.ToString("yyyyMMdd") + "\r\n";

            Recurrence recurrence = new Recurrence();
            recurrence.Value = recurData;
            calToPush.Recurrence = recurrence;


            Reminder fifteenMinReminder = new Reminder();
            fifteenMinReminder.Minutes = 15;
            fifteenMinReminder.Method = Reminder.ReminderMethod.sms;
            calToPush.Reminders.Add(fifteenMinReminder);


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
                    GetNewToken();
                }
                else
                {
                    Response.Write("Error processing request: " + gdre.ToString());
                }

            }
            String whereToGoNext = Request.Url.AbsolutePath.ToString() + "?id=" + Request.QueryString["id"] + "&gcadded=true";


            Response.Redirect(whereToGoNext.ToString());
        }

        protected void addToGcalender_Click(object sender, ImageClickEventArgs e)
        {
            GrabbaRideDBDataContext GdataContext = new GrabbaRideDBDataContext();
            var user = GdataContext.GetUserByUsername(Page.User.Identity.Name);
            if (user.GAuthToken != null)
            {
                String NewToken = user.GAuthToken.ToString();
                Session.Remove("token"); // just to be sure
                Session.Add("token", NewToken);
                PostToGcal();
            }
            else
            {
                GetNewToken();
            }

        }

        private void GetNewToken()
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
            SendEmailDiv.Visible = false;
            EmailSentDiv.Visible = true;
        }
    }
}
