using System.Transactions;
using turipaq.Database;
using turipaq.entities_model;

namespace turipaq.Logic.LogicAdmin
{
    public class PagoBL
    {
        public static void Pagar(List<Pago>pagos, int reservaId)
        {
            var context = new DataContext();
            var reserva = context.Reservas.Find(reservaId);
            var monto = context.Paquete_Turisticos.Find(reserva.PaqueteId);
           
           
            Console.WriteLine("===== REGISTRAR PAGO =====");
            Console.Write("Metodo de pago 1.Tarjeta 2.Efectivo 3.Transferencia: ");
            var metodoPago = Convert.ToInt32(Console.ReadLine());
           
           DateTime fechapago = DateTime.Now;
       
            do
            {
                if (metodoPago == 1)
                {
                    var pago = new Pago()
                    {
                        MetodoPago = "Tarjeta",
                        Monto = monto.Precio,
                        FechaPago = fechapago,
                        ReservaId = reservaId
                    };
                    context.Pagos.Add(pago);
                    context.SaveChanges();
                }
                else if (metodoPago == 2)
                {
                    var pago = new Pago()
                    {
                        MetodoPago = "Efectivo",
                        Monto = monto.Precio,
                        FechaPago = fechapago,
                        ReservaId = reservaId

                    };
                    context.Pagos.Add(pago);
                    context.SaveChanges();

                }
                else if (metodoPago == 3)
                {
                    var pago = new Pago()
                    {
                        MetodoPago = "Transferencia",
                        Monto = monto.Precio,
                        FechaPago = fechapago,
                        ReservaId = reservaId
                    };

                    context.Pagos.Add(pago);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Selecciona una opcion valida");
                }

                Console.WriteLine("pago realizado con exitosamente");
            } while (metodoPago != 1 && metodoPago != 2 && metodoPago != 3);
        }

        public static void VerPagoEnPantalla()
        {
            var context = new DataContext();
            var pagos = context.Pagos.ToList();

            foreach (var pago in pagos)
            {
                Console.WriteLine($"|ID: {pago.PagoId} | ID de reserva: {pago.ReservaId} | monto a pagado: {pago.Monto} | metodo: {pago.MetodoPago} | fecha de pago: {pago.FechaPago}|");
            }
        }

        public static void VerPagoBuscado()
        {
            var context = new DataContext();
            var pago = BuscarPago();
            VerPagoEnPantalla();
        }

        public static void VerPagoBuscado(int optionSearch, string searchTerm)
        {
            var pagos = BuscarPago(optionSearch, searchTerm);
            VerPagoEnPantalla();
        }

        public static Pago BuscarPago()
        {
            var context = new DataContext();
            Console.WriteLine("Digite un Id de Pago para mostrar:");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var pago = context.Pagos.FirstOrDefault(p => p.PagoId == selectedId);
            return pago;
        }

        public static List<Pago> BuscarPago(int optionSearch, string searchTerm)
        {
            var context = new DataContext();
            List<Pago> pagosSeleccionados = new List<Pago>();

            switch (optionSearch)
            {
                case 2:
                    pagosSeleccionados = context.Pagos
                        .Where(p => p.MetodoPago.ToLower().Contains(searchTerm.ToLower()))
                        .ToList();
                    break;
                case 3:
                    pagosSeleccionados = context.Pagos.Where(p => p.FechaPago.ToString().ToLower().Contains(searchTerm.ToLower()))
                        .ToList();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            return pagosSeleccionados;
        }

        public static void VerPagos()
        {
            var context = new DataContext();
            var pagos = context.Pagos.ToList();
            VerPagoEnPantalla();
        }



        public static void EliminarPago()
        {
            var context = new DataContext();
            var pagos = context.Pagos.ToList();
            Console.WriteLine("Digite un ID de pago para eliminar:");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var pago = pagos.FirstOrDefault(p => p.PagoId == selectedId);
            Console.WriteLine("¿Seguro que desea eliminar? 1. Sí 2. No");
            int opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                context.Pagos.Remove(pago);
                context.SaveChanges();
                Console.WriteLine("Pago eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
        }
    }
}
