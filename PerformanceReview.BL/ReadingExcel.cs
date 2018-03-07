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
using Microsoft.SharePoint.Publishing.Internal;
using Microsoft.SharePoint.Utilities;
using System.IO;
using OfficeOpenXml;
using System.Collections.Generic;
using Microsoft.Office.Server.UserProfiles;
using System.DirectoryServices.AccountManagement;
using Microsoft.SharePoint.WebControls;
using System.Text;




namespace PerformanceReview.BL
{
    public class ReadingExcel
    {
        #region[Method]


        #region[Data Cleaning]
        /// <summary>
        /// Maps the SharePoint List column with Columns in Excel File.
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> GetColumnMappingDataCleaning()
        {
            Dictionary<int, string> map = new Dictionary<int, string>();
            map.Add(1, "Ctry"); // First parameter is the column Index in Excel Sheet and Second Param is SharePoint List's  Column Name (Display Name )
            map.Add(2, "PersAreaName");
            map.Add(3, "LecName");
            map.Add(4, "SbuName");
            map.Add(5, "PersNumber");
            map.Add(6, "LastName");
            map.Add(7, "FirstName");
            map.Add(8, "BFGuid");
            map.Add(9, "BFGuide");
            map.Add(10, "BFEmail");

            return map;
        }


        /// <summary>
        /// Uploads the excel file to share point list.
        /// </summary>
        public UploadExcelToSPList UploadExcelFileToSPDataCleaningList(FileUpload fileupload)
        {
            UploadExcelToSPList objupload = new UploadExcelToSPList();
            //int count = 0;            
            try
            {
                string Url = SPContext.Current.Web.Url;
                using (SPSite spSite = new SPSite(Url))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        spWeb.AllowUnsafeUpdates = true;
                        SPList list = spWeb.Lists[Constants.ListDataCleaning];
                        try
                        {
                            byte[] fileData = fileupload.FileBytes;
                            using (MemoryStream memStream = new MemoryStream(fileData))
                            {
                                memStream.Flush();
                                using (ExcelPackage pck = new ExcelPackage(memStream))
                                {
                                    if (pck != null)
                                    {
                                        objupload = CreateDataCleaningListItem(pck, list);
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            ErrorLog objerror = new ErrorLog();
                            objerror.WriteExceptionLog(ex.Message, "ReadingExcel.cs-FN UploadExcelFileToSPDataCleaningList");
                        }
                        spWeb.AllowUnsafeUpdates = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "ReadingExcel.cs-FN UploadExcelFileToSPDataCleaningList");
            }
            return objupload;
        }
        
        public string DataCleaningColumnValidation(FileUpload fileupload)
        {
            string ColumExist = string.Empty;
            try
            {
                string Url = SPContext.Current.Web.Url;
                using (SPSite spSite = new SPSite(Url))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        spWeb.AllowUnsafeUpdates = true;
                        SPList list = spWeb.Lists[Constants.ListDataCleaning];
                        try
                        {
                            byte[] fileData = fileupload.FileBytes;
                            using (MemoryStream memStream = new MemoryStream(fileData))
                            {
                                memStream.Flush();
                                using (ExcelPackage pck = new ExcelPackage(memStream))
                                {
                                    if (pck != null)
                                    {
                                        ColumExist = DataCleaningExcelColumnValidation(pck);
                                    }
                                }
                            }

                            // ltrlMsg.Text = "Data successfully Uploaded...";
                        }
                        catch (Exception ex)
                        {
                            ErrorLog objerror = new ErrorLog();
                            objerror.WriteExceptionLog(ex.Message, "ReadingExcel-DataCleaningColumnValidation");
                        }
                        spWeb.AllowUnsafeUpdates = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "ReadingExcel-DataCleaningColumnValidation");
            }
            return ColumExist;
        }
        public string PerfReviewColumnValidation(FileUpload fileupload)
        {
            string ColumExist = string.Empty;
            try
            {
                string Url = SPContext.Current.Web.Url;
                using (SPSite spSite = new SPSite(Url))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        spWeb.AllowUnsafeUpdates = true;
                        SPList list = spWeb.Lists[Constants.ListDataCleaning];
                        try
                        {
                            byte[] fileData = fileupload.FileBytes;
                            using (MemoryStream memStream = new MemoryStream(fileData))
                            {
                                memStream.Flush();
                                using (ExcelPackage pck = new ExcelPackage(memStream))
                                {
                                    if (pck != null)
                                    {
                                        ColumExist = PerformanceReviewExcelColumnValidation(pck);
                                    }
                                }
                            }

                            // ltrlMsg.Text = "Data successfully Uploaded...";
                        }
                        catch (Exception ex)
                        {
                            ErrorLog objerror = new ErrorLog();
                            objerror.WriteExceptionLog(ex.Message, "ReadingExcel-PerfReviewColumnValidation");
                        }
                        spWeb.AllowUnsafeUpdates = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "ReadingExcel-PerfReviewColumnValidation");
            }
            return ColumExist;

        }
        public string LetterColumnValidation(FileUpload fileupload)
        {
            string ColumExist = string.Empty;
            try
            {
                string Url = SPContext.Current.Web.Url;
                using (SPSite spSite = new SPSite(Url))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        spWeb.AllowUnsafeUpdates = true;
                        SPList list = spWeb.Lists[Constants.ListDataCleaning];
                        try
                        {
                            byte[] fileData = fileupload.FileBytes;
                            using (MemoryStream memStream = new MemoryStream(fileData))
                            {
                                memStream.Flush();
                                using (ExcelPackage pck = new ExcelPackage(memStream))
                                {
                                    if (pck != null)
                                    {
                                        ColumExist = LetterExcelColumnValidation(pck);
                                    }
                                }
                            }

                            // ltrlMsg.Text = "Data successfully Uploaded...";
                        }
                        catch (Exception ex)
                        {
                            ErrorLog objerror = new ErrorLog();
                            objerror.WriteExceptionLog(ex.Message, "ReadingExcel-LetterColumnValidation");
                        }
                        spWeb.AllowUnsafeUpdates = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "ReadingExcel-LetterColumnValidation");
            }
            return ColumExist;
        }
       
      

        /// <summary>
        /// Creates the list item.
        /// </summary>
        /// <param name="pck">The PCK.</param>
        /// <param name="list">The list.</param>
        public UploadExcelToSPList CreateDataCleaningListItem(ExcelPackage pck, SPList list)
        {            
            try
            {
                UploadExcelToSPList objupload = new UploadExcelToSPList();
                Dictionary<int, string> column = GetColumnMappingDataCleaning();
                ExcelWorksheet ws = pck.Workbook.Worksheets[1];
                int rowCount = ws.Dimension.End.Row + 1;
                int colCount = ws.Dimension.End.Column + 1;
                objupload.UnProcessedCount = 0;
                

                StringBuilder processquery = new StringBuilder();
                processquery.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?><Batch>");
                    for (int i = 2; i < rowCount; i++) // Row index starts from 2, as the first row is Title
                    {
                        //DoWork(colCount, ws, i, list, objupload);
                      // ReadingExcel.DoWork(colCount, ws, i, list, objupload);
                       objupload = DatacleaningProcessCol(colCount, ws, i, list, objupload);
                        
                        processquery.Append(Convert.ToString(objupload.processbatch));                        
                        i = objupload.rowCount;
                    }
                    processquery.Append("</Batch>");
                    SPContext.Current.Web.ProcessBatchData(processquery.ToString());
                         
                    objupload.ProcessedCount = Convert.ToString((rowCount - objupload.UnProcessedCount) - 2);
                    return objupload;
                    //return rowCount - 2;            
              
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UploadExcelToSPList DatacleaningProcessCol(int colCount, ExcelWorksheet ws, int i, SPList list, UploadExcelToSPList objupload)
        {
            //SPWeb web = SPContext.Current.Web;
            try
            {
                StringBuilder methodFormat = new StringBuilder();
                object Ctry = null;
                object PersAreaName = null;
                object LecName = null;
                object SbuName = null;
                object PersNumber = null;
                object LastName = null;
                object FirstName = null;
                object BFGuid = null;
                object BFGuide = null;
                object BFEmail = null;
                objupload.rowCount = i;
                for (int j = 1; j < colCount; j++)
                {
                    switch (j)
                    {
                        case 1:
                            Ctry = ws.Cells[i, j].Value;
                            break;
                        case 2:
                            PersAreaName = ws.Cells[i, j].Value;
                            break;
                        case 3:
                            LecName = ws.Cells[i, j].Value;
                            break;
                        case 4:
                            SbuName = ws.Cells[i, j].Value;
                            break;
                        case 5:
                            PersNumber = ws.Cells[i, j].Value;
                            break;
                        case 6:
                            LastName = ws.Cells[i, j].Value;
                            break;
                        case 7:
                            FirstName = ws.Cells[i, j].Value;
                            break;
                        case 8:
                            BFGuid = ws.Cells[i, j].Value;
                            break;
                        case 9:
                            BFGuide = ws.Cells[i, j].Value;
                            break;
                        case 10:
                            BFEmail = ws.Cells[i, j].Value;
                            break;
                        default: break;
                    }
                    //}
                }
                if (PersNumber != null)
                {
                    string listGuid = list.ID.ToString();
                    SPQuery query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='PersNumber' /><Value Type='Text'>" + Convert.ToString(PersNumber) + "</Value></Eq></Where>";
                    SPListItemCollection listcollection = list.GetItems(query);
                    if (listcollection.Count > 0)
                    {
                        foreach (SPListItem items in listcollection)
                        {
                            methodFormat.Append("<Method ID=\"" + i + "\">" +
                                                "<SetList>" + listGuid + "</SetList>" +
                                                "<SetVar Name=\"Cmd\">Save</SetVar>" +
                                                "<SetVar Name=\"ID\">" + items.ID + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Ctry\">" + Ctry + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#PersAreaName\">" + PersAreaName + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#LecName\">" + LecName + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SbuName\">" + SbuName + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#PersNumber\">" + PersNumber + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#LastName\">" + LastName + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuid\">" + BFGuid + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide\">" + BFGuide + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFEmail\">" + BFEmail + "</SetVar>");                                             
                                                
                            

                            //items["Ctry"] = Ctry;
                            //items["PersAreaName"] = PersAreaName;
                            //items["LecName"] = LecName;
                            //items["SbuName"] = SbuName;
                            //items["PersNumber"] = PersNumber;
                            //items["LastName"] = LastName;
                            //items["FirstName"] = FirstName;
                            //items["BFGuid"] = BFGuid;
                            //items["BFGuide"] = BFGuide;
                            //items["BFEmail"] = BFEmail;

                            try
                            {
                                //SPUser Level1user = null;
                                if (!string.IsNullOrEmpty(Convert.ToString(BFEmail)))
                                {
                                    ClientPeoplePicker peoplecontrol = new ClientPeoplePicker();
                                    PeopleEditor ppleditor = new PeopleEditor();
                                    PickerEntity entity = new PickerEntity();
                                    entity.Key = Convert.ToString(BFEmail);
                                    entity = ppleditor.ValidateEntity(entity);
                                    entity.IsResolved = true;
                                    peoplecontrol.AddEntities(new List<PickerEntity> { entity });
                                    ArrayList EntitiesList = peoplecontrol.ResolvedEntities;
                                    foreach (PickerEntity entitys in EntitiesList)
                                    {
                                        SPUser user = SPContext.Current.Web.EnsureUser(entitys.Key);
                                        string uservalue = user.ID + ";#" + user.Name;
                                        //items["Supervisor"] = user;
                                        //items["Supervisor_CN"] = user;
                                        //items["BFGuide_CN"] = user;
                                        //items.Update();
                                        methodFormat.Append("<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor\">" + uservalue + "</SetVar>" +
                                            "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor_CN\">" + uservalue + "</SetVar>" +
                                            "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide_CN\">" + uservalue + "</SetVar>");
                                    }
                                }

                            }
                            catch (Exception)
                            {
                                try
                                {
                                    SPUser Level1user = null;
                                    Level1user = SPContext.Current.Web.EnsureUser(Convert.ToString(BFGuide));
                                    string luservalue = Level1user.ID + ";#" + Level1user.Name;
                                    //items["Supervisor"] = Level1user;
                                    //items["Supervisor_CN"] = Level1user;
                                    //items["BFGuide_CN"] = Level1user;
                                    //items.Update();
                                    methodFormat.Append("<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor\">" + luservalue + "</SetVar>" +
                                            "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor_CN\">" + luservalue + "</SetVar>" +
                                            "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide_CN\">" + luservalue + "</SetVar>");
                                }
                                catch (Exception)
                                {
                                    i = i + 1;
                                    objupload.rowCount = i;
                                    objupload.User = objupload.User + Convert.ToString(BFGuide) + ", ";
                                    objupload.UnProcessedCount = objupload.UnProcessedCount + 1;
                                    objupload = DatacleaningProcessCol(colCount, ws, i, list, objupload);
                                    return objupload;
                                }

                            }                            
                        }
                    }
                    else
                    {
                        //SPListItem items = list.AddItem();
                        //items["Ctry"] = Ctry;
                        //items["PersAreaName"] = PersAreaName;
                        //items["LecName"] = LecName;
                        //items["SbuName"] = SbuName;
                        //items["PersNumber"] = PersNumber;
                        //items["LastName"] = LastName;
                        //items["FirstName"] = FirstName;
                        //items["BFGuid"] = BFGuid;
                        //items["BFGuide"] = BFGuide;
                        //items["BFEmail"] = BFEmail;
                        methodFormat.Append("<Method ID=\"" + i + "\">" +
                                                "<SetList>" + listGuid + "</SetList>" +
                                                "<SetVar Name=\"Cmd\">Save</SetVar>" +
                                                "<SetVar Name=\"ID\">New</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Ctry\">" + Ctry + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#PersAreaName\">" + PersAreaName + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#LecName\">" + LecName + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SbuName\">" + SbuName + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#PersNumber\">" + PersNumber + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#LastName\">" + LastName + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuid\">" + BFGuid + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide\">" + BFGuide + "</SetVar>" +
                                                "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFEmail\">" + BFEmail + "</SetVar>"); 
                        //Updating Additional People/Groups fields
                        try
                        {
                            //SPUser Level1user = null;
                            if (!string.IsNullOrEmpty(Convert.ToString(BFEmail)))
                            {
                                ClientPeoplePicker peoplecontrol = new ClientPeoplePicker();
                                PeopleEditor ppleditor = new PeopleEditor();
                                PickerEntity entity = new PickerEntity();
                                entity.Key = Convert.ToString(BFEmail);
                                entity = ppleditor.ValidateEntity(entity);
                                entity.IsResolved = true;
                                peoplecontrol.AddEntities(new List<PickerEntity> { entity });
                                ArrayList EntitiesList = peoplecontrol.ResolvedEntities;
                                foreach (PickerEntity entitys in EntitiesList)
                                {
                                    SPUser user = SPContext.Current.Web.EnsureUser(entitys.Key);
                                   
                                    //items["Supervisor"] = user;
                                    //items["Supervisor_CN"] = user;
                                    //items["BFGuide_CN"] = user;
                                    //items.Update();
                                    string uservalue = user.ID + ";#" + user.Name;                                    
                                    methodFormat.Append("<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor\">" + uservalue + "</SetVar>" +
                                        "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor_CN\">" + uservalue + "</SetVar>" +
                                        "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide_CN\">" + uservalue + "</SetVar>");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            try
                            {

                                SPUser Level1user = null;
                                Level1user = SPContext.Current.Web.EnsureUser(Convert.ToString(BFGuide));
                                //items["Supervisor"] = Level1user;
                                //items["Supervisor_CN"] = Level1user;
                                //items["BFGuide_CN"] = Level1user;
                                //items.Update();
                                string uservalue = Level1user.ID + ";#" + Level1user.Name;
                                methodFormat.Append("<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor\">" + uservalue + "</SetVar>" +
                                    "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor_CN\">" + uservalue + "</SetVar>" +
                                    "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide_CN\">" + uservalue + "</SetVar>");
                            }
                            catch (Exception)
                            {
                                i = i + 1;
                                objupload.rowCount = i;
                                objupload.User = objupload.User + Convert.ToString(BFGuide) + ", ";
                                objupload.UnProcessedCount = objupload.UnProcessedCount + 1;
                                objupload = DatacleaningProcessCol(colCount, ws, i, list, objupload);
                                return objupload;
                            }
                        }
                    }
                }
                methodFormat.Append("</Method>");
                objupload.processbatch = new StringBuilder();
                objupload.processbatch.Append(Convert.ToString(methodFormat));
                return objupload;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public string DataCleaningExcelColumnValidation(ExcelPackage pck)
        {
            try
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets[1];
                int rowCount = ws.Dimension.End.Row + 1;
                int colCount = ws.Dimension.End.Column + 1;
                string NotColExist = string.Empty;
                object Ctry = null;
                object PersAreaName = null;
                object LecName = null;
                object SbuName = null;
                object PersNumber = null;
                object LastName = null;
                object FirstName = null;
                object BFGuid = null;
                object BFGuide = null;
                object BFEmail = null;

                for (int i = 1; i <= 1; i++) // Row index starts from 2, as the first row is Title
                {
                    for (int j = 1; j < colCount; j++)
                    {
                        switch (j)
                        {
                            case 1:
                                Ctry = ws.Cells[i, j].Value;
                                if (Convert.ToString(Ctry).Trim() != "Country")
                                {
                                    NotColExist = NotColExist + " Country,";
                                }
                                break;
                            case 2:
                                PersAreaName = ws.Cells[i, j].Value;
                                if (Convert.ToString(PersAreaName).Trim() != "Pers.Area")
                                {
                                    NotColExist = NotColExist + " Pers.Area,";
                                }
                                break;
                            case 3:
                                LecName = ws.Cells[i, j].Value;
                                if (Convert.ToString(LecName).Trim() != "Lec.Name")
                                {
                                    NotColExist = NotColExist + " Lec.Name,";
                                }
                                break;
                            case 4:
                                SbuName = ws.Cells[i, j].Value;
                                if (Convert.ToString(SbuName).Trim() != "SBU")
                                {
                                    NotColExist = NotColExist + " SBU,";
                                }
                                break;
                            case 5:
                                PersNumber = ws.Cells[i, j].Value;
                                if (Convert.ToString(PersNumber).Trim() != "SAP Number")
                                {
                                    NotColExist = NotColExist + " SAP Number,";
                                }
                                break;
                            case 6:
                                LastName = ws.Cells[i, j].Value;
                                if (Convert.ToString(LastName).Trim() != "Last Name")
                                {
                                    NotColExist = NotColExist + " Last Name,";
                                }
                                break;
                            case 7:
                                FirstName = ws.Cells[i, j].Value;
                                if (Convert.ToString(FirstName).Trim() != "First Name")
                                {
                                    NotColExist = NotColExist + " First Name,";
                                }
                                break;
                            case 8:
                                BFGuid = ws.Cells[i, j].Value;
                                if (Convert.ToString(BFGuid).Trim() != "SAP# Bus.Fun Supervisor")
                                {
                                    NotColExist = NotColExist + " SAP# Bus.Fun Supervisor,";
                                }
                                break;
                            case 9:
                                BFGuide = ws.Cells[i, j].Value;
                                if (Convert.ToString(BFGuide).Trim() != "Name Bus.Func Supervisor")
                                {
                                    NotColExist = NotColExist + " Name Bus.Func Supervisor,";
                                }
                                break;
                            case 10:
                                BFEmail = ws.Cells[i, j].Value;
                                if (Convert.ToString(BFEmail).Trim() != "Email Bus.Fun Supervisor")
                                {
                                    NotColExist = NotColExist + " Email Bus.Fun Supervisor,";
                                }
                                break;
                            default: break;
                        }
                        //}
                    }
                }
                if (NotColExist != "")
                {
                    return NotColExist.Remove(NotColExist.Length - 1);
                }
                else
                {
                    return NotColExist;
                }
            }
            catch (Exception)
            {
                throw;
            }


        }

        public string LetterExcelColumnValidation(ExcelPackage pck)
        {
            try
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets[1];
                int rowCount = ws.Dimension.End.Row + 1;
                int colCount = ws.Dimension.End.Column + 1;
                string NotColExist = string.Empty;

                object NotesType = null;
                object Language = null;
                object StatementDate = null;
                object FirstName = null;
                object LastName = null;
                object BU_Function = null;
                object Location = null;
                object ManagerName = null;
                object ManagerEmail = null;
                object PerformanceCategory = null;
                object AnnualSalary = null;
                object MonthlySalary = null;
                object ChangePercent = null;
                object ChangeAmount = null;
                object NewMonthlySalary = null;
                object NewAnnualSalary = null;
                object RTG = null;
                object EffectiveDate = null;
                object STIPTarget = null;
                object ProrationFactor = null;
                object CorporateFactor = null;
                object IBF = null;

                for (int i = 1; i <= 1; i++) // Row index starts from 2, as the first row is Title
                {
                    for (int j = 1; j < colCount; j++)
                    {
                        switch (j)
                        {
                            case 1:
                                NotesType = ws.Cells[i, j].Value;
                                if (Convert.ToString(NotesType).Trim() != "Type")
                                {
                                    NotColExist = NotColExist + " Type,";
                                }
                                break;
                            case 2:
                                Language = ws.Cells[i, j].Value;
                                if (Convert.ToString(Language).Trim() != "Language")
                                {
                                    NotColExist = NotColExist + " Language,";
                                }
                                break;
                            case 3:
                                StatementDate = ws.Cells[i, j].Value;
                                if (Convert.ToString(StatementDate).Trim() != "Statement Date")
                                {
                                    NotColExist = NotColExist + " Statement Date,";
                                }
                                break;
                            case 4:
                                FirstName = ws.Cells[i, j].Value;
                                if (Convert.ToString(FirstName).Trim() != "First Name")
                                {
                                    NotColExist = NotColExist + " First Name,";
                                }
                                break;
                            case 5:
                                LastName = ws.Cells[i, j].Value;
                                if (Convert.ToString(LastName).Trim() != "Last Name")
                                {
                                    NotColExist = NotColExist + " Last Name,";
                                }
                                break;
                            case 6:
                                BU_Function = ws.Cells[i, j].Value;
                                if (Convert.ToString(BU_Function).Trim() != "BU_Function")
                                {
                                    NotColExist = NotColExist + " BU_Function,";
                                }
                                break;
                            case 7:
                                Location = ws.Cells[i, j].Value;
                                if (Convert.ToString(Location).Trim() != "Location")
                                {
                                    NotColExist = NotColExist + " Location,";
                                }
                                break;
                            case 8:
                                ManagerName = ws.Cells[i, j].Value;
                                if (Convert.ToString(ManagerName).Trim() != "Manger Name")
                                {
                                    NotColExist = NotColExist + " Manger Name,";
                                }
                                break;
                            case 9:
                                ManagerEmail = ws.Cells[i, j].Value;
                                if (Convert.ToString(ManagerEmail).Trim() != "Manager Email")
                                {
                                    NotColExist = NotColExist + " Manager Email,";
                                }
                                break;
                            case 10:
                                PerformanceCategory = ws.Cells[i, j].Value;
                                if (Convert.ToString(PerformanceCategory).Trim() != "Performance Category")
                                {
                                    NotColExist = NotColExist + " Performance Category,";
                                }
                                break;

                            case 11:
                                AnnualSalary = ws.Cells[i, j].Value;
                                if (Convert.ToString(AnnualSalary).Trim() != "Merit -> Annual Salary")
                                {
                                    NotColExist = NotColExist + " Merit -> Annual Salary,";
                                }
                                break;
                            case 12:
                                MonthlySalary = ws.Cells[i, j].Value;
                                if (Convert.ToString(MonthlySalary).Trim() != "Merit -> Current Monthly Base Pay/Salary:")
                                {
                                    NotColExist = NotColExist + " Merit -> Current Monthly Base Pay/Salary:,";
                                }
                                break;
                            case 13:
                                ChangePercent = ws.Cells[i, j].Value;
                                if (Convert.ToString(ChangePercent).Trim() != "Merit -> Increase Percentage:")
                                {
                                    NotColExist = NotColExist + " Merit -> Increase Percentage:,";
                                }
                                break;
                            case 14:
                                ChangeAmount = ws.Cells[i, j].Value;
                                if (Convert.ToString(ChangeAmount).Trim() != "Merit ->Monthly Increase:")
                                {
                                    NotColExist = NotColExist + " Merit ->Monthly Increase:,";
                                }
                                break;
                            case 15:
                                NewMonthlySalary = ws.Cells[i, j].Value;
                                if (Convert.ToString(NewMonthlySalary).Trim() != "Merit -> New Monthly Base Pay/Salary:")
                                {
                                    NotColExist = NotColExist + " Merit -> New Monthly Base Pay/Salary:,";
                                }
                                break;
                            case 16:
                                NewAnnualSalary = ws.Cells[i, j].Value;
                                if (Convert.ToString(NewAnnualSalary).Trim() != "Merit -> New Annual Salary")
                                {
                                    NotColExist = NotColExist + " Merit -> New Annual Salary,";
                                }
                                break;
                            case 17:
                                RTG = ws.Cells[i, j].Value;
                                if (Convert.ToString(RTG).Trim() != "Merit -> RTG")
                                {
                                    NotColExist = NotColExist + " Merit -> RTG,";
                                }
                                break;
                            case 18:
                                EffectiveDate = ws.Cells[i, j].Value;
                                if (Convert.ToString(EffectiveDate).Trim() != "Merit -> Effective Date")
                                {
                                    NotColExist = NotColExist + " Merit -> Effective Date,";
                                }
                                break;
                            case 19:
                                STIPTarget = ws.Cells[i, j].Value;
                                if (Convert.ToString(STIPTarget).Trim() != "2013 BONUS-> 2013 Bonus Target Award:")
                                {
                                    NotColExist = NotColExist + " 2013 BONUS-> 2013 Bonus Target Award:,";
                                }
                                break;
                            case 20:
                                ProrationFactor = ws.Cells[i, j].Value;
                                if (Convert.ToString(ProrationFactor).Trim() != "2013 A A BONUS->Business Factor:")
                                {
                                    NotColExist = NotColExist + " 2013 A A BONUS->Business Factor:,";
                                }
                                break;

                            case 21:
                                CorporateFactor = ws.Cells[i, j].Value;
                                if (Convert.ToString(CorporateFactor).Trim() != "2013 A A BONUS->Individual Performance Assessment (IPA):")
                                {
                                    NotColExist = NotColExist + "  2013 A A BONUS->Individual Performance Assessment (IPA):,";
                                }
                                break;
                            case 22:
                                IBF = ws.Cells[i, j].Value;
                                if (Convert.ToString(IBF).Trim() != "2013 A A BONUS->2013 Bonus Actual Award:")
                                {
                                    NotColExist = NotColExist + " 2013 A A BONUS->2013 Bonus Actual Award:,";
                                }
                                break;
                            default: break;
                        }
                        //}
                    }
                }
                if (NotColExist != "")
                {
                    return NotColExist.Remove(NotColExist.Length - 1);
                }
                else
                {
                    return NotColExist;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion[Data Cleaning]

        #region[Performance Review]
        /// <summary>
        /// Maps the SharePoint List column with Columns in Excel File.
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> GetColumnMappingPerformanceReview()
        {
            try
            {
                Dictionary<int, string> map = new Dictionary<int, string>();
                map.Add(1, "PersNumber"); // First parameter is the column Index in Excel Sheet and Second Param is SharePoint List's  Column Name (Display Name )
                map.Add(2, "LastName");
                map.Add(3, "FirstName");
                map.Add(4, "Ctry");
                map.Add(5, "SbuName");
                map.Add(6, "OrgUnitName");
                map.Add(7, "PersAreaName");
                map.Add(8, "EmplSubGrpName");
                map.Add(9, "ASDDate");
                map.Add(10, "Leavedate");
                map.Add(11, "PT");
                map.Add(12, "SSGL");
                map.Add(13, "RTG");
                map.Add(14, "Previous_Year_IPF_Name");
                map.Add(15, "Previous. Year IPF");
                map.Add(16, "Previous_Year_PC_Name");
                map.Add(17, "Previous_Year_PC");
                map.Add(18, "Name_PR");
                map.Add(19, "IPA");
                map.Add(20, "SBU_1");
                map.Add(21, "Perc_SBU_1");
                map.Add(22, "SBU_2");
                map.Add(23, "Perc_SBU_2");
                map.Add(24, "SBU_3");
                map.Add(25, "Perc_SBU_3");
                map.Add(26, "BFGuid");
                map.Add(27, "BFGuide");
                map.Add(28, "BFEmail");
                map.Add(29, "comment");
                return map;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Uploads the excel file to share point list.
        /// </summary>
        public UploadExcelToSPList UploadExcelFileToSPPerformanceReviewList(FileUpload fileupload)
        {
            UploadExcelToSPList objupload = new UploadExcelToSPList();
            //int count = 0;
            try
            {
                string Url = SPContext.Current.Web.Url;
                using (SPSite spSite = new SPSite(Url))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        spWeb.AllowUnsafeUpdates = true;
                        SPList list = spWeb.Lists[Constants.ListPerformanceReview];
                        try
                        {
                            byte[] fileData = fileupload.FileBytes;
                            using (MemoryStream memStream = new MemoryStream(fileData))
                            {
                                memStream.Flush();
                                using (ExcelPackage pck = new ExcelPackage(memStream))
                                {
                                    if (pck != null)
                                    {
                                        objupload = CreatePerformanceReviewListItem(pck, list);
                                    }
                                }
                            }

                            // ltrlMsg.Text = "Data successfully Uploaded...";
                        }
                        catch (Exception ex)
                        {
                            ErrorLog objerror = new ErrorLog();
                            objerror.WriteExceptionLog(ex.Message, "Upload Excel file to SP performance review List");
                        }
                        spWeb.AllowUnsafeUpdates = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "Upload Excel file to SP performance review List");
            }
            return objupload;
        }

        public string PerformanceReviewExcelColumnValidation(ExcelPackage pck)
        {
            try
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets[1];
                int rowCount = ws.Dimension.End.Row + 1;
                int colCount = ws.Dimension.End.Column + 1;
                string NotColExist = string.Empty;

                object PersNumber = null;
                object LastName = null;
                object FirstName = null;
                object Ctry = null;
                object SbuName = null;
                object OrgUnitName = null;
                object PersAreaName = null;
                object EmplSubGrpName = null;
                object ASDDate = null;
                object Leavedate = null;
                object PT = null;
                object SSGL = null;
                object RTG = null;
                object PreviousYearIPFName = null;
                object PreviousYearPCName = null;
                object Previous_Year_PC = null;
                object Previous_Year_IPF = null;
                object PR = null;
                object IPA = null;
                object SBU_1 = null;
                object Perc_SBU_1 = null;
                object SBU_2 = null;
                object Perc_SBU_2 = null;
                object SBU_3 = null;
                object Perc_SBU_3 = null;
                object BFGuid = null;
                object BFGuide = null;
                object BFEmail = null;
                object comment = null;

                for (int i = 1; i <= 1; i++) // Row index starts from 2, as the first row is Title
                {
                    for (int j = 1; j < colCount; j++)
                    {
                        switch (j)
                        {
                            case 1:
                                PersNumber = ws.Cells[i, j].Value;
                                if (Convert.ToString(PersNumber).Trim() != "SAP Number")
                                {
                                    NotColExist = NotColExist + " SAP Number,";
                                }
                                break;
                            case 2:
                                LastName = ws.Cells[i, j].Value;
                                if (Convert.ToString(LastName).Trim() != "Last Name")
                                {
                                    NotColExist = NotColExist + " Last Name,";
                                }
                                break;
                            case 3:
                                FirstName = ws.Cells[i, j].Value;
                                if (Convert.ToString(FirstName).Trim() != "First Name")
                                {
                                    NotColExist = NotColExist + " First Name,";
                                }
                                break;
                            case 4:
                                Ctry = ws.Cells[i, j].Value;
                                if (Convert.ToString(Ctry).Trim() != "Country")
                                {
                                    NotColExist = NotColExist + " Country,";
                                }
                                break;
                            case 5:
                                SbuName = ws.Cells[i, j].Value;
                                if (Convert.ToString(SbuName).Trim() != "SBU")
                                {
                                    NotColExist = NotColExist + " SBU,";
                                }
                                break;
                            case 6:
                                OrgUnitName = ws.Cells[i, j].Value;
                                if (Convert.ToString(OrgUnitName).Trim() != "Org. Unit")
                                {
                                    NotColExist = NotColExist + " Org. Unit,";
                                }
                                break;
                            case 7:
                                PersAreaName = ws.Cells[i, j].Value;
                                if (Convert.ToString(PersAreaName).Trim() != "Pers. Area")
                                {
                                    NotColExist = NotColExist + " Pers. Area,";
                                }
                                break;
                            case 8:
                                EmplSubGrpName = ws.Cells[i, j].Value;
                                if (Convert.ToString(EmplSubGrpName).Trim() != "EESubgr")
                                {
                                    NotColExist = NotColExist + " EESubgr,";
                                }
                                break;
                            case 9:
                                ASDDate = ws.Cells[i, j].Value;
                                if (Convert.ToString(ASDDate).Trim() != "Adj. Serv. Date")
                                {
                                    NotColExist = NotColExist + " Adj. Serv. Date,";
                                }
                                break;
                            case 10:
                                Leavedate = ws.Cells[i, j].Value;
                                if (Convert.ToString(Leavedate).Trim() != "Leavers Date")
                                {
                                    NotColExist = NotColExist + " Leavers Date,";
                                }
                                break;

                            case 11:
                                PT = ws.Cells[i, j].Value;
                                if (Convert.ToString(PT).Trim() != "Work Time %")
                                {
                                    NotColExist = NotColExist + " Work Time %,";
                                }
                                break;
                            case 12:
                                SSGL = ws.Cells[i, j].Value;
                                if (Convert.ToString(SSGL).Trim() != "SSGL")
                                {
                                    NotColExist = NotColExist + " SSGL,";
                                }
                                break;
                            case 13:
                                RTG = ws.Cells[i, j].Value;
                                if (Convert.ToString(RTG).Trim() != "RTG")
                                {
                                    NotColExist = NotColExist + " RTG,";
                                }
                                break;
                            case 14:
                                PreviousYearIPFName = ws.Cells[i, j].Value;
                                if (Convert.ToString(PreviousYearIPFName).Trim() != "Previous Year IPF Name")
                                {
                                    NotColExist = NotColExist + " Previous Year IPF Name,";
                                }
                                break;
                            case 15:
                                Previous_Year_IPF = ws.Cells[i, j].Value;
                                if (Convert.ToString(Previous_Year_IPF).Trim() != "Prev. Year IPF")
                                {
                                    NotColExist = NotColExist + " Prev. Year IPF,";
                                }
                                break;
                            case 16:
                                PreviousYearPCName = ws.Cells[i, j].Value;
                                if (Convert.ToString(PreviousYearPCName).Trim() != "Previous Year PC Name")
                                {
                                    NotColExist = NotColExist + " Previous Year PC Name,";
                                }
                                break;
                            case 17:
                                Previous_Year_PC = ws.Cells[i, j].Value;
                                if (Convert.ToString(Previous_Year_PC).Trim() != "Prev. Year PC")
                                {
                                    NotColExist = NotColExist + " Prev. Year PC,";
                                }
                                break;
                            case 18:
                                PR = ws.Cells[i, j].Value;
                                if (Convert.ToString(PR).Trim() != "Name of PR")
                                {
                                    NotColExist = NotColExist + " Name of PR,";
                                }
                                break;
                            case 19:
                                IPA = ws.Cells[i, j].Value;
                                if (Convert.ToString(IPA).Trim() != "Name of IPA")
                                {
                                    NotColExist = NotColExist + " Name of IPA,";
                                }
                                break;
                            case 20:
                                SBU_1 = ws.Cells[i, j].Value;
                                if (Convert.ToString(SBU_1).Trim() != "SBU1")
                                {
                                    NotColExist = NotColExist + " SBU1,";
                                }
                                break;
                            case 21:
                                Perc_SBU_1 = ws.Cells[i, j].Value;
                                if (Convert.ToString(Perc_SBU_1).Trim() != "% SBU1")
                                {
                                    NotColExist = NotColExist + " % SBU1,";
                                }
                                break;
                            case 22:
                                SBU_2 = ws.Cells[i, j].Value;
                                if (Convert.ToString(SBU_2).Trim() != "SBU2")
                                {
                                    NotColExist = NotColExist + " SBU2,";
                                }
                                break;

                            case 23:
                                Perc_SBU_2 = ws.Cells[i, j].Value;
                                if (Convert.ToString(Perc_SBU_2) != "% SBU2")
                                {
                                    NotColExist = NotColExist + " % SBU2,";
                                }
                                break;
                            case 24:
                                SBU_3 = ws.Cells[i, j].Value;
                                if (Convert.ToString(SBU_3).Trim() != "SBU3")
                                {
                                    NotColExist = NotColExist + " SBU3,";
                                }
                                break;
                            case 25:
                                Perc_SBU_3 = ws.Cells[i, j].Value;
                                if (Convert.ToString(Perc_SBU_3).Trim() != "% SBU3")
                                {
                                    NotColExist = NotColExist + " % SBU3,";
                                }
                                break;
                            case 26:
                                BFGuid = ws.Cells[i, j].Value;
                                if (Convert.ToString(BFGuid).Trim() != "SAP #  Bus. Func. Sup.")
                                {
                                    NotColExist = NotColExist + " SAP # Bus. Func. Sup,";
                                }
                                break;
                            case 27:
                                BFGuide = ws.Cells[i, j].Value;
                                if (Convert.ToString(BFGuide).Trim() != "Name Bus. Func. Sup.")
                                {
                                    NotColExist = NotColExist + " Name Bus. Func. Sup.,";
                                }
                                break;
                            case 28:
                                BFEmail = ws.Cells[i, j].Value;
                                if (Convert.ToString(BFEmail).Trim() != "BFEmail")
                                {
                                    NotColExist = NotColExist + " BFEmail,";
                                }
                                break;
                            case 29:
                                comment = ws.Cells[i, j].Value;
                                if (Convert.ToString(comment).Trim() != "Comment")
                                {
                                    NotColExist = NotColExist + " Comment,";
                                }
                                break;
                            default: break;
                        }
                        //}
                    }
                }
                if (NotColExist != "")
                {
                    return NotColExist.Remove(NotColExist.Length - 1);
                }
                else
                {
                    return NotColExist;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates the list item.
        /// </summary>
        /// <param name="pck">The PCK.</param>
        /// <param name="list">The list.</param>
        public UploadExcelToSPList CreatePerformanceReviewListItem(ExcelPackage pck, SPList list)
        {
            UploadExcelToSPList objupload = new UploadExcelToSPList();
            Dictionary<int, string> column = GetColumnMappingPerformanceReview();
            ExcelWorksheet ws = pck.Workbook.Worksheets[1];
            int rowCount = ws.Dimension.End.Row + 1;
            int colCount = ws.Dimension.End.Column + 1;
            objupload.UnProcessedCount = 0;

            StringBuilder processquery = new StringBuilder();
            processquery.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?><Batch>");
            try
            {
                for (int i = 2; i < rowCount; i++) // Row index starts from 2, as the first row is Title
                {

                    objupload = PerformancereviewProcessCol(colCount, ws, i, list, objupload);
                    processquery.Append(Convert.ToString(objupload.processbatch)); 
                    i = objupload.rowCount;

                }                
            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "ReadingExcel-CreatePerformanceReviewListItem");
            }

            processquery.Append("</Batch>");
            SPContext.Current.Web.ProcessBatchData(processquery.ToString());

            objupload.ProcessedCount = Convert.ToString((rowCount - objupload.UnProcessedCount) - 2);
            return objupload;


        }

        public UploadExcelToSPList PerformancereviewProcessCol(int colCount, ExcelWorksheet ws, int i, SPList list, UploadExcelToSPList objupload)
        {
            try
            {
                StringBuilder methodFormat = new StringBuilder();

                object PersNumber = null;
                object LastName = null;
                object FirstName = null;
                object Ctry = null;
                object SbuName = null;
                object OrgUnitName = null;
                object PersAreaName = null;
                object EmplSubGrpName = null;
                object ASDDate = null;
                object Leavedate = null;
                object PT = null;
                object SSGL = null;
                object RTG = null;
                object PreviousYearIPFName = null;
                object PreviousYearPCName = null;
                object Previous_Year_PC = null;
                object Previous_Year_IPF = null;
                object PR = null;
                object IPA = null;
                object SBU_1 = null;
                object Perc_SBU_1 = null;
                object SBU_2 = null;
                object Perc_SBU_2 = null;
                object SBU_3 = null;
                object Perc_SBU_3 = null;
                object BFGuid = null;
                object BFGuide = null;
                object BFEmail = null;
                object comment = null;
                objupload.rowCount = i;

                for (int j = 1; j < colCount; j++)
                {
                    switch (j)
                    {
                        case 1:
                            PersNumber = ws.Cells[i, j].Value;
                            break;
                        case 2:
                            LastName = ws.Cells[i, j].Value;
                            break;
                        case 3:
                            FirstName = ws.Cells[i, j].Value;
                            break;
                        case 4:
                            Ctry = ws.Cells[i, j].Value;
                            break;
                        case 5:
                            SbuName = ws.Cells[i, j].Value;
                            break;
                        case 6:
                            OrgUnitName = ws.Cells[i, j].Value;
                            break;
                        case 7:
                            PersAreaName = ws.Cells[i, j].Value;
                            break;
                        case 8:
                            EmplSubGrpName = ws.Cells[i, j].Value;
                            break;
                        case 9:
                            ASDDate = ws.Cells[i, j].Value;
                            break;
                        case 10:
                            Leavedate = ws.Cells[i, j].Value;
                            break;

                        case 11:
                            PT = ws.Cells[i, j].Value;
                            break;
                        case 12:
                            SSGL = ws.Cells[i, j].Value;
                            break;
                        case 13:
                            RTG = ws.Cells[i, j].Value;
                            break;
                        case 14:
                            PreviousYearIPFName = ws.Cells[i, j].Value;
                            break;
                        case 15:
                            Previous_Year_IPF = ws.Cells[i, j].Value;
                            break;
                        case 16:
                            PreviousYearPCName = ws.Cells[i, j].Value;
                            break;
                        case 17:
                            Previous_Year_PC = ws.Cells[i, j].Value;
                            break;
                        case 18:
                            PR = ws.Cells[i, j].Value;
                            break;
                        case 19:
                            IPA = ws.Cells[i, j].Value;
                            break;
                        case 20:
                            SBU_1 = ws.Cells[i, j].Value;
                            break;
                        case 21:
                            Perc_SBU_1 = ws.Cells[i, j].Value;
                            break;
                        case 22:
                            SBU_2 = ws.Cells[i, j].Value;
                            break;
                        case 23:
                            Perc_SBU_2 = ws.Cells[i, j].Value;
                            break;
                        case 24:
                            SBU_3 = ws.Cells[i, j].Value;
                            break;
                        case 25:
                            Perc_SBU_3 = ws.Cells[i, j].Value;
                            break;
                        case 26:
                            BFGuid = ws.Cells[i, j].Value;
                            break;
                        case 27:
                            BFGuide = ws.Cells[i, j].Value;
                            break;
                        case 28:
                            BFEmail = ws.Cells[i, j].Value;
                            break;
                        case 29:
                            comment = ws.Cells[i, j].Value;
                            break;

                        default: break;
                    }
                    //}
                }
                if (PersNumber != null)
                {
                    string listGuid = list.ID.ToString();
                    SPQuery query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='PersNumber' /><Value Type='Text'>" + Convert.ToString(PersNumber) + "</Value></Eq></Where>";
                    SPListItemCollection listcollection = list.GetItems(query);
                    if (listcollection.Count > 0)
                    {
                        foreach (SPListItem items in listcollection)
                        {
                            methodFormat.Append("<Method ID=\"" + i + "\">" +
                                               "<SetList>" + listGuid + "</SetList>" +
                                               "<SetVar Name=\"Cmd\">Save</SetVar>" +
                                               "<SetVar Name=\"ID\">" + items.ID + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#PersNumber\">" + PersNumber + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#LastName\">" + LastName + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#FirstName\">" + FirstName + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SbuName\">" + SbuName + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Ctry\">" + Ctry + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#OrgUnitName\">" + OrgUnitName + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#PersAreaName\">" + PersAreaName + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#EmplSubGrpName\">" + EmplSubGrpName + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#ASDDate\">" + ASDDate + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Leavedate\">" + Leavedate + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#PT\">" + PT + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SSGL\">" + SSGL + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#RTG\">" + RTG + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Previous_Year_PC\">" + Previous_Year_PC + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Previous_Year_IPF\">" + Previous_Year_IPF + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Previous_Year_IPF_Name\">" + PreviousYearIPFName + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Name_PR\">" + PR + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Name_IPA\">" + IPA + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SBU_1\">" + GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_1), "Area") + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Perc_SBU_1\">" + Perc_SBU_1 + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SBU_2\">" + GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_2), "Area") + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Perc_SBU_2\">" + Perc_SBU_2 + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SBU_3\">" + GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_3), "Area") + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Perc_SBU_3\">" + Perc_SBU_3 + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuid\">" + BFGuid + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide\">" + BFGuide + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFEmail\">" + BFEmail + "</SetVar>" +
                                               "<SetVar Name=\"urn:schemas-microsoft-com:office:office#comment\">" + comment + "</SetVar>");                                             
                        

                            //items["PersNumber"] = PersNumber;
                            //items["LastName"] = LastName;
                            //items["FirstName"] = FirstName;
                            //items["Ctry"] = Ctry;
                            //items["SbuName"] = SbuName;
                            //items["OrgUnitName"] = OrgUnitName;
                            //items["PersAreaName"] = PersAreaName;
                            //items["EmplSubGrpName"] = EmplSubGrpName;
                            //items["ASDDate"] = ASDDate;
                            //items["Leavedate"] = Leavedate;
                            //items["PT"] = PT;
                            //items["SSGL"] = SSGL;
                            //items["RTG"] = RTG;
                            //items["Previous_Year_PC"] = Previous_Year_PC;
                            //items["Previous_Year_IPF"] = Previous_Year_IPF;
                            //items["Previous_Year_IPF_Name"] = PreviousYearIPFName;
                            //items["Previous_Year_PC_Name"] = PreviousYearPCName;
                            //items["Name_PR"] = PR;
                            //items["Name_IPA"] = IPA;
                            //items["SBU_1"] = GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_1), "Area");
                            //items["Perc_SBU_1"] = Perc_SBU_1;
                            //items["SBU_2"] = GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_2), "Area");
                            //items["Perc_SBU_2"] = Perc_SBU_2;
                            //items["SBU_3"] = GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_3), "Area");
                            //items["Perc_SBU_3"] = Perc_SBU_3;
                            //items["BFGuid"] = BFGuid;
                            //items["BFGuide"] = BFGuide;
                            //items["BFEmail"] = BFEmail;
                            //items["comment"] = comment;

                            try
                            {
                                //Updating Additional People/Groups fields
                                //SPUser Level1user = null;
                                if (!string.IsNullOrEmpty(Convert.ToString(BFEmail)))
                                {
                                    ClientPeoplePicker peoplecontrol = new ClientPeoplePicker();
                                    PeopleEditor ppleditor = new PeopleEditor();
                                    PickerEntity entity = new PickerEntity();
                                    entity.Key = Convert.ToString(BFEmail);
                                    entity = ppleditor.ValidateEntity(entity);
                                    entity.IsResolved = true;
                                    peoplecontrol.AddEntities(new List<PickerEntity> { entity });
                                    ArrayList EntitiesList = peoplecontrol.ResolvedEntities;
                                    foreach (PickerEntity entitys in EntitiesList)
                                    {
                                        SPUser user = SPContext.Current.Web.EnsureUser(entitys.Key);
                                        string uservalue = user.ID + ";#" + user.Name;

                                        //items["Supervisor"] = user;
                                        //items["Supervisor_CN"] = user;
                                        //items["BFGuide_CN"] = user;
                                        //items.Update();

                                        methodFormat.Append("<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor\">" + uservalue + "</SetVar>" +
                                            "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor_CN\">" + uservalue + "</SetVar>" +
                                            "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide_CN\">" + uservalue + "</SetVar>");
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    SPUser Level1user = null;
                                    Level1user = SPContext.Current.Web.EnsureUser(Convert.ToString(BFGuide));
                                    string luservalue = Level1user.ID + ";#" + Level1user.Name;

                                    //items["Supervisor"] = Level1user;
                                    //items["Supervisor_CN"] = Level1user;
                                    //items["BFGuide_CN"] = Level1user;
                                    //items.Update();

                                    methodFormat.Append("<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor\">" + luservalue + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor_CN\">" + luservalue + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide_CN\">" + luservalue + "</SetVar>");

                                }
                                catch (Exception)
                                {
                                    i = i + 1;
                                    objupload.rowCount = i;
                                    //objupload.User = "The User " + Convert.ToString(BFGuide) + " is not Available in AD";
                                    objupload.User = objupload.User + Convert.ToString(BFGuide) + ", ";
                                    objupload.UnProcessedCount = objupload.UnProcessedCount + 1;
                                    objupload = PerformancereviewProcessCol(colCount, ws, i, list, objupload);
                                    //objupload.ProcessedCount = Convert.ToString(i - 2);
                                    return objupload;
                                }

                            }
                        }
                    }
                    else
                    {
                        //SPListItem items = list.AddItem();


                        methodFormat.Append("<Method ID=\"" + i + "\">" +
                                           "<SetList>" + listGuid + "</SetList>" +
                                           "<SetVar Name=\"Cmd\">Save</SetVar>" +
                                           "<SetVar Name=\"ID\">New</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#PersNumber\">" + PersNumber + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#LastName\">" + LastName + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#FirstName\">" + FirstName + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SbuName\">" + SbuName + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Ctry\">" + Ctry + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#OrgUnitName\">" + OrgUnitName + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#PersAreaName\">" + PersAreaName + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#EmplSubGrpName\">" + EmplSubGrpName + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#ASDDate\">" + ASDDate + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Leavedate\">" + Leavedate + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#PT\">" + PT + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SSGL\">" + SSGL + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#RTG\">" + RTG + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Previous_Year_PC\">" + Previous_Year_PC + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Previous_Year_IPF\">" + Previous_Year_IPF + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Previous_Year_IPF_Name\">" + PreviousYearIPFName + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Name_PR\">" + PR + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Name_IPA\">" + IPA + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SBU_1\">" + GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_1), "Area") + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Perc_SBU_1\">" + Perc_SBU_1 + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SBU_2\">" + GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_2), "Area") + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Perc_SBU_2\">" + Perc_SBU_2 + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#SBU_3\">" + GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_3), "Area") + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Perc_SBU_3\">" + Perc_SBU_3 + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuid\">" + BFGuid + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide\">" + BFGuide + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFEmail\">" + BFEmail + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#comment\">" + comment + "</SetVar>"); 

                        //items["PersNumber"] = PersNumber;
                        //items["LastName"] = LastName;
                        //items["FirstName"] = FirstName;
                        //items["Ctry"] = Ctry;
                        //items["SbuName"] = SbuName;
                        //items["OrgUnitName"] = OrgUnitName;
                        //items["PersAreaName"] = PersAreaName;
                        //items["EmplSubGrpName"] = EmplSubGrpName;
                        //items["ASDDate"] = ASDDate;
                        //items["Leavedate"] = Leavedate;
                        //items["PT"] = PT;
                        //items["SSGL"] = SSGL;
                        //items["RTG"] = RTG;
                        //items["Previous_Year_PC"] = Previous_Year_PC;
                        //items["Previous_Year_IPF"] = Previous_Year_IPF;
                        //items["Previous_Year_IPF_Name"] = PreviousYearIPFName;
                        //items["Previous_Year_PC_Name"] = PreviousYearPCName;
                        //items["Name_PR"] = PR;
                        //items["Name_IPA"] = IPA;
                        //items["SBU_1"] = GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_1), "Area");
                        //items["Perc_SBU_1"] = Perc_SBU_1;
                        //items["SBU_2"] = GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_2), "Area");
                        //items["Perc_SBU_2"] = Perc_SBU_2;
                        //items["SBU_3"] = GetLookUpValue(Constants.ListSBU, list, Convert.ToString(SBU_3), "Area");
                        //items["Perc_SBU_3"] = Perc_SBU_3;
                        //items["BFGuid"] = BFGuid;
                        //items["BFGuide"] = BFGuide;
                        //items["BFEmail"] = BFEmail;
                        //items["comment"] = comment;

                        try
                        {
                            //SPUser Level1user = null;
                            if (!string.IsNullOrEmpty(Convert.ToString(BFEmail)))
                            {
                                ClientPeoplePicker peoplecontrol = new ClientPeoplePicker();
                                PeopleEditor ppleditor = new PeopleEditor();
                                PickerEntity entity = new PickerEntity();
                                entity.Key = Convert.ToString(BFEmail);
                                entity = ppleditor.ValidateEntity(entity);
                                entity.IsResolved = true;
                                peoplecontrol.AddEntities(new List<PickerEntity> { entity });
                                ArrayList EntitiesList = peoplecontrol.ResolvedEntities;
                                foreach (PickerEntity entitys in EntitiesList)
                                {
                                    SPUser user = SPContext.Current.Web.EnsureUser(entitys.Key);
                                    string uservalue = user.ID + ";#" + user.Name;
                                    //items["Supervisor"] = user;
                                    //items["Supervisor_CN"] = user;
                                    //items["BFGuide_CN"] = user;
                                    //items.Update();
                                    methodFormat.Append("<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor\">" + uservalue + "</SetVar>" +
                                            "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor_CN\">" + uservalue + "</SetVar>" +
                                            "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide_CN\">" + uservalue + "</SetVar>");
                                }
                            }

                        }
                        catch (Exception)
                        {
                            try
                            {
                                //Updating Additional People/Groups fields
                                SPUser Level1user = null;
                                Level1user = SPContext.Current.Web.EnsureUser(Convert.ToString(BFGuide));
                                string luservalue = Level1user.ID + ";#" + Level1user.Name;

                                //items["Supervisor"] = Level1user;
                                //items["Supervisor_CN"] = Level1user;
                                //items["BFGuide_CN"] = Level1user;
                                //items.Update();

                                methodFormat.Append("<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor\">" + luservalue + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Supervisor_CN\">" + luservalue + "</SetVar>" +
                                           "<SetVar Name=\"urn:schemas-microsoft-com:office:office#BFGuide_CN\">" + luservalue + "</SetVar>");
                            }

                            catch (Exception)
                            {
                                i = i + 1;
                                objupload.rowCount = i;
                                //objupload.User = "The User " + Convert.ToString(BFGuide) + " is not Available in AD";
                                objupload.User = objupload.User + Convert.ToString(BFGuide) + ", ";
                                objupload.UnProcessedCount = objupload.UnProcessedCount + 1;
                                objupload = PerformancereviewProcessCol(colCount, ws, i, list, objupload);
                                //objupload.ProcessedCount = Convert.ToString(i - 2);
                                return objupload;
                            }

                        }
                    }
                }
                methodFormat.Append("</Method>");
                objupload.processbatch = new StringBuilder();
                objupload.processbatch.Append(Convert.ToString(methodFormat));
                return objupload;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private SPFieldLookupValue GetLookUpValue(string listName, SPList oList, string lookUpValue, string columnName)
        {
            SPFieldLookupValue value = null;
            SPWeb objweb = SPContext.Current.Web;

            try
            {
                SPList subList = objweb.Lists.TryGetList(listName);//[listName];

                List<SPListItem> oItem = (from SPListItem oi in subList.Items
                                          where oi[columnName] != null && oi[columnName].ToString().Equals(lookUpValue)
                                          select oi).ToList();

                if (oItem.Count > 0) value = new SPFieldLookupValue(Convert.ToInt16(oItem[0]["ID"]), lookUpValue);

            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "GetLookUpValue"); ;
            }

            return value;
        }

        #endregion[PerformanceReview]

        #region[Letter Generation]
        /// <summary>
        /// Maps the SharePoint List column with Columns in Excel File.
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> GetColumnMappingLetterGeneration()
        {
            try
            {
                Dictionary<int, string> map = new Dictionary<int, string>();
                map.Add(1, "NotesType"); // First parameter is the column Index in Excel Sheet and Second Param is SharePoint List's  Column Name (Display Name )
                map.Add(2, "Language");
                map.Add(3, "StatementDate");
                map.Add(4, "FirstName");
                map.Add(5, "LastName");
                map.Add(6, "BU_Function");
                map.Add(7, "Location");
                map.Add(8, "ManagerName");
                map.Add(9, "ManagerEmail");
                map.Add(10, "PerformanceCategory");
                map.Add(11, "AnnualSalary");
                map.Add(12, "MonthlySalary");
                map.Add(13, "ChangePercent");
                map.Add(14, "ChangeAmount");
                map.Add(15, "NewMonthlySalary");
                map.Add(16, "NewAnnualSalary");
                map.Add(17, "RTG");
                map.Add(18, "EffectiveDate");
                map.Add(19, "STIPTarget");
                map.Add(20, "ProrationFactor");
                map.Add(21, "CorporateFactor");
                map.Add(22, "IBF");

                return map;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Uploads the excel file to share point list.
        /// </summary>
        public UploadExcelToSPList UploadExcelFileToSPLetterGenerationList(FileUpload fileupload)
        {
            UploadExcelToSPList objupload = new UploadExcelToSPList();
            //int count = 0;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    string Url = SPContext.Current.Web.Url;
                    using (SPSite spSite = new SPSite(Url))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb())
                        {
                            spWeb.AllowUnsafeUpdates = true;
                            SPList list = spWeb.Lists[Constants.ListLetterGeneration];
                            try
                            {
                                byte[] fileData = fileupload.FileBytes;
                                using (MemoryStream memStream = new MemoryStream(fileData))
                                {
                                    memStream.Flush();
                                    using (ExcelPackage pck = new ExcelPackage(memStream))
                                    {
                                        if (pck != null)
                                        {
                                            objupload = CreateLetterGenerationListItem(pck, list);
                                            // count = CreateLetterGenerationListItem(pck, list);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorLog objerror = new ErrorLog();
                                objerror.WriteExceptionLog(ex.Message, "ReadingExcel-UploadExcelFileToSPLetterGenerationList");
                            }
                            spWeb.AllowUnsafeUpdates = false;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "ReadingExcel-UploadExcelFileToSPLetterGenerationList");
            }
            return objupload;
        }

        /// <summary>
        /// Creates the list item.
        /// </summary>
        /// <param name="pck">The PCK.</param>
        /// <param name="list">The list.</param>
        public UploadExcelToSPList CreateLetterGenerationListItem(ExcelPackage pck, SPList list)
        {
            try
            {
                UploadExcelToSPList objupload = new UploadExcelToSPList();
                Dictionary<int, string> column = GetColumnMappingLetterGeneration();
                ExcelWorksheet ws = pck.Workbook.Worksheets[1];
                int rowCount = ws.Dimension.End.Row + 1;
                int colCount = ws.Dimension.End.Column + 1;
                objupload.UnProcessedCount = 0;

                for (int i = 2; i < rowCount; i++) // Row index starts from 2, as the first row is Title
                {
                    SPListItem item = list.AddItem();

                    objupload = LettergenerationProcessCol(column, colCount, ws, i, list, objupload, item, rowCount);
                    if (objupload.rowCount == i)
                        item.Update();


                }
                list.Update();

                objupload.ProcessedCount = Convert.ToString((rowCount - objupload.UnProcessedCount) - 2);
                return objupload;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public UploadExcelToSPList LettergenerationProcessCol(Dictionary<int, string> column, int colCount, ExcelWorksheet ws, int i, SPList list, UploadExcelToSPList objupload, SPListItem item, int rowCount)
        {
            try
            {
                string UserValue = string.Empty;
                bool resolved = false;
                for (int j = 1; j < colCount; j++)
                {
                    if (column.ContainsKey(j))
                    {
                        item[column[j]] = ws.Cells[i, j].Value;

                        if (j == 8 || j == 9)
                        {
                            try
                            {
                                if (j == 8)
                                {
                                    SPUser Level1user = null;
                                    Level1user = SPContext.Current.Web.EnsureUser(Convert.ToString(ws.Cells[i, j].Value));
                                    UserValue = Convert.ToString(ws.Cells[i, j].Value);
                                    item["Supervisor"] = Level1user;
                                    resolved = true;
                                    j++;
                                }
                                if (j == 9 && resolved == false)
                                {
                                    //SPUser Level1user = null;
                                    if (!string.IsNullOrEmpty(Convert.ToString(ws.Cells[i, j].Value)))
                                    {
                                        ClientPeoplePicker peoplecontrol = new ClientPeoplePicker();
                                        PeopleEditor ppleditor = new PeopleEditor();
                                        PickerEntity entity = new PickerEntity();
                                        entity.Key = Convert.ToString(Convert.ToString(ws.Cells[i, j].Value));
                                        entity = ppleditor.ValidateEntity(entity);
                                        entity.IsResolved = true;
                                        peoplecontrol.AddEntities(new List<PickerEntity> { entity });
                                        ArrayList EntitiesList = peoplecontrol.ResolvedEntities;
                                        foreach (PickerEntity entitys in EntitiesList)
                                        {
                                            SPUser user = SPContext.Current.Web.EnsureUser(entitys.Key);
                                            item["Supervisor"] = user;
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                if (j == 9)
                                {
                                    try
                                    {
                                        //SPUser Level1user = null;
                                        if (!string.IsNullOrEmpty(Convert.ToString(ws.Cells[i, j].Value)))
                                        {
                                            ClientPeoplePicker peoplecontrol = new ClientPeoplePicker();
                                            PeopleEditor ppleditor = new PeopleEditor();
                                            PickerEntity entity = new PickerEntity();
                                            entity.Key = Convert.ToString(Convert.ToString(ws.Cells[i, j].Value));
                                            entity = ppleditor.ValidateEntity(entity);
                                            entity.IsResolved = true;
                                            peoplecontrol.AddEntities(new List<PickerEntity> { entity });
                                            ArrayList EntitiesList = peoplecontrol.ResolvedEntities;
                                            foreach (PickerEntity entitys in EntitiesList)
                                            {
                                                SPUser user = SPContext.Current.Web.EnsureUser(entitys.Key);
                                                item["Supervisor"] = user;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        string[] User = Convert.ToString(ws.Cells[i, j].Value).Split('@');
                                        objupload.User = objupload.User + User[0] + ", ";
                                        objupload.UnProcessedCount = objupload.UnProcessedCount + 1;
                                        objupload.rowCount = i + 1;
                                        return objupload;
                                    }
                                }
                            }
                        }

                    }
                }
                objupload.rowCount = i;
                return objupload;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion[Letter Generation]

        public void CloseLog(UploadExcelToSPList objupload, string CloseLog)
        {
            //string Createdby = string.Empty;
            try
            {
                string Url = SPContext.Current.Web.Url;
                using (SPSite spSite = new SPSite(Url))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        spWeb.AllowUnsafeUpdates = true;
                        //Get User Email-ID
                        string emailTo = spWeb.CurrentUser.Email.ToString();
                        string mailsubj = CloseLog + " " + DateTime.Now.ToString();
                        string Mailbody = "End:" + DateTime.Now.ToString() + "<br/>" + "<br/>" + "Employees processed: " + objupload.ProcessedCount + "<br/>" + "<br/>" + "Employess not processed: " + objupload.UnProcessedCount;
                        SendMail(emailTo, mailsubj, Mailbody);
                        spWeb.AllowUnsafeUpdates = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "Send Email for the Login User ");
            }
        }

        public void SendMail(string To, string mailsubj, string mailbody)
        {
            try
            {
                System.Collections.Specialized.StringDictionary msghdr = new System.Collections.Specialized.StringDictionary();
                msghdr.Add("To", To);
                msghdr.Add("Subject", mailsubj);
                msghdr.Add("Content-Type", "text/html");
                SPUtility.SendEmail(SPContext.Current.Web, msghdr, mailbody);
            }
            catch (Exception ex)
            {
                ErrorLog objerror = new ErrorLog();
                objerror.WriteExceptionLog(ex.Message, "Send Email for the Login User");
            }
        }

        #endregion[Method]
       
    }

   
}
