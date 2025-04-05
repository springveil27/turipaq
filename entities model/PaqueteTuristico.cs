using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turipaq.entities_model
{
    public class PaqueteTuristico
    {
        public int PaqueteId { get; set; }
        public string Destino { get; set; }
        public string Duracion { get; set; }
        public string precio { get; set; }
        public bool disponibilidad { get; set; }
        public string TipoViaje { get; set; }
    }
}
