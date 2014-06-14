using FSM.BC.DMO;
using MTM.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Module.People
{
    public partial class Default : System.Web.UI.Page
    {
        private string ModuleId = "2379199A-7357-4DDC-982E-04F6599CE7DB";
        private ModulesBC moduleBC = new ModulesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        private PeopleBC personBC = new PeopleBC((new DataBasesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)).ConnectionString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }
            else
            {
                if ((string)Session["2379199A73574DDC982E04F6599CE7DB"] == null)
                {
                    Session["2379199A73574DDC982E04F6599CE7DB"] = (moduleBC.IsValidForUser((string)Session["UserId"], ModuleId)).ToString();
                }

                if (bool.Parse((string)Session["2379199A73574DDC982E04F6599CE7DB"]))
                {
                    if (!IsPostBack)
                    {
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
            Repeater1.DataSource = personBC.Select();
            Repeater1.DataBind();
        }
    }
}