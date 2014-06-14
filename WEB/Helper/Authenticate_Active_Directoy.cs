using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;

namespace WEB.Helper
{
    public class Authenticate_Active_Directoy
    {
        public static bool AD_UserAuthentication(string usuario, string contrasena)
        {
            if (wc_configuration.AUTH_AD == false) return false;
            string domainAndUsername = usuario;
            if (!usuario.Contains(@"\"))
            {
                domainAndUsername = wc_configuration.SEVER_DomainName + @"\" + usuario;
            }
            string[] strServer_AD = wc_configuration.SEVER_AD.Split(';');
            if (strServer_AD == null || strServer_AD.Length <= 0) return false;
            bool result2= false;
            for (int i = 0; i < strServer_AD.Length; i++)
            {
                DirectoryEntry entry = new DirectoryEntry(strServer_AD[i], domainAndUsername, contrasena);
             
                try
                {
                    DirectorySearcher search = new DirectorySearcher(entry);
                    SearchResult result = search.FindOne();
                    if (result == null)
                    {
                        result2 = false;
                    }
                    else
                    {
                        result2 = true;
                        break;
                    }
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            return result2;
        }
    }
}