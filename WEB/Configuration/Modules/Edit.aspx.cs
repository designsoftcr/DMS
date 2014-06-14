using MTM.BC;
using MTM.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Configuration.Modules
{
    public partial class Edit : System.Web.UI.Page
    {
        private WorkGroupsBC workGroupsBC = new WorkGroupsBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private ModulesBC moduleBC = new ModulesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private ModulesBE moduleBE = new ModulesBE();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Roles.IsUserInRole("SuperAdmin"))
            {
                Response.Redirect("~/Forbidden");
            }
            else
            {
                if (!IsPostBack)
                {
                    Bind();
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

        protected void BTCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuration/Modules/");
        }

        protected void BTSave_Click(object sender, EventArgs e)
        {
            var ModuleId = Request.QueryString["Id"];
            if (ModuleId != null)
            {
                moduleBE.ModuleId = Guid.Parse(ModuleId);
                moduleBE.ModuleName = TBModuleName.Text.ToString().Trim();
                moduleBE.ModuleDescription = TBModuleDescription.Text.ToString().Trim();
                moduleBE.WorkGroups = WorkGroupsInModules();
                moduleBC.UpdateModule(moduleBE);

                Response.Redirect("~/Configuration/Modules/");
            }
        }

        protected void Bind()
        {
            var ModuleId = Request.QueryString["Id"];
            if (ModuleId != null)
            {
                moduleBE = moduleBC.GetModuleByGuid(ModuleId);
                TBModuleName.Text = moduleBE.ModuleName.ToString().Trim();
                TBModuleDescription.Text = moduleBE.ModuleDescription.ToString().Trim();
            }

            CBLWorkGroups.DataSource = workGroupsBC.SelectWorkGroups();
            CBLWorkGroups.DataValueField = "RoleId";
            CBLWorkGroups.DataTextField = "RoleName";
            CBLWorkGroups.DataBind();

            WorkGroupsInModulesMapper(moduleBE.WorkGroups);
        }

        private void WorkGroupsInModulesMapper(List<WorkGroupsBE> workGroups)
        {
            foreach (WorkGroupsBE aux in workGroups)
            {
                CBLWorkGroups.Items.FindByValue(aux.RoleId.ToString()).Selected = true;
            }
        }

        private List<WorkGroupsBE> WorkGroupsInModules()
        {
            List<WorkGroupsBE> workGroups = new List<WorkGroupsBE>();

            for (int i = 0; i < CBLWorkGroups.Items.Count; i++)
            {
                if (CBLWorkGroups.Items[i].Selected)
                {
                    workGroups.Add(new WorkGroupsBE(Guid.Parse(CBLWorkGroups.Items[i].Value)));
                }
            }

            return workGroups;
        }
    }
}