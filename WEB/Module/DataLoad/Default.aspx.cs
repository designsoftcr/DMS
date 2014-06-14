using CapaLog;
using FSM.BC.DDL;
using FSM.BE.DDL;
using MTM.BC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.DDL_FileWS;

namespace WEB.Module.DataLoad
{
    public partial class Default : System.Web.UI.Page
    {
        private string ModuleId = "30F24934-02CB-4C14-8672-B9D45C276A25";
        private ModulesBC moduleBC = new ModulesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        
        private ProfilesBC profilesBC = new ProfilesBC((new DataBasesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)).ConnectionString());
        private FilesBC filesBC = new FilesBC((new DataBasesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)).ConnectionString());
        private DDL_FileWS.FileWSSoapClient fileWS;

        protected void Page_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");//""es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");//("es-ES");//
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }
            else
            {
                if (DDLProfiles.SelectedValue !=null && !string.IsNullOrEmpty(DDLProfiles.SelectedValue.ToString().Trim()))
                {
                    Session["DDL_Files_ProfileName"] = DDLProfiles.SelectedValue.ToString().Trim();
                }
                if ((string)Session["30F2493402CB4C148672B9D45C276A25"] == null)
                {
                    Session["30F2493402CB4C148672B9D45C276A25"] = (moduleBC.IsValidForUser((string)Session["UserId"],ModuleId)).ToString();
                }

                if (bool.Parse((string)Session["30F2493402CB4C148672B9D45C276A25"]))
                {
                    if (!IsPostBack)
                    {
                        if (!Roles.IsUserInRole("SuperAdmin"))
                        {
                            LiProfiles.Visible = false;
                        }

                        Bind();
                    }
                }
                else
                {
                    Response.Redirect("~/Forbidden");
                }
            }

        }

        protected override void InitializeCulture()
        {
            base.InitializeCulture();
            string cult = (string)(Session["Cult"]);
            if (cult != null)
            {
                Culture = cult;
                UICulture = cult;
            }
            else
            {
                Culture = "en-US";
                UICulture = "en-US";
            }
        }

        protected void BTLoad_Click(object sender, EventArgs e)
        {
            try
            {
                //if (String.Compare(myFile.PostedFile.ContentType, "application/vnd.openxmlformats-officedocument.spreadsheetml.d") == 0 || String.Compare(myFile.PostedFile.ContentType, "application/vnd.ms-excel") == 0)
                if(1==1)
                {
                    // File was sent
                    var postedFile = myFile.PostedFile;
                    int dataLength = postedFile.ContentLength;
                    byte[] myData = new byte[dataLength];
                    postedFile.InputStream.Read(myData, 0, dataLength);

                    string fileName = Path.GetFileName(postedFile.FileName);
                    string ext = System.IO.Path.GetExtension(postedFile.FileName);

                    FilesBE fileBE = filesBC.NewFile();

                    if (fileBE != null)
                    {
                        fileBE.FileName = fileName;
                        if (DDLProfiles.SelectedValue != null && !string.IsNullOrEmpty(DDLProfiles.SelectedValue.ToString().Trim()))
                        {
                            fileBE.ProfileId = Guid.Parse(DDLProfiles.SelectedValue.ToString().Trim());
                        }
                        else
                        {
                            fileBE.ProfileId = Guid.Parse(Session["DDL_Files_ProfileName"].ToString().Trim());
                        }
                        fileBE.Description = TBDescription.Text.ToString().Trim();
                        fileBE.FileLink = String.Concat(WEB.Properties.Settings.Default.DDL_UPLOADS_PATH, fileBE.FileId, ext);// "~/Module/DataLoad/Uploads/"

                        postedFile.SaveAs(String.Concat(WEB.Properties.Settings.Default.DDL_UPLOADS_PATH, fileBE.FileId, ext));

                        filesBC.Update(fileBE);
                        int iExcelCoulumnCount = 0;
                        LError.Text = filesBC.ConvertExcel(fileBE, WEB.Properties.Settings.Default.DDL_UPLOADS_PATH, ref iExcelCoulumnCount);

                        string strWebServices = "0";
                        if (System.Configuration.ConfigurationManager.AppSettings["WebServiceRequired"] != null && !string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["WebServiceRequired"]))
                        {
                            strWebServices = System.Configuration.ConfigurationManager.AppSettings["WebServiceRequired"].ToString();
                        }

                        if (strWebServices == "1")
                        {
                            UploadToDBServer(Convert.ToString(fileBE.FileId));
                        }

                        if (LError.Text != String.Empty)
                        {
                            ErrorDiv.Visible = true;
                        }
                        else
                        {
                            LError.Text = filesBC.ImportData(CBDeleteCurrentData.Checked,
                                                            Guid.Parse((string)Session["CompanyId"]),
                                                            Guid.Parse((string)Session["UserId"]), fileBE,
                                                            WEB.Properties.Settings.Default.DDL_UPLOADS_PATH, iExcelCoulumnCount);
                            if (LError.Text != String.Empty)
                            {
                                ErrorDiv.Visible = true;
                            }
                            else
                            {
                                Response.Redirect("~/Module/DataLoad/Summary?FileId=" + fileBE.FileId);
                            }
                        }
                    }
                }
                else {
                    LError.Text = "Exce ContentType Error  " + myFile.PostedFile.ContentType;
                    Log.appendToLog(Log.LEVEL_WARN, "Exce ContentType Error  " + myFile.PostedFile.ContentType);
                }
            }
            catch (Exception ex)
            {
                LError.Text = "Upload Error " + ex.Message.ToString();
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
            }
        }

        protected void Bind()
        {
            DDLProfiles.DataSource = profilesBC.Select();
            DDLProfiles.DataTextField ="Name";
            DDLProfiles.DataValueField = "ProfileId";
            DDLProfiles.DataBind();
        }

        protected void UploadToDBServer(string fileName)
        {
            try
            {
                fileWS = new DDL_FileWS.FileWSSoapClient();

                FileInfo fInfo = new FileInfo(String.Concat(WEB.Properties.Settings.Default.DDL_UPLOADS_PATH, fileName));
                long numBytes = fInfo.Length;
                double dLen = Convert.ToDouble(fInfo.Length / 1000000);

                //if (dLen < 4)
                //{
                    FileStream fStream = new FileStream(String.Concat(WEB.Properties.Settings.Default.DDL_UPLOADS_PATH, fileName),
                    FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);
 
                    byte[] data = br.ReadBytes((int)numBytes);
                    br.Close();

                    fileWS.FileUpload(data, fileName);
                    fStream.Close();
                    fStream.Dispose();
 
                //}

            }
            catch (Exception ex)
            {
                LError.Text = "Upload Error " + ex.Message.ToString();
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
            }

        }
    }
}