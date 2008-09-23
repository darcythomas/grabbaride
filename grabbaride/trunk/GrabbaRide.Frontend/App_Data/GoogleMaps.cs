using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using GrabbaRide.Frontend.Properties;

namespace GrabbaRide.Frontend
{
    public static class GoogleMaps
    {
        /// <summary>
        /// Checks the page in the currentPage attribute to see whether the google maps scripts
        /// have been registered. If not, they are registered.
        /// </summary>
        /// <param name="currentPage"></param>
        public static void LoadGoogleMapsScripts(Page currentPage)
        {
            // check for the google maps api script
            if (!currentPage.ClientScript.IsClientScriptIncludeRegistered("googleMapsApi"))
            {
                if (currentPage.Request.Url.Host == "localhost")
                {
                    currentPage.ClientScript.RegisterClientScriptInclude("googleMapsApi",
                        Settings.Default.GoogleMapsLocalhost);
                }
                else
                {
                    currentPage.ClientScript.RegisterClientScriptInclude("googleMapsApi",
                        Settings.Default.GoogleMapsSeatProjects1);
                }
            }

            // check for our google maps script
            if (!currentPage.ClientScript.IsClientScriptIncludeRegistered("googleMapsJs"))
            {
                currentPage.ClientScript.RegisterClientScriptInclude("googleMapsJs",
                    currentPage.ResolveUrl("GoogleMaps.js"));
            }
        }
    }
}
