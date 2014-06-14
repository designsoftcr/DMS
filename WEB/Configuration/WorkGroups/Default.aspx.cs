using MTM.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Configuration.WorkGroups
{
    public partial class Default : System.Web.UI.Page
    {
        private WorkGroupsBC workGroupsBC = new WorkGroupsBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

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
                    var delete = Request.QueryString["Delete"];
                    if (delete != null)
                    {
                        try
                        {
                            if (string.Compare(delete,"SuperAdmin")!=0)
                            {
                                Roles.DeleteRole(delete);
                            }
                        }
                        catch { }
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
            Repeater1.DataSource = workGroupsBC.SelectWorkGroups();
            Repeater1.DataBind();
        }

        protected void BTAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Roles.CreateRole(TBWorkGroupName.Text.ToString().Trim());
            }
            catch (Exception ex) { System.Diagnostics.Trace.WriteLine(ex.Message); }

            finally { TBWorkGroupName.Text = String.Empty; }

            Bind();
        }
    }
}