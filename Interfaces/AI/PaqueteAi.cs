using turipaq.entities_model;
using turipaq.Logic.LogicAdmin;
namespace turipaq.Interfaces.AI
{
    class PaqueteAi
    {
     public static void Menupaq()
        {
            List<PaqueteTuristico> paquetes = new List<PaqueteTuristico>();

            bool backanother = true;
            while (backanother)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("===== MENÚ DE PAQUETES TURÍSTICOS =====");
                    Console.WriteLine("1. Agregar un nuevo paquete");
                    Console.WriteLine("2. Ver todos los paquetes");
                    Console.WriteLine("3. Buscar paquete");
                    Console.WriteLine("4. Editar un paquete");
                    Console.WriteLine("5. Eliminar un paquete");
                    Console.WriteLine("6. Volver al menú principal");
                    Console.WriteLine("======================================");
                    Console.Write("Seleccione una opción: ");
                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            Console.Clear();
                            try
                            {
                                PaqueteBL.AgregarPaquete(paquetes);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error al agregar paquete: {ex.Message}");
                                Console.ReadKey();
                            }
                            break;

                        case "2":
                            Console.Clear();
                            try
                            {
                                PaqueteBL.verPaquetes(paquetes);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error al mostrar paquetes: {ex.Message}");
                                Console.ReadKey();
                            }
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Opción para buscar el paquete: 1. ID  2. Destino  3. Tipo de viaje  4. Duración");
                            try
                            {
                                var optionSearch = int.Parse(Console.ReadLine());

                                if (optionSearch == 1)
                                {
                                    PaqueteBL.VerPaqueteBuscando();
                                }
                                else
                                {
                                    Console.WriteLine("Ingrese el valor para filtrar:");
                                    var filter = Console.ReadLine();

                                    PaqueteBL.VerPaqueteBuscando(optionSearch, filter);
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Debe ingresar un número válido.");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error al buscar paquete: {ex.Message}");
                                Console.ReadKey();
                            }
                            break;

                        case "4":
                            Console.Clear();
                            try
                            {
                                PaqueteBL.EditarPaquetes();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error al editar paquete: {ex.Message}");
                                Console.ReadKey();
                            }
                            break;

                        case "5":
                            Console.Clear();
                            try
                            {
                                PaqueteBL.EliminarPaquete();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error al eliminar paquete: {ex.Message}");
                                Console.ReadKey();
                            }
                            break;

                        case "6":
                            backanother = false;
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Presione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }
    }
}
        
