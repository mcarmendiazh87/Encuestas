using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TestJquery1.Service
{
    /// <summary>
    /// Summary description for WebServicePerson
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]//Es importante descomentar esta linea si es que está comentada
    public class WebServicePerson : System.Web.Services.WebService
    {

        [WebMethod]
        public string Respuestas(string Respuestas)
        {
            return String.Format("Sus respuestas fueron: {0}", Respuestas);
        }
    }
}
