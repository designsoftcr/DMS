using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WCF
{
    /// <summary>
    /// Summary description for FileWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FileWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string FileUpload(byte[] myFile, string fileName)
        {
            try
            {
                MemoryStream ms = new MemoryStream(myFile);
                FileStream fs = new FileStream(
                    System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/") + fileName, FileMode.Create);
                ms.WriteTo(fs);

                ms.Close();
                fs.Close();
                fs.Dispose();

                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
