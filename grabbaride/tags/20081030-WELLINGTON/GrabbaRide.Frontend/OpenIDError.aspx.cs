using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetOpenId.Extensions.SimpleRegistration;
using GrabbaRide.UserManagement;
using GrabbaRide.Database;
using System.Web.Security;

namespace GrabbaRide.Frontend
{
    public partial class OpenIDError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // can't be logged in to view this page
            if (Request.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                // check we have a response state
                if (HttpContext.Current.Session["MissingClaims"] != null)
                {
                    SetVisablePageLoad();
                }
                else
                {
                    // you can't look at this page
                    Response.Redirect("Login.aspx");
                }
            }
        }

        /// <summary>
        /// Gets the openid response state we were passed.
        /// </summary>
        /// <returns></returns>
        private OpenIDUserResponseState GetResponseState()
        {
            return HttpContext.Current.Session["MissingClaims"] as OpenIDUserResponseState;
        }

        /// <summary>
        /// Automatically fills in name and email data if we have it.
        /// </summary>
        private void SetVisablePageLoad()
        {
            OpenIDUserResponseState responseState = GetResponseState();

            if (responseState.Profile != null)
            {
                if (!String.IsNullOrEmpty(responseState.Profile.FullName))
                {
                    string fullName = responseState.Profile.FullName;
                    int nameSeparator = fullName.LastIndexOf(' ');
                    TxtBox_First.Text = fullName.Substring(0, nameSeparator);
                    TxtBox_Last.Text = fullName.Substring(nameSeparator + 1);
                }

                if (!String.IsNullOrEmpty(responseState.Profile.Email))
                {
                    TxtBox_Email.Text = responseState.Profile.Email;
                }
            }
        }


        protected void SubmitBttn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // add the user to the db
                string password = Guid.NewGuid().ToString();
                Membership.CreateUser(NewUserNameText.Text, password, TxtBox_Email.Text);

                // get the user from the db
                GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
                User u = context.GetUserByUsername(NewUserNameText.Text);

                // set first and last names
                u.FirstName = TxtBox_First.Text;
                u.LastName = TxtBox_Last.Text;
                context.SubmitChanges();

                // add their openid
                OpenIDUserResponseState responseState = GetResponseState();
                OpenID openID = new OpenID(responseState.OpenIDLoginName, u.UserID);
                context.OpenIDs.InsertOnSubmit(openID);
                context.SubmitChanges();

                // log the user in
                FormsAuthentication.RedirectFromLoginPage(u.Username, false);
            }
        }

        /// <summary>
        /// Checks that the username doesn't already exist.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void UsernameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            if (context.GetUserByUsername(args.Value) != null)
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Check that the email address doesn't already exist.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void EmailCustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            if (context.GetUserByEmail(args.Value) != null)
            {
                args.IsValid = false;
            }
        }
    }
}
