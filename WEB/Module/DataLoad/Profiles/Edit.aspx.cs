using FSM.BC.DDL;
using FSM.BE.DDL;
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
    public partial class Edit : System.Web.UI.Page
    {
        private ProfilesBC profilesBC = new ProfilesBC((new DataBasesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)).ConnectionString());

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
                        var profileId = Request.QueryString["Id"];
                        if (profileId != null)
                        {
                            LoadProfile(profileId);
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

        protected void BTCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Module/DataLoad/Profiles/");
        }

        protected void BTSave_Click(object sender, EventArgs e)
        {
            var profileId = Request.QueryString["Id"];
            if (profileId != null)
            {
                profilesBC.Update(profileId, 
                    TBProfileName.Text.ToString().Trim(), 
                    DDLStoreProcedures.SelectedValue.ToString().Trim(),
                    TBProfileDescription.Text.ToString().Trim());

                Response.Redirect("~/Module/DataLoad/Profiles/");
            }
        }

        protected void Bind()
        {
            DDLStoreProcedures.DataSource = profilesBC.SelectStoreProcedures().DefaultView;
            DDLStoreProcedures.DataTextField = "specific_name";
            DDLStoreProcedures.DataBind();
        }

        protected void LoadProfile(string id)
        {
            ProfilesBE profile = profilesBC.SelectProfileById(id);
            TBProfileName.Text = profile.Name;
            TBProfileDescription.Text = profile.Description;
        }
    }
}