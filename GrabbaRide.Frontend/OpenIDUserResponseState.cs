using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrabbaRide.Database;
using DotNetOpenId;
using DotNetOpenId.Extensions.SimpleRegistration;
using System.Web;

namespace GrabbaRide.UserManagement
{
    class OpenIDUserResponseState
    {
        public static void Clear()
        {
            ProfileFields = null;
            FriendlyLoginName = null;
        }
        public static ClaimsResponse ProfileFields
        {
            get { return HttpContext.Current.Session["ProfileFields"] as ClaimsResponse; }
            set { HttpContext.Current.Session["ProfileFields"] = value; }
        }
        public static string FriendlyLoginName
        {
            get { return HttpContext.Current.Session["FriendlyUsername"] as string; }
            set { HttpContext.Current.Session["FriendlyUsername"] = value; }
        }
       
    }
}
