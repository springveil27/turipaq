using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turipaq.entities_model
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int PaqueteId { get; set; }
        public int ClienteId { get; set; }
        public string FechaReserva { get; set; }
        public string FechaViaje { get; set; }
        public string CódigoConfirmación { get; set; }
    }
}
