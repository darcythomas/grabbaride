using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrabbaRide.Database;
using DotNetOpenId;

namespace GrabbaRide.UserManagement
{
    class OpenIDAuthentication
    {

        private GrabbaRideDBDataContext context;
        private string OpenIDURL;
        private string ReturnURL;
        private Boolean querryProviderToRegisterUser;

        /// <summary>
        /// Constructor for openID authentication
        /// </summary>
        /// <param name="url"></param>
        public OpenIDAuthentication(string OpenIDurl,string returnURL)
        {
            //open a db contex
            this.context = new GrabbaRideDBDataContext();
            this.OpenIDURL = OpenIDurl;
            this.ReturnURL = returnURL;
            if (OpenIDExsistInDB())
            {
                querryProviderToRegisterUser = false;
                // authenicate
                if (!IsUserAlreadySignedIn())
                {
                    // then log them in

                }
                else {
                    ///f the user is already signed in but the OpenID belongs to a different user, 
                    ///show an error message saying that this OpenID has already been claimed by another user.
                    ///You can also provide the user the option to sign out and try again. This is an edge case.
                }
            }
            else
            {
                // add them and authenicate
                querryProviderToRegisterUser = true;
            }
        }

        private Boolean OpenIDExsistInDB()
        {
            return this.context.IsOpenIDRegistered(OpenIDURL);
        }

        private Boolean IsUserAlreadySignedIn()
        {
            return this.context.GetUser_ByOpenID(OpenIDURL).IsSignedIn;
        }

        private void QuerryProviderToRegister()
        {
           // DotNetOpenId.
        }


    }
}
