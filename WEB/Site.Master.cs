using MTM.BC;
using MTM.BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        private CompaniesBC companyBC = new CompaniesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private UsersBC userBC = new UsersBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private ModulesBC moduleBC = new ModulesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");//""es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");//("es-ES");//
            if(!IsPostBack){
                try
                {
                    if (AccountProfile.CurrentUser != null)
                    {
                        InitSession();
                        InitMenu();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message); 
                }
            }
        }

        protected void LBSetLangES_Click(object sender, EventArgs e)
        {
            SwitchCulture("es-CR");
        }

        protected void LBSetLangEN_Click(object sender, EventArgs e)
        {
            SwitchCulture("en-US");
        }

        protected void SwitchCulture(String cult)
        {
            AccountProfile currentProfile = AccountProfile.CurrentUser;
            currentProfile.Culture = cult;
            currentProfile.Save();
            Session["Cult"] = cult;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void InitMenu()
        {
            if(!Roles.IsUserInRole("SuperAdmin"))
                LBConfiguration.Visible = false;

            if ((string)Session["30F2493402CB4C148672B9D45C276A25"] == null)
                Session["30F2493402CB4C148672B9D45C276A25"] = (moduleBC.IsValidForUser((string)Session["UserId"],"30F24934-02CB-4C14-8672-B9D45C276A25")).ToString();

            if(!bool.Parse((string)Session["30F2493402CB4C148672B9D45C276A25"]))
                LBDataLoad.Visible = false;

            if ((string)Session["2379199A73574DDC982E04F6599CE7DB"] == null)
                Session["2379199A73574DDC982E04F6599CE7DB"] = (moduleBC.IsValidForUser((string)Session["UserId"], "2379199A-7357-4DDC-982E-04F6599CE7DB")).ToString();

            if (!bool.Parse((string)Session["2379199A73574DDC982E04F6599CE7DB"]))
                LBPeople.Visible = false;
        }

        protected void BTChangeCompany_Click(object sender, EventArgs e)
        {
            AccountProfile currentProfile = AccountProfile.CurrentUser;
            SetCompany(currentProfile);
            LSelectedCompany.Text = (string)Session["CompanyName"];
        }

        protected void SetCompany(AccountProfile currentProfile)
        {
            currentProfile.CurrentCompanyName = DDLCompanies.SelectedItem.ToString().Trim();
            currentProfile.CurrentCompanyId = DDLCompanies.SelectedValue;
            currentProfile.Save();

            Session["CompanyId"] = currentProfile.CurrentCompanyId;
            Session["CompanyName"] = currentProfile.CurrentCompanyName;
        }

        protected void InitSession()
        {
            AccountProfile currentProfile = AccountProfile.CurrentUser;

            if (Session["UserId"] == null)
            {
                currentProfile.UserId = userBC.GetUserGuid(currentProfile.UserName);
                currentProfile.Save();
                Session["UserId"] = currentProfile.UserId;
                Session["ExternalUserId"] = currentProfile.ExternalId;
            }

            DDLCompanies.DataSource = companyBC.GetCompaniesByUserGuid((string)Session["UserId"]);
            DDLCompanies.DataTextField = "CompanyName";
            DDLCompanies.DataValueField = "CompanyId";
            DDLCompanies.DataBind();

            if (Session["CompanyId"] == null)
                SetCompany(currentProfile);

            LSelectedCompany.Text = (string)Session["CompanyName"];
        }

    }
}