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
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
            loadViewState();
            if (!Page.IsPostBack)
            {

                if (getResponse() != null)
                {
                    SetVisablePageLoad();
                    
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
           //     loadViewState();
            }
        

        }

        private OpenIDUserResponseState getResponse()
        { 
            return HttpContext.Current.Session["MissingClaims"] as OpenIDUserResponseState;
        }

        private void SetVisablePageLoad()
        {
            OpenIDUserResponseState claimsRequest = getResponse();

            if (claimsRequest.Profile==null || 
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
           
            OpenIDUserResponseState claimsRequest = getResponse();
            if (claimsRequest == null || !AllRequiredFeildsSet())
            {
                //check the user input if not ok reload the page with stuff that needs to be filed correctly 
                if (!claimsRequest.UniqueUserName())
                {
                    
                    // set the veiw state
                   

                }
                ///more input testing
                
                //post back
                Response.Redirect("OpenIDError.aspx");


                //testing
                Boolean allfeildsset = AllRequiredFeildsSet();
                Boolean isnull= claimsRequest==null;
                claimsRequest = RespondToClaim(claimsRequest);
                Session.Add("MissingClaims", RespondToClaim(claimsRequest)); 
                setViewState();
            }

            else
            {
                Boolean test =  AllRequiredFeildsSet();

                Session.Add("MissingClaims", RespondToClaim(claimsRequest));
          
            }





        

  
            Response.Redirect("Login.aspx");
          
        }

        private void loadViewState()
        {
            if (!Page.IsPostBack && getResponse() != null && !getResponse().UniqueUserName())
            {
                usernameError.Visible = true;
            }
            if(ViewState["FirstName"]!=null)
                TxtBox_First.Text = ViewState["FirstName"].ToString();
            if (ViewState["LastName"] != null)
                TxtBox_Last.Text =  ViewState["LastName"].ToString();
            if(ViewState["Gender"]!=null)
                GenderList.SelectedIndex = (int)ViewState["Gender"];
            if(ViewState["Email"]!=null)
              TxtBox_Email.Text =ViewState["Email"].ToString();
        
        }

        private void setViewState()
        {
           
            ViewState.Add("FirstName", TxtBox_First.Text);
            ViewState.Add("LastName", TxtBox_Last.Text);
            ViewState.Add("Gender", GenderList.SelectedIndex);
            ViewState.Add("Email", TxtBox_Email.Text);
        }

        private OpenIDUserResponseState RespondToClaim(OpenIDUserResponseState response)
        {

            // also need to check user name avali.. maybe javascript
            response.GrabbaRideLoginName = NewUserNameText.Text;

            if (response.Profile == null)
                response.Profile = new ClaimsResponse(); // yes i know this throws a warning, but 
            // if i create a request and then a response it throws a null hissy 
           
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
            return getResponse().AllRequiredFeilds();

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
