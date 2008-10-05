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
                return ((Profile.FullName == null) || (Profile.Gender == null) || (Profile.BirthDate == null) ||
                    (Profile.Email == null));
            }
        }

        public ClaimsRequest ClaimsRequestMissing()
        {
            
            ClaimsRequest request = new ClaimsRequest();
            if (Profile == null)
            {
                request.FullName = DemandLevel.Require;
                request.Gender = DemandLevel.Require;
                request.Email = DemandLevel.Require;
            }
            else
            {

                if (Profile.BirthDate == null)
                    request.BirthDate = DemandLevel.Require;
                if (Profile.Email == null)
                    request.Email = DemandLevel.Require;
                if (Profile.Gender == null)
                    request.Gender = DemandLevel.Require;
                if (Profile.FullName == null)
                    request.FullName = DemandLevel.Require;

               
            }
            return request;
        }




       
       
    }
}
