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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.IsAuthenticated)
                {
                    if (String.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        // redirect to "my profile" page
                        Response.Redirect("User.aspx?id=" + User.Identity.Name);
                    }

                    // should we display edit buttons
                    if (Request.QueryString["id"] == User.Identity.Name)
                    {
                        // display "my profile", make editable
                        UserDetailsView.AutoGenerateEditButton = true;
                        // hide rating buttons
                        rateButtons.Visible = false;
                    }
                    else
                    {
                        // display the profile of whoever it is
                        UserDetailsView.AutoGenerateEditButton = false;
                    }

                    // display feedback totals for this user
                    GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
                    User thisuser = dataContext.GetUserByUsername(Request.QueryString["id"]);
                    lblScore.Text = thisuser.FeedbackScoreTotal.ToString();
                    lblNoRatings.Text = thisuser.FeedbackScoreCount.ToString();
                }
                else
                {
                    // must be logged in to view this page
                    Response.Redirect("Login.aspx?RedirectUrl=User.aspx");
                }
            }
        }

        protected void ibtnRateNeg_Click(object sender, ImageClickEventArgs e)
        {
            PlaceRating(-1);
        }

        protected void ibtnRatePos_Click(object sender, ImageClickEventArgs e)
        {
            PlaceRating(1);
        }

        void PlaceRating(short rating)
        {
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User userRater = dataContext.GetUserByUsername(User.Identity.Name);
            User userRated = dataContext.GetUserByUsername(Request.QueryString["id"]);
            dataContext.PlaceFeedbackRating(userRater, userRated, rating);
            Response.Redirect(Request.Url.PathAndQuery);
        }
    }
}
