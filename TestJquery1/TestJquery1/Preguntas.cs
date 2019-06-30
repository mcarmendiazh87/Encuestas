using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TestJquery1
{
    /// <summary>
    /// Clase que permite simular el acceso a datos
    /// </summary>
    public class Preguntas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Inicializa la simulación de un contexto de datos
        /// </summary>
        /// <returns></returns>
        public List<Preguntas> GetPreguntas()
        {
            List<Preguntas> persons = new List<Preguntas>();
            persons.Add(new Preguntas { Id = 1, Name = "Pedro" });
            persons.Add(new Preguntas { Id = 2, Name = "Andrés" });
            persons.Add(new Preguntas { Id = 3, Name = "Juan" });
            persons.Add(new Preguntas { Id = 4, Name = "Julián" });
            persons.Add(new Preguntas { Id = 5, Name = "Felipe" });
            return persons;
        }
        /// <summary>
        /// Inicializa la simulación de un contexto de datos con objeto json
        /// </summary>
        /// <returns></returns>
        public string GetPreguntasJson()
        {
            List<Preguntas> persons = new List<Preguntas>();
            persons.Add(new Preguntas { Id = 1, Name = "Cómo te llamas" });
            persons.Add(new Preguntas { Id = 2, Name = "Cúantos años tienes" });
            persons.Add(new Preguntas { Id = 3, Name = "Dónde vives" });
            persons.Add(new Preguntas { Id = 4, Name = "Estudias o trabajas" });
            persons.Add(new Preguntas { Id = 5, Name = "Soltero o Casado" });

            var json = new JavaScriptSerializer().Serialize(persons);

            return json;
        }
        /// <summary>
        /// Permite filtrar personas y realizar una búsqueda 
        /// tanto por Cod si el filtro es numerico o por 
        /// coincidencia con el nombre si el filtro es texto
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Preguntas> PersonsByFilter(string filter)
        {
            double id = -1;
            string name = string.Empty;
            var persons = GetPreguntas();
            if (Double.TryParse(filter, out id))
            {
                var result = from p in persons
                             where p.Id == id
                             select p;
                return result.ToList();
            }
            else {
                var result = from p in persons
                             where p.Name.Contains(filter)
                             select p;
                return result.ToList();
            }
        }
    }
}