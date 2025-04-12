using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turipaq.entities_model
{
    public class Pago
    {
        public int PagoId { get; set; }
        public Reserva Reserva { get; set; }
        public int ReservaId { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
