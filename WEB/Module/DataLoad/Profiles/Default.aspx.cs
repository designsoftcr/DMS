using FSM.BC.DDL;
using MTM.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Module.DataLoad.Profiles
{
    public partial class Default : System.Web.UI.Page
    {
        //private ProfilesBC profilesBC = new ProfilesBC((new DataBasesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)).ConnectionString());
        private ProfilesBC profilesBC = new ProfilesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }
            else
            {
                if (!Roles.IsUserInRole("SuperAdmin"))
                {
                    Response.Redirect("~/Forbidden");
                }
                else
                {
                    if (!IsPostBack)
                    {
                        var delete = Request.QueryString["Delete"];
                        if (delete != null)
                        {
                            profilesBC.Delete(delete);
                        }

                        Bind();
                    }
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

        protected void BTAdd_Click(object sender, EventArgs e)
        {
            profilesBC.Insert(TBProfileName.Text.ToString().Trim(),
                DDLStoreProcedures.SelectedValue.ToString().Trim(),
                TBProfileDescription.Text.ToString().Trim());

            TBProfileName.Text = TBProfileDescription.Text = String.Empty;

            Bind();
        }

        protected void Bind()
        {
            DDLStoreProcedures.DataSource = profilesBC.SelectStoreProcedures().DefaultView;
            DDLStoreProcedures.DataTextField = "specific_name";
            DDLStoreProcedures.DataBind();

            Repeater1.DataSource = profilesBC.Select();
            Repeater1.DataBind();

        }

    }
}