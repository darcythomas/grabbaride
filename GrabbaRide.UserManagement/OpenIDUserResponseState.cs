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
    public class OpenIDUserResponseState
    {
        public OpenIDUserResponseState(OpenIdEventArgs e)
        { 
            LoginName = e.Response.FriendlyIdentifierForDisplay;
            Profile = e.Response.GetExtension<ClaimsResponse>();
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

        public Boolean AllRequiredFeilds()
        {
            if (Profile == null)
                return false;
            else
            {
              
                return ((Profile.FullName != null) && (Profile.Gender != null) && 
                    (Profile.Email != null));
            }
        }

        



       
       
    }
}
