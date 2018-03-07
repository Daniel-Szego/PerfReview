using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using PerformanceReview;
using PerformanceReview.BL;
using PerformanceReview.Common;
using PerformanceReview.DL;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.IO;
using OfficeOpenXml;
using System.Drawing;

namespace PerformanceReview.VisualWebparts.PerformanceReview
{
    [ToolboxItemAttribute(false)]
    public partial class PerformanceReview : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public PerformanceReview()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                lblMsg.Visible = false;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string CreateLog = Constants.CreateLog;
                string CloseLog = Constants.CloseLog;
                PerformanceReview.BL.ReadingExcel objreadexcel = new PerformanceReview.BL.ReadingExcel();

                if (!fileupload.HasFile)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = Constants.ValidExcel;
                }
                else
                {
                    //string FileName = System.IO.Path.GetFileName(fileupload.PostedFile.FileName);
                    string FilePath = System.IO.Path.GetFullPath(fileupload.PostedFile.FileName);
                    FileUpload objfileupload = fileupload;
                    string ExistColumn = objreadexcel.PerfReviewColumnValidation(objfileupload);
                    if (ExistColumn == "")
                    {
                        try
                        {
                            UploadExcelToSPList objupload = objreadexcel.UploadExcelFileToSPPerformanceReviewList(objfileupload);                            
                            objreadexcel.CloseLog(objupload, CloseLog);

                            if (objupload.User != null)
                            {
                                // lblMsg.Text = objupload.User;
                                lblMsg.Text = "The User " + objupload.User.Remove(objupload.User.Length - 2) + " not available in Active Directory";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                lblMsg.ForeColor = System.Drawing.Color.Green;
                                lblMsg.Text = Constants.success;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorLog objerror = new ErrorLog();
                            objerror.WriteExceptionLog(ex.Message, "Performamnce Review-btnUpload_Click");
                        }
                    }
                    else
                    {
                        lblMsg.Text = "The Excel file doesn't Contain " + ExistColumn;
                        lblMsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "Performamnce Review-btnUpload_Click");
            }


        }
        protected void UpdateGroups()
        {

        }
    }
}
