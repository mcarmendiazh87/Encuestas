using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestJquery1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicePerson" in code, svc and config file together.
    public class ServicePerson : IServicePerson
    {
        public List<Preguntas> GetPersonByFilter(string filter)
        {
            Preguntas persons = new Preguntas();
            var personsList = persons.PersonsByFilter(filter);
            return personsList;
        }
    }
}
