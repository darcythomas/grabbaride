using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetOpenId.Extensions.SimpleRegistration;

namespace GrabbaRide.Frontend
{
    public partial class OpenIDError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
         
             //build the page around the claims request
             SetVisablePageLoad(HttpContext.Current.Session["MissingClaimsRequest"] as ClaimsRequest);

        

        }

        private void SetVisablePageLoad(ClaimsRequest claimsRequest)
        {
            if (claimsRequest.FullName == DemandLevel.Require)
            {
                TxtBox_First.Visible = true;
                TxtBox_Last.Visible = true;
                FristNameLbl.Visible = true;
                LastNameLbl.Visible = true;

            }


            if (claimsRequest.Gender == DemandLevel.Require)
            {
                GenderList.Visible = true;
                GenderLbl.Visible = true;
            }


            if (claimsRequest.Email == DemandLevel.Require)
            {

                TxtBox_Email.Visible = true;
                EmailLbl.Visible = true;
            }
         
            
           
        }

        

      
    }
}
