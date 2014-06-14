using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MTM.BE;
using MTM.BC;

namespace WEB.Configuration.Companies
{
    public partial class Default : System.Web.UI.Page
    {
        private CompaniesBC companiesBC = new CompaniesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

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
                    var edit = Request.QueryString["Edit"];
                    if (edit != null)
                    {
                        Response.Redirect("~/Configuration/Companies/Edit?Id=" + edit);
                    }

                    var delete = Request.QueryString["Delete"];
                    if (delete != null)
                    {
                        if (string.Compare(delete, "dee87bbb-f773-4134-8049-3e32ec4bd264") != 0)
                            companiesBC.InactiveCompanyById(delete);
                    }

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
            Repeater1.DataSource = companiesBC.Select();
            Repeater1.DataBind();
        }

        protected void BTAdd_Click(object sender, EventArgs e)
        {
            companiesBC.Insert(TBCompanyName.Text.ToString().Trim());
            TBCompanyName.Text = String.Empty;
            Bind();
        }


    }
}