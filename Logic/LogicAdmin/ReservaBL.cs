using turipaq.Database;
using turipaq.entities_model;


namespace turipaq.Logic.LogicAdmin
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
            try
            {
                DateTime fechaReserva = DateTime.Now;

                Console.WriteLine("===== Hacer Reserva  =====");
                var idReserva = GeneradorID(reservas.Count());

                Console.Write("Ingrese el ID del paquete que desea reservar: ");
                var idPaquete = Convert.ToInt32(Console.ReadLine());

                Console.Write("Usuario que desea Reservar: ");
                var idUsuario = Convert.ToInt32(Console.ReadLine());

                Console.Write("En qué fecha desea viajar (dd/MM/yyyy): ");
                var fechaViaje = Console.ReadLine();

                var codigoUnico = GenerarCodigoUnico();
                var fecha = fechaReserva.ToString();

                Console.WriteLine("======================================");
                Console.WriteLine();

                var reserva = new Reserva()
                {
                    ReservaId = idReserva,
                    PaqueteId = idPaquete,
                    ClienteId = idUsuario,
                    FechaReserva = fecha,
                    FechaViaje = fechaViaje,
                    CódigoConfirmación = codigoUnico
                };

                using (var context = new DataContext())
                {
                    context.Reservas.Add(reserva);
                    context.SaveChanges();
                    Console.WriteLine("Reserva agregada correctamente.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El formato de entrada no es válido. Por favor, ingrese un número entero donde se requiera.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: El valor ingresado es demasiado grande o pequeño.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar la reserva: {ex.Message}");
            }
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


        public static void EliminarReserva(List<Reserva> reservas)
        {
            try
            {
                Console.WriteLine("Digite un Id de Reserva Para Eliminar:");
                int selectedId = Convert.ToInt32(Console.ReadLine());

                using (var context = new DataContext())
                {
                    var reserva = context.Reservas.Where(p => p.ReservaId == selectedId).FirstOrDefault();

                    if (reserva == null)
                    {
                        Console.WriteLine("No se encontró la reserva con el ID especificado.");
                        return;
                    }

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
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la reserva: {ex.Message}");
            }
        }
    }
}