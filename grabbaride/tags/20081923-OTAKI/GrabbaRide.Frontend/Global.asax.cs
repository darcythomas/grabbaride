using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using GrabbaRide.Database;

namespace GrabbaRide.Frontend
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Contains rules that define how we rewrite urls to make nice-looking addresses.
        /// </summary>
        private static readonly Dictionary<string, string> UrlRewriteRules =
            new Dictionary<string, string>() {
                // pattern: { regular expression, replacement string }
                { "^/user/([^/]+)/?$", "/User.aspx?id={1}" },
            };

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // perform url rewriting
            RewriteUrls();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        private void RewriteUrls()
        {
            // get the current requested url
            string requestPath = Request.Url.PathAndQuery;

            // perform regex matching based on our rules
            foreach (KeyValuePair<string, string> kvp in UrlRewriteRules)
            {
                Match match = Regex.Match(requestPath, kvp.Key, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    // convert the groups matched in the regex to an array
                    Group[] groups = new Group[match.Groups.Count];
                    match.Groups.CopyTo(groups, 0);

                    // format the new url and redirect
                    string newPath = String.Format(kvp.Value, groups);
                    Context.RewritePath(newPath);

                    // only match the first rule we find
                    break;
                }
            }
        }
    }
}