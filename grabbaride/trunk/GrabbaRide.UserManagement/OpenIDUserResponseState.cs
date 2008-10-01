using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrabbaRide.Database;
using DotNetOpenId;
using DotNetOpenId.Extensions.SimpleRegistration;
using System.Web;
using DotNetOpenId.RelyingParty;

namespace GrabbaRide.UserManagement
{
    class OpenIDUserResponseState
    {
        public OpenIDUserResponseState(IAuthenticationResponse response)
        {
            LoginName = response.FriendlyIdentifierForDisplay;
            Profile = response.GetExtension<ClaimsResponse>();
        }

     
        public  ClaimsResponse Profile
        {
            get { return HttpContext.Current.Session["ProfileFields"] as ClaimsResponse; }
            set { HttpContext.Current.Session["ProfileFields"] = value; }
        }
        public string LoginName
        {
            get { return HttpContext.Current.Session["FriendlyUsername"] as string; }
            set { HttpContext.Current.Session["FriendlyUsername"] = value; }
        }


       
       
    }
}
