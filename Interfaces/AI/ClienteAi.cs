using turipaq.entities_model;
using turipaq.Logic.LogicAdmin;

namespace turipaq.Interfaces.AI
{
    public class ClienteAi
    {
        public static void MenuCliente()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                bool back = false;
                while (!back)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("===== GESTION DE CLIENTES =====");
                        Console.WriteLine("1.Agregar un nuevo Cliente");
                        Console.WriteLine("2. Ver todos los clientes ");
                        Console.WriteLine("3. Buscar clientes");
                        Console.WriteLine("4. Editar un cliente");
                        Console.WriteLine("5. Eliminar un cliente");
                        Console.WriteLine("6. Salir");
                        Console.WriteLine("======================================");
                        Console.Write("Seleccione una opción: ");
                        string option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                try
                                {
                                    Console.Clear();
                                    ClienteBL.AgregarCliente(clientes);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al agregar cliente: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case "2":
                                try
                                {
                                    Console.Clear();
                                    ClienteBL.VerClientes();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al ver clientes: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case "3":
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("opcion a utilizar para buscar el Paquete: 1. ID 2.Destino  3. Tipo de viaje 4 .duraccion");
                                    int OptionSearch = int.Parse(Console.ReadLine());
                                    if (OptionSearch == 1)
                                    {
                                        ClienteBL.VerClienteBuscado();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese la opcion a utilizar");
                                        var filter = Console.ReadLine();
                                        ClienteBL.VerClienteBuscado();
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error: Por favor ingrese un número válido para la opción de búsqueda.");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al buscar cliente: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case "4":
                                try
                                {
                                    Console.Clear();
                                    ClienteBL.EditarCliente();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al editar cliente: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case "5":
                                try
                                {
                                    Console.Clear();
                                    ClienteBL.EliminarCliente();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al eliminar cliente: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case "6":
                                back = true;
                                break;
                            default:
                                Console.WriteLine("Opción no válida. Presione una tecla para continuar...");
                                Console.ReadKey();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inesperado en el menú de clientes: {ex.Message}");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error crítico en el menú de gestión de clientes: {ex.Message}");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}

    

