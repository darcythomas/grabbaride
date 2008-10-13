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
            OpenIDLoginName = e.Response.FriendlyIdentifierForDisplay;
            Profile = e.Response.GetExtension<ClaimsResponse>();
            
        }

        public String GrabbaRideLoginName
        {
            get { return HttpContext.Current.Session["GrabbaRideLoginName"] as String; }
            set { HttpContext.Current.Session["GrabbaRideLoginName"] = value; }
        }

        public  ClaimsResponse Profile
        {
            get { return HttpContext.Current.Session["ProfileFields"] as ClaimsResponse; }
            set { HttpContext.Current.Session["ProfileFields"] = value; }
        }
        public string  OpenIDLoginName
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
                    (Profile.Email != null)&&(!String.IsNullOrEmpty(this.GrabbaRideLoginName))&& ValidUserName());
            }
        }

        public Boolean ValidUserName()
        {

            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            return !context.HasUserName(GrabbaRideLoginName)&& !String.IsNullOrEmpty(GrabbaRideLoginName)&& UniqueUserName();
        }


        public bool UniqueUserName()
        {
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();

            return  context.HasUserName(GrabbaRideLoginName);
        }
    }
}
