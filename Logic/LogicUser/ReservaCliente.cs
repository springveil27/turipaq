using turipaq.Database;
using turipaq.entities_model;
using turipaq.Interfaces.AI;
using turipaq.Logic.LogicAdmin;
using turipaq.Login;

namespace turipaq.Logic.LogicUser
{
    public class ReservaCliente
    {
        public static string GenerarCodigoUnico()
        {
            string guid = Guid.NewGuid().ToString("N");
            return guid.Substring(0, 10).ToUpper();
        }
        public static void CrearReserva(List<Reserva> reservas, List<PaqueteTuristico> paquetes)
        {

            Console.WriteLine("===== Hacer Reserva  =====");
            var context = new DataContext();
            DateTime fechaReserva = DateTime.Now;
            PaqueteBL.verPaquetes(paquetes);

            var cliente = context.Clientes.FirstOrDefault(c => c.ClienteId == LogicLogin.UsuarioIniciado.ClienteId);

            Console.Write("Ingrese el ID del paquete que desea reservar ");
            var idPaquete = Convert.ToInt32(Console.ReadLine());
            var paquete = context.Paquete_Turisticos.FirstOrDefault(p => p.PaqueteId == idPaquete);
            var idUsuario = LogicLogin.UsuarioIniciado.ClienteId;
            Console.Write("en que fecha desea viajar (dd/MM/yyyy): ");
            var fechaViaje = Console.ReadLine();

            var CodigoUnico = GenerarCodigoUnico();
            var fecha = fechaReserva.ToString();
            Console.WriteLine("======================================");
            Console.WriteLine();

            paquete.ReservasActuales++;
            if (paquete.ReservasActuales >= 3)
            {
                paquete.Disponibilidad = false;
                Console.WriteLine("Este fue el último cupo. El paquete ya no estará disponible.");
            }

            var Reserva = new Reserva()
            {
                PaqueteId = idPaquete,
                ClienteId = idUsuario,
                FechaReserva = fecha,
                FechaViaje = fechaViaje,
                CódigoConfirmación = CodigoUnico

            };

            context.Reservas.Add(Reserva);
            context.SaveChanges();
            Console.WriteLine("Reserva realizada con correctamente");

            List<Pago> pagos = new List<Pago>();
            List<PaqueteTuristico> monto = new List<PaqueteTuristico>();
            PagoBL.Pagar(pagos, Reserva.ReservaId);
        }
        public static void VerMiReserva(List<Reserva> reservas)
        {
            var context = new DataContext();
            foreach (var reserva in reservas)
            {
            var paquete = context.Paquete_Turisticos.Find(reserva.PaqueteId);
                

                Console.WriteLine($"|Lugar de viaje: {paquete.Destino} |ID: {reserva.ReservaId}|ID reserva: {reserva.PaqueteId} | Cliente ID: {reserva.ClienteId} |Fecha de reserva{reserva.FechaReserva}|  fecha de viaje {reserva.FechaViaje}  |codigo de confirmacion {reserva.CódigoConfirmación} |");
            }
            Console.ReadKey();
        }

        public static void VerReservaBuscada(List<Reserva> reservas)
        {
            var context = new DataContext();
            var reserva = BuscarReserva();
            VerMiReserva(reservas);
        }

        public static Reserva BuscarReserva()
        {
            var context = new DataContext();
            int idSeleccionado = LogicLogin.UsuarioIniciado.ClienteId;
            var reserva = context.Reservas.FirstOrDefault(p => p.ClienteId == idSeleccionado);

            return reserva;
        }



        public static void VerReservas(List<Reserva> reservas)
        {
            var context = new DataContext();
            reservas = context.Reservas.ToList();

            VerMiReserva(reservas);
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

        public static void EliminarReserva()
        {
            Console.WriteLine("Digite un Id de Reserva Para Eliminar");
            int selectedId = Convert.ToInt32(Console.ReadLine());
            var context = new DataContext();
            var reservas = context.Reservas.Where(p => p.ReservaId == selectedId).FirstOrDefault();

            Console.WriteLine("¿Seguro que desea eliminar? 1. Sí, 2. No");
            int opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                context.Reservas.Remove(reservas);
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

