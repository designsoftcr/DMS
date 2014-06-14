using MTM.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Configuration.Modules
{
    public partial class Default : System.Web.UI.Page
    {
        private ModulesBC modulesBC = new ModulesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

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

        protected void Bind()
        {
            Repeater1.DataSource = modulesBC.Select();
            Repeater1.DataBind();
        }

        protected void BTAdd_Click(object sender, EventArgs e)
        {
            modulesBC.Insert(
                TBModuleName.Text.ToString().Trim(),
                TBModuleDescription.Text.ToString().Trim());
            
            TBModuleName.Text = TBModuleDescription.Text = String.Empty;

            Bind();
            
        }
    }
}