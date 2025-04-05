using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turipaq.entities_model
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public int PaqueteID { get; set; }
        public int ClienteID { get; set; }
        public string FechaReserva { get; set; }
        public string FechaViaje { get; set; }
        public string EstadoReserva { get; set; }
        public string CódigoConfirmación { get; set; }
    }
}
