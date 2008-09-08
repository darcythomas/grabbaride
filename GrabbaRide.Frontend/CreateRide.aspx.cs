using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace GrabbaRide.Frontend
{
    public partial class CreateRide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("Login.aspx?RedirectUrl=CreateRide.aspx");
            }
            else
            {
                
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            String fromloc = hfstart.Value;
            String toloc = hfend.Value;
            String[] loctemp;
            System.Collections.Specialized.ListDictionary listDictionary = new System.Collections.Specialized.ListDictionary();
            listDictionary.Add("CreationDate", DateTime.Now);
            listDictionary.Add("StartDate", calstart.SelectedDate);
            listDictionary.Add("EndDate", calEnd.SelectedDate);
            listDictionary.Add("NumSeats", drpSeats.SelectedValue);
            listDictionary.Add("RecurMon", chkmon.Checked);
            listDictionary.Add("RecurTue", chktue.Checked);
            listDictionary.Add("RecurWed", chkwed.Checked);
            listDictionary.Add("RecurThu", chkthurs.Checked);
            listDictionary.Add("RecurFri", chkfri.Checked);
            listDictionary.Add("RecurSat", chksat.Checked);
            listDictionary.Add("RecurSun", chksun.Checked);
            loctemp = fromloc.Split(',');
            listDictionary.Add("LocationFromLat", loctemp[0]);
            listDictionary.Add("LocationFromLong", loctemp[1]);
            loctemp = toloc.Split(',');
            listDictionary.Add("LocationToLat", loctemp[0]);
            listDictionary.Add("LocationToLong", loctemp[1]);
            listDictionary.Add("UserID", 1);
            listDictionary.Add("Available", true);

            CreateRideSource.Select = "";
            CreateRideSource.Insert(listDictionary);

        }
    }
}
