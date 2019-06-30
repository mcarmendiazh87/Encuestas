using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace TestJquery1
{
    public partial class AJAXJQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Método de servicio 
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static List<Preguntas> GetPreguntas()
        {
            Preguntas preguntas = new Preguntas();
            var list = preguntas.GetPreguntas();
            return list;
        }

        [WebMethod]
        public static string GetPreguntasJson()
        {
            Preguntas preguntas = new Preguntas();
            var list = preguntas.GetPreguntasJson();
            return list;
        }
    }
   
}