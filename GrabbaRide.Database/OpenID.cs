using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrabbaRide.Database
{
    public partial class OpenID
    {

      

        public OpenID(String url, int userID): this()
        {
            this.OpenIDUrl = url;
            this.UserID = userID;
        }
    }
}
