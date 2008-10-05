using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetOpenId.Extensions.SimpleRegistration;
using GrabbaRide.UserManagement;

namespace GrabbaRide.Frontend
{
    public partial class OpenIDError : System.Web.UI.Page

    {
        private OpenIDUserResponseState claimsRequest;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.claimsRequest = HttpContext.Current.Session["MissingClaims"] as OpenIDUserResponseState;
             //build the page around the claims request
             SetVisablePageLoad();

        

        }

        private void SetVisablePageLoad()
        {
            if (this.claimsRequest==null|| claimsRequest.Profile==null || 
                        (claimsRequest.Profile.FullName == null) )
            {
                TxtBox_First.Visible = true;
                TxtBox_Last.Visible = true;
                FristNameLbl.Visible = true;
                LastNameLbl.Visible = true;

            }

            if (claimsRequest.Profile == null || (claimsRequest.Profile.Gender == null))
            {
                GenderList.Visible = true;
                GenderLbl.Visible = true;
            }


            if (claimsRequest.Profile == null || (claimsRequest.Profile.Email == null) )
            {

                TxtBox_Email.Visible = true;
                EmailLbl.Visible = true;
            }
         
            
           
        }

        protected void SubmitBttn_Click(object sender, EventArgs e)
        {
            //get any data we do have
         //   ClaimsRequest request = HttpContext.Current.Session["MissingClaimsRequest"] as ClaimsRequest;
           
            if (claimsRequest == null || !AllRequiredFeildsSet())
            {

                claimsRequest.Profile = new ClaimsRequest().CreateResponse();
                Session.Add("ProfileFields", RespondToClaim(claimsRequest));
            }

            else
            {
                Boolean test =  AllRequiredFeildsSet();
              
                Session.Add("ProfileFields", RespondToClaim(claimsRequest));
          
            }

          

          

         

            //or redirect to login to inject into db????
            Response.Redirect("Default.aspx");
          
        }

        private OpenIDUserResponseState RespondToClaim(OpenIDUserResponseState response)
        { 
          if(EmailLbl.Visible==true&&TxtBox_Email.Visible==true)
                response.Profile.Email = sanitiseEmail(TxtBox_Email.Text);
            if (GenderLbl.Visible == true && GenderList.Visible == true)
                response.Profile.Gender = getGender();
            if (FristNameLbl.Visible = true && TxtBox_First.Visible == true)
                response.Profile.FullName = getFullName(TxtBox_First.Text, TxtBox_Last.Text);

            return response;
        }

        private Gender getGender()
        {
            if (GenderList.SelectedItem.Value == "Male")
                return Gender.Male;
            else return Gender.Female;
        }

        private Boolean AllRequiredFeildsSet()
        {
            return claimsRequest.AllRequiredFeilds();

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
