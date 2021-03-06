﻿using System;
using System.Web.UI;

using GrabbaRide.Database;

namespace GrabbaRide.Frontend
{
    public partial class UserDetails : System.Web.UI.Page
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

                if (String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    // redirect to "my profile" page
                    Response.Redirect("UserDetails.aspx?id=" + User.Identity.Name);
                }

                // get the user object for the user we are viewing
                GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
                User displayedUser = dataContext.GetUserByUsername(Request.QueryString["id"]);

                // make sure the user exists
                if (displayedUser == null)
                {
                    InvalidUserLabel.Visible = true;
                    UserDetailsDiv.Visible = false;
                }
                else
                {
                    User loggedUser = dataContext.GetUserByUsername(Page.User.Identity.Name);

                    // fill in user details
                    UsernameLabel.Text = displayedUser.Username;
                    NameLabel.Text = displayedUser.FullName;
                    LocationLabel.Text = displayedUser.Location;
                    OccupationLabel.Text = displayedUser.Occupation;
                    MemberSinceLabel.Text = displayedUser.CreationDate.ToString("d MMM yyyy");
                    RatingLabel.Text = displayedUser.FeedbackString;
                    if (!String.IsNullOrEmpty(displayedUser.Comment))
                        CommentLabel.Text = displayedUser.Comment.Replace("\n", "<br />");

                    // check that we have a last seen date
                    if (displayedUser.LastActvityDate.HasValue)
                        LastSeenLabel.Text = displayedUser.LastActvityDate.Value.ToString("d MMM yyyy, h:mm tt");
                    else
                        LastSeenLabel.Text = "Never!";

                    // fill in user's rides (if any)
                    UsersRidesGridView.DataSource = dataContext.GetRidesByUserID(displayedUser.UserID);
                    UsersRidesGridView.DataBind();

                    // if user is viewing their own profile
                    if (displayedUser.UserID == loggedUser.UserID)
                    {
                        // show edit button, hide rating buttons
                        EditUserHyperlink.Visible = true;
                        PlaceRatingTr.Visible = false;
                        RidesCreatedTitle.Text = String.Format(RidesCreatedTitle.Text, "you");
                    }
                    else // we are viewing a different user
                    {
                        RidesCreatedTitle.Text = string.Format(RidesCreatedTitle.Text, displayedUser.Username);

                        // check for an existing rating
                        FeedbackRating existingRating = dataContext.GetFeedbackRating(loggedUser, displayedUser);

                        if (existingRating != null)
                        {
                            // show existing rating, hide place rating text
                            ExistingRatingSpan.Visible = true;
                            PlaceRatingLabel.Visible = false;

                            switch (existingRating.Rating)
                            {
                                case -1:
                                    ExistingRatingNegativeImage.Visible = true;
                                    break;
                                case 0:
                                    ExistingRatingNeutralImage.Visible = true;
                                    break;
                                case 1:
                                    ExistingRatingPositiveImage.Visible = true;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        protected void PlaceRatingPositiveButton_Click(object sender, ImageClickEventArgs e)
        {
            PlaceFeedbackRating(1);
        }

        protected void PlaceRatingNeutralButton_Click(object sender, ImageClickEventArgs e)
        {
            PlaceFeedbackRating(0);
        }

        protected void PlaceRatingNegativeButton_Click(object sender, ImageClickEventArgs e)
        {
            PlaceFeedbackRating(-1);
        }

        private void PlaceFeedbackRating(short rating)
        {
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            context.PlaceFeedbackRating(Page.User.Identity.Name, Request.QueryString["id"], rating);
            Response.Redirect(Request.Url.PathAndQuery);
        }
    }
}
