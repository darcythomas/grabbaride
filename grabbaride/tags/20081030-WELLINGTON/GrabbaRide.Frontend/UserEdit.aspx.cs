using System;
using System.Web.UI;
using GrabbaRide.Database;

namespace GrabbaRide.Frontend
{
    public partial class UserEdit : System.Web.UI.Page
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

                // get user object for current user
                GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
                User user = context.GetUserByUsername(Page.User.Identity.Name);

                // set title
                UsernameLabel.Text = user.Username;

                // set current details
                EmailTextBox.Text = user.Email;
                FirstNameTextBox.Text = user.FirstName;
                LastNameTextBox.Text = user.LastName;
                OccupationTextBox.Text = user.Occupation;
                LocationTextBox.Text = user.Location;
                CommentTextBox.Text = user.Comment;
            }
        }

        protected void SaveChangesButton_Click(object sender, EventArgs e)
        {
            // get user object for current user
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            User user = context.GetUserByUsername(Page.User.Identity.Name);

            // update details & save
            user.Email = EmailTextBox.Text;
            user.FirstName = FirstNameTextBox.Text;
            user.LastName = LastNameTextBox.Text;
            user.Occupation = OccupationTextBox.Text;
            user.Location = LocationTextBox.Text;
            user.Comment = CommentTextBox.Text;
            context.SubmitChanges();

            // redirect to user details page
            Response.Redirect(String.Format("UserDetails.aspx?id={0}", user.Username));
        }
    }
}
