using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turipaq.Database;
using turipaq.entities_model;
using System.Runtime.CompilerServices;

namespace turipaq.Logic
{
    public class PagoBL
    {
        public static int GeneradorID(int count) => count++;

        public static void AgregarPago(List<Pago> pagos)
        {
            Console.WriteLine("===== REGISTRAR PAGO =====");
            var pagoiD = GeneradorID(pagos.Count());
            Console.Write("Metodo de pago 1.Tarjeta 2.Efectivo 3.Transferencia: ");
            var metodoPago = Convert.ToInt32(Console.ReadLine());
            Console.Write("ingresa el id de la reserva que pago ");
            var ReservaId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Monto de pago: $RD ");
            int monto = int.Parse(Console.ReadLine());
            DateTime fechapago = DateTime.Now;

            while (metodoPago != 1 || metodoPago != 2 || metodoPago != 3)
            {
                if (metodoPago == 1)
                {
                    var metodoPagoStr = "Tarjeta";
                    var pago = new Pago()
                    {
                        PagoId = pagoiD,
                        MetodoPago = metodoPagoStr,
                        ReservaID = ReservaId,
                        Monto = new PaqueteTuristico().precio,
                        FechaPago = fechapago.ToString()

                    };
                    var context = new DataContext();
                    context.Pagos.Add(pago);
                    context.SaveChanges();
                }
                else if (metodoPago == 2)
                {
                    var metodoPagoStr = "Efectivo";
                    var pago = new Pago()
                    {
                        PagoId = pagoiD,
                        MetodoPago = metodoPagoStr,
                        ReservaID = ReservaId,
                        Monto = new PaqueteTuristico().precio,
                        FechaPago = fechapago.ToString()
                    };
                    var context = new DataContext();
                    context.Pagos.Add(pago);
                    context.SaveChanges();
                }
                else if (metodoPago == 3)
                {
                    var metodoPagoStr = "Transferencia";
                    var pago = new Pago()
                    {
                        PagoId = pagoiD,
                        MetodoPago = metodoPagoStr,
                        ReservaID = ReservaId,
                        Monto = new PaqueteTuristico().precio,
                        FechaPago = fechapago.ToString()
                    };
                    var context = new DataContext();
                    context.Pagos.Add(pago);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Selecciona una opcion valida");
                }
            }

        }

        public static void VerPagoEnPantalla(List<Pago> pagos)
        {
            foreach (var pago in pagos)
            {
                Console.WriteLine($"|ID: {pago.PagoId} | ID de reserva: {pago.ReservaID} | monto a pagado: {pago.Monto} | metodo: {pago.MetodoPago} | fecha de pago: {pago.FechaPago}|");
            }
        }

        public static void VerPagoBuscado()
        {
            var context = new DataContext();
            var pago = BuscarPago();
            VerPagoEnPantalla(new List<Pago> { pago });
        }

        public static void VerPagoBuscado(int optionSearch, string searchTerm)
        {
            var pagos = BuscarPago(optionSearch, searchTerm);
            VerPagoEnPantalla(pagos);
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
                    pagosSeleccionados = context.Pagos.Where(p => p.FechaPago.ToLower().Contains(searchTerm.ToLower()))
                        .ToList();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            return pagosSeleccionados;
        }

        public static void VerPagos(List<Pago> pagos)
        {
            var context = new DataContext();
            pagos = context.Pagos.ToList();
            VerPagoEnPantalla(pagos);
        }

     

        public static void EliminarPago(List<Pago> pagos)
        {
            Console.WriteLine("Digite un ID de pago para eliminar:");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var pago = pagos.FirstOrDefault(p => p.PagoId == selectedId);
            Console.WriteLine("¿Seguro que desea eliminar? 1. Sí 2. No");
            int opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                var context = new DataContext();
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
