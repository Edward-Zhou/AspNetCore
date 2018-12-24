using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AsmxService
{
    /// <summary>
    /// Summary description for NTLMWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NTLMWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return $"Hello World {HttpContext.Current.User.Identity.Name}";
        }
    }
}
