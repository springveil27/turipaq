using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turipaq.Database;
using turipaq.entities_model;
using System.Runtime.CompilerServices;
using Microsoft.IdentityModel.Tokens;

namespace turipaq.Logic
{

    public class ReservaBL
    {
        public static int GeneradorID(int count) => count++;
        public static string GenerarCodigoUnico()
        {
            string guid = Guid.NewGuid().ToString("N");
            return guid.Substring(0, 10).ToUpper();
        }

        public static void AgregarReserva(List<Reserva> reservas)
        {
            DateTime fechaReserva = DateTime.Now;

            Console.WriteLine("===== Hacer Reserva  ====="); ;
            var idReserva = GeneradorID(reservas.Count());
            Console.Write("Ingrese el ID del paquete que desea reservar ");
            var idPaquete = Convert.ToInt32(Console.ReadLine());
            Console.Write("Usuario que desea Reservar ");
            var idUsuario = Convert.ToInt32(Console.ReadLine());
            Console.Write("en que fecha desea viajar (dd/MM/yyyy): ");
            var fechaViaje = Console.ReadLine();
            var CodigoUnico = GenerarCodigoUnico();
            var fecha = fechaReserva.ToString();
            Console.WriteLine("======================================");
            Console.WriteLine();

            var Reserva = new Reserva()
            {
                ReservaId = idReserva,
                PaqueteId = idPaquete,
                ClienteId = idUsuario,
                FechaReserva = fecha,
                FechaViaje = fechaViaje,
                CódigoConfirmación = CodigoUnico

            };
            var context = new DataContext();
            context.Reservas.Add(Reserva);
            context.SaveChanges();
        }

        public static void VerReservaEnPantalla(List<Reserva> reservas)
        {
            foreach (var reserva in reservas)
            {
                Console.WriteLine($"|ID: {reserva.ReservaId}|Nombre: {reserva.PaqueteId} | Apellido: {reserva.ClienteId} |Correo: {reserva.FechaReserva}|  telefono: {reserva.FechaViaje}  | cedula: {reserva.CódigoConfirmación} |");
            }
            Console.ReadKey();
        }

        public static void VerReservaBuscada()
        {
            var context = new DataContext();
            var reserva = BuscarReserva();
            VerReservaEnPantalla(new List<Reserva> { reserva });
        }

        public static void VerReservaBuscada(int optionSearch)
        {
            var reservas = BuscarReserva(optionSearch);
            VerReservaEnPantalla(reservas);
        }

        public static Reserva BuscarReserva()
        {
            var context = new DataContext();
            Console.WriteLine("Digite un Id de Reserva Para Mostrar");
            int idSeleccionado = Convert.ToInt32(Console.ReadLine());

            var reserva = context.Reservas.FirstOrDefault(p => p.ReservaId == idSeleccionado);

            return reserva;
        }

        public static List<Reserva> BuscarReserva(int optionSearch)
        {
            var context = new DataContext();
            List<Reserva> reservasSeleccionadas = new List<Reserva>();

            Console.WriteLine("Digite el ID a buscar:");
            int idSeleccionado = Convert.ToInt32(Console.ReadLine());

            switch (optionSearch)
            {
                case 2:
                    reservasSeleccionadas = context.Reservas
                        .Where(p => p.PaqueteId == idSeleccionado)
                        .ToList();
                    break;

                case 3:
                    reservasSeleccionadas = context.Reservas
                        .Where(p => p.ClienteId == idSeleccionado)
                        .ToList();
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            return reservasSeleccionadas;
        }


        public static void VerReservas(List<Reserva> reservas)
        {
            var context = new DataContext();
            reservas = context.Reservas.ToList();

            VerReservaEnPantalla(reservas);
        }

        public static void EditarReserva()
        {
            var context = new DataContext();
            Console.WriteLine("Digite un Id de Reserva Para Editar");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var reserva = context.Reservas.Where(p => p.ReservaId == selectedId).FirstOrDefault();

            Console.Write($"El ID Del paquete es : {reserva.PaqueteId}, Selecciona Otro Paquete: ");
            string paqueteId = Console.ReadLine();
            Console.Write($"El apellido es: {reserva.FechaReserva}, Digite el nuevo apellido: ");
            string fechaReserva = Console.ReadLine();
            Console.Write($"El correo es: {reserva.FechaViaje}, Digite el Nuevo correo: ");
            string fechaViaje = Console.ReadLine();

            if (!string.IsNullOrEmpty(paqueteId))
            {
                int value = Convert.ToInt32(paqueteId);
                reserva.PaqueteId = value;
            }
            if (!string.IsNullOrEmpty(fechaReserva))
            {
                reserva.FechaReserva = fechaReserva;
            }
            if (!string.IsNullOrEmpty(fechaReserva))
            {
                reserva.FechaViaje = fechaViaje;

            }

            if (reserva != null)
            {
                context.Reservas.Update(reserva);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Reserva no encontrada.");
            }
        }

        public static void EliminarReserva(List<Reserva> reservas)
        {
            Console.WriteLine("Digite un Id de Reserva Para Eliminar");
            int selectedId = Convert.ToInt32(Console.ReadLine());
            var context = new DataContext();
            var reserva = context.Reservas.Where(p => p.ReservaId == selectedId).FirstOrDefault();

            Console.WriteLine("¿Seguro que desea eliminar? 1. Sí, 2. No");
            int opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                context.Reservas.Remove(reserva);
                context.SaveChanges();
                Console.WriteLine("Reserva eliminada correctamente");
            }
            else
            {
                Console.WriteLine("Eliminación de reserva cancelada");
            }
        }
    }
}