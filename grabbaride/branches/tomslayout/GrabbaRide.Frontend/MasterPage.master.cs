using System;
using System.Web.UI;
using GrabbaRide.Database;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // use full domain name for massey server (so that google key works)
            if (Request.Url.Host == "seat-projects1")
            {
                Response.Redirect("http://seat-projects1.massey.ac.nz/carpoolgp2/");
            }

            // update user last seen date
            if (Request.IsAuthenticated)
            {
                GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
                dataContext.UpdateLastActivityByUsername(Page.User.Identity.Name);
            }

            FooterDateLabel.Text = DateTime.Now.ToString("d MMM, h:mm tt");
        }
    }
}
