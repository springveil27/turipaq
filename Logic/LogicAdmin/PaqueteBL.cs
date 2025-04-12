using turipaq.Database;
using turipaq.entities_model;


namespace turipaq.Logic.LogicAdmin
{
    public class PaqueteBL
    {

        public static int GeneradorID(int count) => count++;

        public static void AgregarPaquete(List<PaqueteTuristico>paquetes)
        {
            var context = new DataContext();
            Console.WriteLine("===== CREAR PAQUETES TURÍSTICOS ====="); ;
            var id = GeneradorID(paquetes.Count());
            Console.Write("Destino de viaje ");
            var destino = Console.ReadLine();
            Console.Write("Duracion del viaje: ");
            var duracion = Console.ReadLine();
            Console.Write("Precio $: ");
            int precio = Convert.ToInt32(Console.ReadLine());
            Console.Write("Tipo De viaje: ");
            var tipoViaje = Console.ReadLine();
            Console.Write("Disponible 1. Si  2.No: ");
            bool disponible = Convert.ToInt32(Console.ReadLine()) == 2;
            Console.WriteLine();

            
            var paqueteTuristico = new PaqueteTuristico()
            {
                PaqueteId = id,
                Destino = destino,
                Duracion = duracion,
                Precio = precio,
                TipoViaje = tipoViaje,
                Disponibilidad = disponible
            };
            context.Paquete_Turisticos.Add(paqueteTuristico);
            context.SaveChanges();
        }

       

        public static void verPaqueteEnPantalla(List<PaqueteTuristico> paquetes)
        {
        
            if (!paquetes.Any())
            {
                Console.WriteLine("No hay paquete disponible");
            }
                
            
            foreach (var paquete in paquetes)
            {
                var disponibilidadStr = (paquete.Disponibilidad == true ? "disponible" : "No disponible");
                Console.WriteLine($"|ID: {paquete.PaqueteId} | Destino: {paquete.Destino} |Duracion: {paquete.Duracion}|  Precio: {paquete.Precio}  | Disponible:{disponibilidadStr} | Tipo de viaje:  {paquete.TipoViaje} |");
            }
            Console.ReadKey();
        }

        public static void VerPaqueteBuscando()
        {
            var context = new DataContext();
            var paquete = BuscarPaquete();
            verPaqueteEnPantalla( new List<PaqueteTuristico> { paquete} );
        }
        public static void VerPaqueteBuscando(int optionSearch, string searchTerm)
        {
            var paquete = BuscarPaquete(optionSearch, searchTerm);
            verPaqueteEnPantalla(paquete);
        }
        public static PaqueteTuristico BuscarPaquete()
        {
            var context = new DataContext();
            Console.WriteLine("Digite un Id de Paquete Para Mostrar");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var paquete = context.Paquete_Turisticos.FirstOrDefault(p => p.PaqueteId == selectedId);

            return paquete;
        }
        public static List<PaqueteTuristico> BuscarPaquete(int optionSearch, string searchTerm)
        {
            var context = new DataContext();
            {
                List<PaqueteTuristico> paqueteSeleccionado = new List<PaqueteTuristico>();
                switch (optionSearch)
                {
                    case 2:

                        paqueteSeleccionado = context.Paquete_Turisticos
                            .Where(p => p.Destino.ToLower().Contains(searchTerm.ToLower()))
                            .ToList();
                        break;

                    case 3:
                        paqueteSeleccionado = context.Paquete_Turisticos
                            .Where(p => p.TipoViaje.ToLower().Contains(searchTerm.ToLower()))
                            .ToList();
                        break;

                    case 4:
                        paqueteSeleccionado = context.Paquete_Turisticos
                            .Where(p => p.Duracion.ToLower().Contains(searchTerm.ToLower()))
                                .ToList();
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }  

                return paqueteSeleccionado;
            }
        }
        public static void verPaquetes(List<PaqueteTuristico> paquetes)
        {
            var context = new DataContext();
            paquetes = context.Paquete_Turisticos.ToList();
            verPaqueteEnPantalla(paquetes);
        }
        public static void EditarPaquetes()
        {

            var context = new DataContext();
            Console.WriteLine("Digite un  Id del paquete Para Editar");
            int selectedId = Convert.ToInt32(Console.ReadLine());
            var paquete = context.Paquete_Turisticos.Where(p => p.PaqueteId == selectedId).FirstOrDefault();
            Console.Write($"El Destino es: {paquete.Destino}, Digite el Nuevo Destino: ");
            var Destino = Console.ReadLine();
            Console.Write($"la duracion del paquete es: {paquete.Duracion}, Digite la nueva duracion ");
            var Duracion = Console.ReadLine();
            Console.Write($"El precio del paquete es: {paquete.Precio}, Digite el Nuevo Precio: ");
            var precio = Convert.ToInt32(Console.ReadLine());
            Console.Write($"El Tipo de viaje es: {paquete.TipoViaje}, Digite un Nuevo tipo de viaje: ");
            var TipoViaje = Console.ReadLine();
            Console.Write($"el paquete : {paquete.Disponibilidad}, ingrese  1 esta disponible o 2. no esta disponible: ");
            bool disponibilidad;
            var disponibilidadstr = (disponibilidad = true) ? "si" : "no";


            
            paquete.Destino = Destino;
            paquete.Duracion = Duracion;
            paquete.Precio = precio;
            paquete.TipoViaje = TipoViaje;
            paquete.Disponibilidad = disponibilidad;

            if (paquete != null)
            {
                context.Paquete_Turisticos.Update(paquete);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Paquete no encontrado.");
            }
        }

        public static void EliminarPaquete()
        {
            var context = new DataContext();
            var paquetes = context.Paquete_Turisticos.ToList();
            Console.WriteLine("Digite un Id de paquete Para Eliminar");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var paquete = paquetes.Where(p => p.PaqueteId == selectedId).FirstOrDefault();
            Console.WriteLine("Seguro que desea eliminar? 1. Si, 2. No");
            int opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1)
            {
                context.Paquete_Turisticos.Remove(paquete);
                context.SaveChanges();

                Console.WriteLine("paquete eliminado correctamente");
            }

            Console.WriteLine("Eliminacion de paquete cancelada");
        }

    }
}

