using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace PerformanceReview.BL
{
    public class ErrorLog
    {
        public void WriteExceptionLog(string ExceptionName, string EventName)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Web.Url))
                {
                    oSite.AllowUnsafeUpdates = true;
                    using (SPWeb oWeb = oSite.OpenWeb())
                    {
                        oWeb.AllowUnsafeUpdates = true;
                        SPList oList = oWeb.Lists["ErrorLog"];
                        SPListItem oSPListItem = oList.Items.Add();
                        oSPListItem["Title"] = Convert.ToString(EventName);
                        oSPListItem["Exception"] = Convert.ToString(ExceptionName);
                        oSPListItem.Update();
                        oWeb.AllowUnsafeUpdates = false;
                    }
                    oSite.AllowUnsafeUpdates = false;
                }
            });
        }
    }
}
