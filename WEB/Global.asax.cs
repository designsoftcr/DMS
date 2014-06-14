using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using WEB;
using WEB.App_Start;

namespace WEB
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Application_BeginRequest(object sender, EventArgs e)
        {

            string path = HttpContext.Current.Request.Url.AbsolutePath;

            if (HttpContext.Current.Request.ServerVariables["HTTPS"] == "on")
            {
                if (SecurePath.IsSecure(path))
                {
                    //do nothing
                }
                else
                {
                    //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("https://localhost:44300", "http://localhost:22411"));
                    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("https://", "http://"));
                    return;
                }
            }

            if (HttpContext.Current.Request.ServerVariables["HTTPS"] != "on")
            {
                if (SecurePath.IsSecure(path))
                {
                    //Redirect to https version
                    //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("http://localhost:22411", "https://localhost:44300"));
                    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("http://", "https://"));
                }
            }

        }
    }
}
