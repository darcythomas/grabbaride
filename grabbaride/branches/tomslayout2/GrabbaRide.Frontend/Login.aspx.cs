﻿using System;
using System.Web;
using System.Web.UI;
using DotNetOpenId.RelyingParty;
using GrabbaRide.Database;
using GrabbaRide.UserManagement;

namespace GrabbaRide.Frontend
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // set the returnurl
                GrabbaRideLogin.DestinationPageUrl = Request.QueryString["RedirectUrl"];
                GrabbaRideLogin.CreateUserUrl += Request.Url.Query;

                // detect session data and respond acordingly
                OpenIDUserResponseState state = HttpContext.Current.Session["MissingClaims"] as OpenIDUserResponseState;

                //if there is a current login session, and that login session has all required feilds 

                if (state != null && state.AllRequiredFeilds())
                {
                    //inject into database
                    AuthenticateResponse(state);
                }
            }
        }

        public void AuthenticateResponse(OpenIDUserResponseState state)
        {
            // steps for authenication
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext(); 
            GrabbaRideMembershipProvider membership = new GrabbaRideMembershipProvider();
            if (context.IsOpenIDRegistered(state.OpenIDLoginName))
            {// do we have this user already?
              // ep if its sececond time login then we wont be asking them for there grabbaride log in
                // need to store it in db
                membership.ValidateOpenIDUser(state.GrabbaRideLoginName);
            }
            else
            {

                // if so log them in
                // if not
                // add them
               
                membership.OpenIDCreateUser(state);
                // log them in
            }
            Response.Redirect("Default.aspx");
        }

        /// <summary>
        /// Fired upon login.
        /// Note, that straight after login, forms auth will redirect the user to their original page. So this page may never be rendererd.
        /// </summary>
        protected void OpenIdLogin1_LoggedIn(object sender, OpenIdEventArgs e)
        {
            LoggedInLabel.Visible = true;
            LoggedInLabel.Text += " WELCOME" + e.Response.FriendlyIdentifierForDisplay;

            processResponse(new OpenIDUserResponseState(e));
        }

        private void processResponse(OpenIDUserResponseState response)
        {
            // first should check if we have this user?????
            if (!OpenIDSignInPrevious(response))
            { // if not then do the rest.....

                if (!response.AllRequiredFeilds())
                {
                    // add the missing request to the session and redirect
                    Session.Add("MissingClaims", response);
                    Response.Redirect("OpenIDError.aspx?RedirectUrl=Login.aspx");
                }
                else
                {
                    // inject
                    AuthenticateResponse(response);
                }

            }
            else
            {

                // check that openid has autheticated then login the user from our records
            }
        }

        private Boolean OpenIDSignInPrevious(OpenIDUserResponseState response)
        {
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            return context.IsOpenIDRegistered(response.OpenIDLoginName);
        }

        protected void OpenIdLogin1_Failed(object sender, OpenIdEventArgs e)
        {
            loginFailedLabel.Visible = true;
            loginFailedLabel.Text += ": " + e.Response.Exception.Message;
        }

        protected void OpenIdLogin1_Canceled(object sender, OpenIdEventArgs e)
        {
            loginCanceledLabel.Visible = true;
            loginCanceledLabel.Text = ": " + e.Response.Exception.Message;
        }

        protected void OpenIdLogin1_SetupRequired(object sender, OpenIdEventArgs e)
        {
            loginFailedLabel.Text = "It seems you need to set up an openID account";
            loginFailedLabel.Visible = true;
        }
    }
}