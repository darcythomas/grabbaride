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
        private  ClaimsRequest claimsRequest;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.claimsRequest = HttpContext.Current.Session["MissingClaimsRequest"] as ClaimsRequest;
             //build the page around the claims request
             SetVisablePageLoad();

        

        }

        private void SetVisablePageLoad()
        {
            if ( claimsRequest==null || (claimsRequest.FullName == DemandLevel.Require) )
            {
                TxtBox_First.Visible = true;
                TxtBox_Last.Visible = true;
                FristNameLbl.Visible = true;
                LastNameLbl.Visible = true;

            }


            if (claimsRequest == null || (claimsRequest.Gender == DemandLevel.Require))
            {
                GenderList.Visible = true;
                GenderLbl.Visible = true;
            }


            if (claimsRequest == null || (claimsRequest.Email == DemandLevel.Require) )
            {

                TxtBox_Email.Visible = true;
                EmailLbl.Visible = true;
            }
         
            
           
        }

        protected void SubmitBttn_Click(object sender, EventArgs e)
        {
            //get any data we do have
         //   ClaimsRequest request = HttpContext.Current.Session["MissingClaimsRequest"] as ClaimsRequest;
            ClaimsResponse response;
            if (claimsRequest == null)
            {
                ClaimsRequest r = new ClaimsRequest();
                response = r.CreateResponse();
            }

            else
                response = claimsRequest.CreateResponse();

            //fill in the response

            if(EmailLbl.Visible==true&&TxtBox_Email.Visible==true)
                response.Email = sanitiseEmail(TxtBox_Email.Text);
            if (GenderLbl.Visible == true && GenderList.Visible == true)
                response.Gender = getGender();
            if (FristNameLbl.Visible = true && TxtBox_First.Visible == true)
                response.FullName = getFullName(TxtBox_First.Text, TxtBox_Last.Text);
            //save to sesion and redirect

            Session.Add("ProfileFields", response);

            //or redirect to login to inject into db????
            Response.Redirect("Defult.aspx");
          
        }

        private Gender getGender()
        {
            if (GenderList.SelectedItem.Value == "Male")
                return Gender.Male;
            else return Gender.Female;
        }


        private string sanitiseEmail(string email)
        {
            return email;// haha yes ill actually do some spring cleaning soon
        }

        private string getFullName(string first, string last)
        {
            return first + " " + last;
        }

        

      
    }
}
