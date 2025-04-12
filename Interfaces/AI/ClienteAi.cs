using turipaq.entities_model;
using turipaq.Logic.LogicAdmin;

namespace turipaq.Interfaces.AI
{
    public class ClienteAi
    {
        public static void MenuCliente()
        {
            List<Cliente> clientes = new List<Cliente>();

            bool back = false;
            while (!back)
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
                        Console.Clear();
                        ClienteBL.AgregarCliente(clientes);
                        break;

                    case "2":
                        Console.Clear();
                        ClienteBL.VerClientes(clientes);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("opcion a utilizar para buscar el Paquete: 1. ID 2.Destino  3. Tipo de viaje 4 .duraccion");
                        var OptionSearch = int.Parse(Console.ReadLine());
                        if (OptionSearch == 1)
                        {

                            ClienteBL.VerClienteBuscado();
                        }
                        else
                        {
                            Console.WriteLine("Ingrese la opcion a utilizar");
                            var filter = Console.ReadLine();

                            ClienteBL.VerClienteBuscado(OptionSearch, filter);
                        }

                        break;

                    case "4":
                        Console.Clear();
                        ClienteBL.EditarCliente();
                        break;

                    case "5":
                        Console.Clear();
                       ClienteBL.EliminarCliente(clientes);
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
        }

    }
}

