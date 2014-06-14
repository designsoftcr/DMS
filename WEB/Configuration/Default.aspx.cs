using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Configuration
{
    public partial class Default : System.Web.UI.Page
    {
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
    }
}