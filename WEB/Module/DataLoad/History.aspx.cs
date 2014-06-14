using FSM.BC.DDL;
using MTM.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Module.DataLoad
{
    public partial class History : System.Web.UI.Page
    {
        private string ModuleId = "30F24934-02CB-4C14-8672-B9D45C276A25";
        private ModulesBC moduleBC = new ModulesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        private LogBC logBC = new LogBC((new DataBasesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)).ConnectionString());

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
                        if (!Roles.IsUserInRole("SuperAdmin"))
                        {
                            LiProfiles.Visible = false;
                        }
                        Bind();
                    }
                }
                else
                    Response.Redirect("~/Forbidden");
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
            Repeater1.DataSource = logBC.Select((string)Session["UserId"], (string)Session["CompanyId"]);
            Repeater1.DataBind();
        }

        protected void BTClear_Click(object sender, EventArgs e)
        {
            logBC.ClearHistory(WEB.Properties.Settings.Default.DDL_UPLOADS_PATH, (string)Session["UserId"], (string)Session["CompanyId"]);
            Bind();
        }
    }
}