﻿using MTM.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Configuration.Users
{
    public partial class Default : System.Web.UI.Page
    {
        private UsersBC usersBC = new UsersBC(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

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
                    var edit = Request.QueryString["Edit"];
                    if (edit != null)
                    {
                        Response.Redirect("~/Configuration/Users/Edit?Id=" + edit);
                    }

                    var delete = Request.QueryString["Delete"];
                    if (delete != null)
                    {
                        Membership.DeleteUser(delete, false);
                    }

                    BindData();
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

        protected void BindData()
        {
            Repeater1.DataSource = usersBC.SelectUsers();
            Repeater1.DataBind();
        }


    }
}