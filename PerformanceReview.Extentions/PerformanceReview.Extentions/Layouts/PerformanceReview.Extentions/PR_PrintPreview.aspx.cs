using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PerformanceReview.Extentions.Layouts.PerformanceReview.Extentions
{
    /// <summary>
    /// Application Page for Print Preview
    /// </summary>
    public partial class PR_PrintPreview : LayoutsPageBase
    {
        /// <summary>
        /// Internal Array if IDs 
        /// </summary>
        private List<int> _idsquerystring = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadIDs();
            if (_idsquerystring.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<div>");
                foreach (int _id in _idsquerystring)
                {
                    sb.Append(_id.ToString());
                    sb.Append(",");
                }
                sb.Append("</div>");

                lblContent.Text = sb.ToString();
            }
            getHtmlForID(1);
        }

        protected string getHtmlForID(int _id)
        {

            string html = string.Empty;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                string url = "http://win-1ov1vug358q:2222/Lists/CSLetterTemplate/CompensationLTDisplayForm.aspx?ID=25&CompID=10&PrintPreview=true";
                WebBrowser wb = new WebBrowser();
                wb.ScrollBarsEnabled = false;
                wb.ScriptErrorsSuppressed = true;
                wb.Navigate(url);
                while (wb.ReadyState != WebBrowserReadyState.Complete) { }
                wb.Document.DomDocument.ToString();


                WebRequest req = WebRequest.Create("http://win-1ov1vug358q:2222/Lists/CSLetterTemplate/CompensationLTDisplayForm.aspx?ID=25&CompID=10&PrintPreview=true");
            
                //SPContext.Current.Web.CurrentUser.
                //req.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                //req.Credentials = System.Net.CredentialCache.DefaultCredentials;
                req.UseDefaultCredentials = true;

                WebResponse res = req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream());
                html = sr.ReadToEnd();
            });

            return html;

        }

        /// <summary>
        /// Getting IDs from the query string
        /// </summary>
        protected void LoadIDs()
        {
            string IDString = Request.QueryString["IDS"];
            string [] IDs = IDString.Split(',');
            foreach (string id in IDs)
            {
                int num = 0;
                try 
                {
                    num = int.Parse(id);
                }
                catch(Exception ex)
                {
                
                }
                if (num != 0)
                {
                    _idsquerystring.Add(num);
                }
            }
        }

    }
}
