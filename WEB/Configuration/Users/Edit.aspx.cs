using MTM.BC;
using MTM.DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WEB.Configuration.Users
{
    public partial class Edit : System.Web.UI.Page
    {
        private SqlConnection connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection((new DataBasesBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)).ConnectionString());
            if (!Roles.IsUserInRole("SuperAdmin"))
            {
                Response.Redirect("~/Forbidden");
            }
            else
            {
                if (!IsPostBack)
                {
                    getAllControls();
                }
            }
        }

        private void getAllControls() {
            DataTable dt = new DataTable();
            UsersDAC objUsersDAC = new UsersDAC();
            try
            {
                dt = objUsersDAC.GetCompany();
                if (dt != null && dt.Rows.Count > 0) {
                    this.lbxComapny.DataTextField = "CompanyName";
                    this.lbxComapny.DataValueField = "CompanyId";
                    this.lbxComapny.DataSource = dt;
                    this.lbxComapny.DataBind();
                }

                dt = objUsersDAC.GetWorkGroup();
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.lbxWworkGroup.DataTextField = "RoleName";
                    this.lbxWworkGroup.DataValueField = "RoleId";
                    this.lbxWworkGroup.DataSource = dt;
                    this.lbxWworkGroup.DataBind();
                }

                dt = objUsersDAC.GetUserInformation(Request["Id"].ToString().Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                    this.txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    this.txtExternalID.Text = dt.Rows[0]["ExternalId"].ToString();
                }

                dt = objUsersDAC.GetCompanyByUser(Request["Id"].ToString().Trim());
                if (dt != null && dt.Rows.Count > 0 && this.lbxComapny.Items.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++) {
                        lbxComapny.Items.FindByValue(dt.Rows[i]["CompanyId"].ToString()).Selected = true; ;
                    }
                }

                dt = objUsersDAC.GetRolByUser(Request["Id"].ToString().Trim());
                if (dt != null && dt.Rows.Count > 0 && this.lbxWworkGroup.Items.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lbxWworkGroup.Items.FindByValue(dt.Rows[i]["RoleId"].ToString()).Selected = true; ;
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally { 
            
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
        public bool UpdateExternal()
        {
            try
            {
                StringBuilder strCompany = new StringBuilder();
                string strVCompany = string.Empty;
                StringBuilder strRol = new StringBuilder();
                string strVRol = string.Empty;
                string strUserName = Request["Id"].ToString().Trim();
                if (this.lbxComapny.Items.Count > 0) {
                    for (int i = 0; i < this.lbxComapny.Items.Count; i++) {
                        if (this.lbxComapny.Items[i].Selected == true) {
                            strCompany.Append(this.lbxComapny.Items[i].Value);
                            strCompany.Append(",");
                        }
                    }
                }
                if (!string.IsNullOrEmpty(strCompany.ToString()))
                {
                    strVCompany = strCompany.ToString().Remove(strCompany.Length - 1);
                }
                if (this.lbxWworkGroup.Items.Count > 0)
                {
                    for (int i = 0; i < this.lbxWworkGroup.Items.Count; i++)
                    {
                        if (this.lbxWworkGroup.Items[i].Selected == true)
                        {
                            strRol.Append(this.lbxWworkGroup.Items[i].Value);
                            strRol.Append(",");
                        }
                    }
                }
                if (!string.IsNullOrEmpty(strRol.ToString()))
                {
                    strVRol = strRol.ToString().Remove(strRol.Length - 1);
                }
                string strNewPassword = string.Empty;
                if(!string.IsNullOrEmpty(this.txtNewPassword.Text)){
                    MembershipUser u = Membership.GetUser(strUserName);
                    //string strPass = u.GetPassword();
                    u.ChangePassword(u.ResetPassword(),this.txtNewPassword.Text);
                }
                if (string.IsNullOrEmpty(strUserName)) return false;
                UsersDAC objUsersDAC = new UsersDAC();
                objUsersDAC.UpdateUser(strUserName, this.txtExternalID.Text.ToString().Trim(),this.txtEmail.Text, strVCompany, strVRol,strNewPassword);
                this.lblError.Text = "the changes was successful!";
                return true;
            }
            catch (Exception e) {
                this.lblError.Text = e.Message;
                return false;
            }
            finally { 
                connection.Close();
            }
        }

        protected void BTSave_Click(object sender, EventArgs e)
        {
            //AccountProfile currentProfile = AccountProfile.CurrentUser;
            //currentProfile.ExternalId = TBExternalId.Text.ToString().Trim();
            if (UpdateExternal() == true)
            {
                Response.Redirect("~/Configuration/Users/");
            }
        }
    }
}