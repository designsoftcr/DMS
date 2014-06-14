using MTM.BC;
using MTM.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Configuration.Companies
{
    public partial class Edit : System.Web.UI.Page
    {
        private UsersBC usersBC = new UsersBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private CompaniesBC companyBC = new CompaniesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private CompaniesBE companyBE = new CompaniesBE();

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
            Response.Redirect("~/Configuration/Companies/");
        }

        protected void BTSave_Click(object sender, EventArgs e)
        {
            var CompanyId = Request.QueryString["Id"];
            if (CompanyId != null)
            {
                companyBE.CompanyId = Guid.Parse(CompanyId);
                companyBE.CompanyName = TBCompanyName.Text.ToString().Trim();
                companyBE.Users = UsersInCompanies();
                companyBC.UpdateCompany(companyBE);
                Response.Redirect("~/Configuration/Companies/");
            }
        }

        protected void Bind()
        {
            var CompanyId = Request.QueryString["Id"];
            if (CompanyId != null)
            {
                companyBE = companyBC.GetCompanyByGuid(CompanyId);
                TBCompanyName.Text = companyBE.CompanyName.ToString().Trim();
                if (string.Compare(TBCompanyName.Text,"FONT Sistemas, S.A.") == 0)
                    TBCompanyName.Enabled = false;
            }

            CBLUsers.DataSource = usersBC.SelectUsers();
            CBLUsers.DataValueField = "UserId";
            CBLUsers.DataTextField = "Email";
            CBLUsers.DataBind();

            UsersInCompaniesMapper(companyBE.Users);

        }

        private void UsersInCompaniesMapper(List<UsersBE> users)
        {
            foreach (UsersBE aux in users)
            {
                CBLUsers.Items.FindByValue(aux.UserId.ToString()).Selected = true;
            }
        }

        private List<UsersBE> UsersInCompanies()
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