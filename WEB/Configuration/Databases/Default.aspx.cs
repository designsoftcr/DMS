using MTM.BC;
using MTM.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Configuration.Databases
{
    public partial class Default : System.Web.UI.Page
    {
        private DataBasesBE databaseBE = new DataBasesBE();
        private DataBasesBC databaseBC = new DataBasesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

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
                    GetDefaultDataBase();
                    ShowDefaultDataBase();
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

        }

        protected void BTSave_Click(object sender, EventArgs e)
        {
            databaseBC.InsertDefault(
                        TBName.Text,
                        TBServerName.Text,
                        TBDataBaseName.Text,
                        TBDataBaseUser.Text,
                        TBDataBasePassword.Text,
                        TBDescription.Text);
        }

        protected void BTCancel_Click(object sender, EventArgs e)
        {
            ShowDefaultDataBase();
        }

        public void GetDefaultDataBase()
        {
            databaseBE = databaseBC.SelectDefaultDataBase();
        }

        public void ShowDefaultDataBase()
        {
            if (databaseBE != null)
            {
                TBName.Text = databaseBE.Name;
                TBServerName.Text = databaseBE.ServerName;
                TBDataBaseName.Text = databaseBE.DataBaseName;
                TBDataBaseUser.Text = databaseBE.DataBaseUser;
                TBDataBasePassword.Text = databaseBE.DataBasePassword;
                TBDescription.Text = databaseBE.Description;
            }
        }
    }
}