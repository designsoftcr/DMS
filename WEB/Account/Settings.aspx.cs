using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Account
{
    public partial class Settings : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }
            else
            {
                if (!IsPostBack)
                {
                    changePassword.Visible = true;

                    CanRemoveExternalLogins = true;

                    // Render success message
                    var message = Request.QueryString["m"];
                    if (message != null)
                    {
                        // Strip the query string from action
                        Form.Action = ResolveUrl("~/Account/Settings");

                        if (AccountProfile.CurrentUser.Culture == "es-CR")
                        {
                            SuccessMessage =
                              message == "ChangePwdSuccess" ? "Su contraseña ha sido cambiada."
                              : message == "SetPwdSuccess" ? "Su contraseña se ha establecido."
                              : message == "RemoveLoginSuccess" ? "El ingreso externo ha sido retirado."
                              : String.Empty;
                        }
                        else
                        {
                            SuccessMessage =
                                message == "ChangePwdSuccess" ? "Your password has been changed."
                                : message == "SetPwdSuccess" ? "Your password has been set."
                                : message == "RemoveLoginSuccess" ? "The external login was removed."
                                : String.Empty;
                        }
                        successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                    }
                }
            }
        }

        protected static string ConvertToDisplayDateTime(DateTime? utcDateTime)
        {
            // You can change this method to convert the UTC date time into the desired display
            // offset and format. Here we're converting it to the server timezone and formatting
            // as a short date and a long time string, using the current thread culture.
            return utcDateTime.HasValue ? utcDateTime.Value.ToLocalTime().ToString("G") : "[never]";
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
    }
}