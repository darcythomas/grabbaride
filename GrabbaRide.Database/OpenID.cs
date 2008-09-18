using System;

namespace GrabbaRide.Database
{
    public partial class OpenID
    {
        public OpenID(string url, int userID)
            : this()
        {
            this.OpenIDUrl = url;
            this.UserID = userID;
        }
    }
}
