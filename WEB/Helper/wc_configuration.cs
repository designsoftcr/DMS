using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WEB.Helper
{
    public class wc_configuration
    {
        public static bool AUTH_AD
        {
            get
            {
                if (ConfigurationManager.AppSettings["AUTH_AD"] != null && !string.IsNullOrEmpty(ConfigurationManager.AppSettings["AUTH_AD"]) && ConfigurationManager.AppSettings["AUTH_AD"].ToString().ToUpper() == "TRUE")
                {
                    return true;
                }
                return false;
            }
        }
        public static string SEVER_AD
        {
            get
            {
                if (ConfigurationManager.AppSettings["SEVER_AD"] != null && !string.IsNullOrEmpty(ConfigurationManager.AppSettings["SEVER_AD"]))
                {
                    return ConfigurationManager.AppSettings["SEVER_AD"];
                }
                return string.Empty;
            }
        }
        public static string SEVER_DomainName
        {
            get
            {
                if (ConfigurationManager.AppSettings["SEVER_DomainName"] != null && !string.IsNullOrEmpty(ConfigurationManager.AppSettings["SEVER_DomainName"]))
                {
                    return ConfigurationManager.AppSettings["SEVER_DomainName"];
                }
                return string.Empty;
            }
        }

       

        public static string Links_Externos_DMS
        {
            get
            {
                if (ConfigurationManager.AppSettings["Links_Externos_DMS"] != null && !string.IsNullOrEmpty(ConfigurationManager.AppSettings["Links_Externos_DMS"]))
                {
                    return ConfigurationManager.AppSettings["Links_Externos_DMS"];
                }
                return string.Empty;
            }
        }
    }
}