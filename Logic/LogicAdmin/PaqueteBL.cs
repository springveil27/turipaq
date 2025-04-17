using turipaq.Database;
using turipaq.entities_model;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace turipaq.Logic.LogicAdmin
{
    public class PaqueteBL
    {

        public static int GeneradorID(int count) => count++;

        public static void AgregarPaquete(List<PaqueteTuristico>paquetes)
        {
            try
            {
                var context = new DataContext();
                Console.WriteLine("===== CREAR PAQUETES TURÍSTICOS =====");
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
                Console.WriteLine("Paquete turístico agregado correctamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato. Asegúrate de ingresar un número válido para el precio.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado al agregar paquete: {ex.Message}");
            }
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

            try
            {
                var context = new DataContext();
                Console.WriteLine("Digite un Id del paquete Para Editar");
                int selectedId = Convert.ToInt32(Console.ReadLine());
                var paquete = context.Paquete_Turisticos.Where(p => p.PaqueteId == selectedId).FirstOrDefault();

                if (paquete == null)
                {
                    Console.WriteLine("Paquete no encontrado.");
                    return;
                }

                Console.Write($"El Destino es: {paquete.Destino}, Digite el Nuevo Destino (presiona ENTER para omitir): ");
                var Destino = Console.ReadLine();
                if (!string.IsNullOrEmpty(Destino) && Destino != " ")
                {
                    paquete.Destino = Destino;
                }

                Console.Write($"la duracion del paquete es: {paquete.Duracion}, Digite la nueva duracion (presiona ENTER para omitir): ");
                var Duracion = Console.ReadLine();
                if (!string.IsNullOrEmpty(Duracion) && Duracion != " ")
                {
                    paquete.Duracion = Duracion;
                }

                Console.Write($"El precio del paquete es: {paquete.Precio}, Digite el Nuevo Precio (presiona ENTER para omitir): ");
                string precioStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(precioStr) && precioStr != " ")
                {
                    try
                    {
                        int precio = Convert.ToInt32(precioStr);
                        paquete.Precio = precio;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formato de precio inválido. No se actualizó el precio.");
                    }
                }

                Console.Write($"El Tipo de viaje es: {paquete.TipoViaje}, Digite un Nuevo tipo de viaje (presiona ENTER para omitir): ");
                var TipoViaje = Console.ReadLine();
                if (!string.IsNullOrEmpty(TipoViaje) && TipoViaje != " ")
                {
                    paquete.TipoViaje = TipoViaje;
                }

                Console.Write($"El paquete está {(paquete.Disponibilidad ? "disponible" : "no disponible")}, ingrese 1. Si está disponible o 2. No está disponible (presiona ENTER para omitir): ");
                string disponibilidadStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(disponibilidadStr) && disponibilidadStr != " ")
                {
                    try
                    {
                        int opcion = Convert.ToInt32(disponibilidadStr);
                        paquete.Disponibilidad = opcion == 1;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formato inválido. No se actualizó la disponibilidad.");
                    }
                }

                context.Paquete_Turisticos.Update(paquete);
                context.SaveChanges();
                Console.WriteLine("Paquete actualizado correctamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato. Asegúrate de ingresar números donde se requiere.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error: El paquete no existe o los datos son inválidos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar paquete: {ex.Message}");
            }

        }

        public static void EliminarPaquete()
        {
            try
            {
                var context = new DataContext();
                Console.WriteLine("Digite un Id de paquete Para Eliminar");
                int selectedId = Convert.ToInt32(Console.ReadLine());

                var paquete = context.Paquete_Turisticos.FirstOrDefault(p => p.PaqueteId == selectedId);

                if (paquete == null)
                {
                    Console.WriteLine("Paquete no encontrado.");
                    return;
                }

                Console.WriteLine("Seguro que desea eliminar? 1. Si, 2. No");
                int opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion == 1)
                {
                    context.Paquete_Turisticos.Remove(paquete);
                    context.SaveChanges();
                    Console.WriteLine("Paquete eliminado correctamente");
                    return;
                }

                Console.WriteLine("Eliminacion de paquete cancelada");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato. Asegúrate de ingresar un ID válido (número entero).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar paquete: {ex.Message}");
            }
        }

    }
}

