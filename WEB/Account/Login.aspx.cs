using CapaLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.Helper;

namespace WEB.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }

        public bool IsAuthenticateByActiveDirectory(string user, string pass)
        {
            try
            {
                if (wc_configuration.AUTH_AD == false) return false;
                return Authenticate_Active_Directoy.AD_UserAuthentication(user, pass);
            }
            catch (Exception ex)
            {
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
                throw;
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                e.Authenticated = Membership.ValidateUser(Login1.UserName, Login1.Password);
                if (e.Authenticated == false)
                {
                    MembershipUser usrInfo = Membership.GetUser(Login1.UserName); // getting user information
                    if (usrInfo == null) return;
                    if (IsAuthenticateByActiveDirectory(Login1.UserName, Login1.Password)) // when the AD information return true, the code must go on
                    {
                        e.Authenticated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
                throw;
            }
        }
    }
}