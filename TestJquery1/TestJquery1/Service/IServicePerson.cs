using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace TestJquery1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePerson" in both code and config file together.
    [ServiceContract]
    public interface IServicePerson
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        List<Preguntas> GetPersonByFilter(string filter);
    }
}
