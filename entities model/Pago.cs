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
        public int ReservaID { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public string FechaPago { get; set; }
    }
}
