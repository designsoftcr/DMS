using MTM.BC;
using MTM.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Configuration.WorkGroups
{
    public partial class Edit : System.Web.UI.Page
    {
        private UsersBC usersBC = new UsersBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private WorkGroupsBC workGroupBC = new WorkGroupsBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private WorkGroupsBE workGroupBE = new WorkGroupsBE();

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
            Response.Redirect("~/Configuration/WorkGroups/");
        }

        protected void BTSave_Click(object sender, EventArgs e)
        {
            var RoleId = Request.QueryString["Id"];
            if (RoleId != null)
            {
                workGroupBE.RoleId = Guid.Parse(RoleId);
                workGroupBE.RoleName = TBWorkGroupName.Text.ToString().Trim();
                workGroupBE.Users = UsersInWorkGroup();
                workGroupBC.UpdateWorkGroup(workGroupBE);
                Response.Redirect("~/Configuration/WorkGroups/");
            }

        }

        protected void Bind()
        {
            var RoleId = Request.QueryString["Id"];
            if (RoleId != null)
            {
                workGroupBE = workGroupBC.GetWorkGroupByGuid(RoleId);
                
                TBWorkGroupName.Text = workGroupBE.RoleName.ToString().Trim();

                if(string.Compare(TBWorkGroupName.Text, "SuperAdmin") == 0)
                {
                    TBWorkGroupName.Enabled = false;
                }
            }

            CBLUsers.DataSource = usersBC.SelectUsers();
            CBLUsers.DataValueField = "UserId";
            CBLUsers.DataTextField = "Email";
            CBLUsers.DataBind();

            UsersInWorkGroupMapper(workGroupBE.Users);

        }

        private void UsersInWorkGroupMapper(List<UsersBE> users)
        {
            foreach (UsersBE aux in users)
            {
                CBLUsers.Items.FindByValue(aux.UserId.ToString()).Selected = true;
            }
        }

        private List<UsersBE> UsersInWorkGroup()
        {
            List<UsersBE> users = new List<UsersBE>();

            for (int i = 0; i < CBLUsers.Items.Count; i++)
            {
                if (CBLUsers.Items[i].Selected)
                {
                    users.Add(new UsersBE(Guid.Parse(CBLUsers.Items[i].Value)));
                }
            }

            return users;
        }
    }
}