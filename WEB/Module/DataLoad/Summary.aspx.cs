using CapaLog;
using FSM.BC.DDL;
using FSM.BE.DDL;
using MTM.BC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Module.DataLoad
{
    public partial class Summary : System.Web.UI.Page
    {
        private string ModuleId = "30F24934-02CB-4C14-8672-B9D45C276A25";
        private ModulesBC moduleBC = new ModulesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        private LogBC logBC = new LogBC((new DataBasesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)).ConnectionString());
        private LogBE logBE = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }
            else
            {
                if ((string)Session["30F2493402CB4C148672B9D45C276A25"] == null)
                {
                    Session["30F2493402CB4C148672B9D45C276A25"] = (moduleBC.IsValidForUser((string)Session["UserId"], ModuleId)).ToString();
                }

                if (bool.Parse((string)Session["30F2493402CB4C148672B9D45C276A25"]))
                {
                    if (!IsPostBack)
                    {
                        var fileId = Request.QueryString["FileId"];
                        if (fileId != null)
                        {
                            logBE = logBC.SelectByFileId(fileId);
                            if (logBE != null)
                            {
                                Bind();
                            }
                            else
                            {
                                DataTable dt = logBC.getError_Log(fileId);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    this.dtgErrorShow.DataSource = dt;
                                    this.dtgErrorShow.DataBind();
                                }
                                else
                                {
                                    Response.Redirect("~/Module/DataLoad/");
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("~/Module/DataLoad/History");
                        }
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

        protected void Bind()
        {
            try
            {
                DataTable dt = new DataTable();
                var fileId = Request.QueryString["FileId"];
                dt = logBC.getDDL_Error_Log(fileId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dtgErrorShow.DataSource = dt;
                    this.dtgErrorShow.DataBind();
                }
                if (logBE == null) return;

                HLFile.Text = logBE.FileName;
                HLFile.NavigateUrl = logBE.FileLink;            

                if (logBE.ProfileName != String.Empty)
                {
                    LTProfileName.Text = logBE.ProfileName.ToString().Trim();
                    DDProfileName.Visible = true;
                    DTProfileName.Visible = true;
                }

                if(logBE.ProfileDescription != String.Empty)
                {
                    LTProfileDescription.Text = logBE.ProfileDescription.ToString().Trim();
                    DDProfileDescription.Visible = true;
                    DTProfileDescription.Visible = true;
                }

                if (logBE.FileDescription != String.Empty)
                {
                    LTFileDescription.Text = logBE.FileDescription;
                    DTFileDescription.Visible = true;
                    DDFileDescription.Visible = true;
                }

                if (logBE.Inserts > 0)
                {
                    LInsertsR.Text = logBE.Inserts.ToString();
                    LIInserts.Visible = true;
                    DTChanges.Visible = true;
                    DDChanges.Visible = true;
                }

                if (logBE.Updates > 0)
                {
                    LUpdatesR.Text = logBE.Updates.ToString();
                    LIUpdates.Visible = true;
                    DTChanges.Visible = true;
                    DDChanges.Visible = true;
                }

                if (logBE.Deletes > 0)
                {
                    LDeletesR.Text = logBE.Deletes.ToString();
                    LIDeletes.Visible = true;
                    DTChanges.Visible = true;
                    DDChanges.Visible = true;
                }

                if (logBE.Errors > 0 || logBE.ErrorDescription != null)
                {
                    //LErrorsR.Text = logBE.Errors.ToString();
                    //LIErrors.Visible = true;
                    if (logBE.ErrorDescription != null)
                    {
                        LTErrorDescription.Text = logBE.ErrorDescription.ToString().Trim();
                        DIVError.Visible = true;
                    }
                    else {
                        DIVError.Visible = false;
                    }
                }
                else 
                {
                    if(string.Compare((string)(Session["Cult"]),"es-CR")==0)
                    {
                        LTDuration.Text = string.Concat(logBE.Duration.ToString().Trim(), " seg.");
                    }else
                    {
                        LTDuration.Text = string.Concat(logBE.Duration.ToString().Trim(), " sec.");
                    }

                    DDDuration.Visible = true;
                    DTDuration.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
                throw;
            }
            
        }

        protected void dtgErrorShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.Text = HttpUtility.HtmlDecode(cell.Text);//Server.HtmlDecode(cell.Text);
            }
        }
    }
}