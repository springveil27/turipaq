using turipaq.Database;
using turipaq.entities_model;

namespace turipaq.Logic.LogicAdmin
{
    public class ClienteBL
    {
        public static int GeneradorID(int count) => count++;

        public static void AgregarCliente(List<Cliente> clientes)
        {
            try
            {
                var context = new DataContext();

                Console.WriteLine("===== CREAR USUARIO  =====");
                var id = GeneradorID(clientes.Count());
                Console.Write("Ingrese su nombre ");
                var nombre = Console.ReadLine();
                Console.Write("Ingrese su apellido ");
                var apellido = Console.ReadLine();
                Console.Write("Ingresa el correo electronico: ");
                var correo = Console.ReadLine();
                Console.Write("Ingresa el numero de telefono: ");
                var telefono = Console.ReadLine();
                Console.Write("Ingresa tu documento de identidad");
                var documentoIdentad = Console.ReadLine();
                Console.Write("Ingresa un Usuario");
                var usuario = Console.ReadLine();
                Console.Write("Ingresa una contraseña");
                var contrasena = Console.ReadLine();
                Console.WriteLine("El usuario es administrador? 1.Si 2.No");
                bool esAdmin = Convert.ToInt32(Console.ReadLine()) == 1;
                Console.WriteLine("======================================");
                Console.WriteLine();

                var Cliente = new Cliente()
                {
                    ClienteId = id,
                    Nombre = nombre,
                    Apellido = apellido,
                    Correo = correo,
                    Telefono = telefono,
                    DocumentoIdentidad = documentoIdentad,
                    Usuario = usuario,
                    Contrasena = contrasena,
                    Admin = esAdmin
                };

                context.Clientes.Add(Cliente);
                context.SaveChanges();
            }
            catch (FormatException)
            {
                Console.WriteLine("Ingresaste algun valor mal. asegurate de usar numero donde se te pide");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error inesperado: {ex.Message}");
            }
        }

        public static void VerClienteEnPantalla()
        {
            var context = new DataContext();
            var cliente = context.Clientes.ToList();

            foreach (var clientes in cliente)
            {
                Console.WriteLine($"|ID: {clientes.ClienteId}|Nombre: {clientes.Nombre} | Apellido: {clientes.Apellido} |Correo: {clientes.Correo}|  telefono: {clientes.Telefono}  | cedula: {clientes.DocumentoIdentidad} | Usuario: {clientes.Usuario} |");
            }
            Console.ReadKey();
        }

        public static void VerClienteBuscado()
        {
            var context = new DataContext();
            var cliente = BuscarCliente();
            VerClienteEnPantalla();
        }

        public static void VerClienteBuscado(int optionSearch, string searchTerm)
        {
            var cliente = BuscarCliente(optionSearch, searchTerm);
            VerClienteEnPantalla();
        }

        public static Cliente BuscarCliente()
        {
            try
            {
                var context = new DataContext();
                Console.WriteLine("Digite un Id de Paquete Para Mostrar");
                int selectedId = Convert.ToInt32(Console.ReadLine());

                var cliente = context.Clientes.FirstOrDefault(p => p.ClienteId == selectedId);

                if (cliente == null)
                {
                    Console.WriteLine("Cliente no encontrado.");
                }

                return cliente;
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de ID inválido. Por favor ingrese un número entero.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error al buscar cliente: {ex.Message}");
                return null;
            }
        }

        public static List<Cliente> BuscarCliente(int optionSearch, string searchTerm)
        {
            try
            {
                var context = new DataContext();
                List<Cliente> ClienteSeleccionado = new List<Cliente>();

                switch (optionSearch)
                {
                    case 2:
                        ClienteSeleccionado = context.Clientes
                            .Where(p => p.Nombre.ToLower().Contains(searchTerm.ToLower()) || p.Apellido.Contains(searchTerm.ToLower()))
                            .ToList();
                        break;

                    case 3:
                        ClienteSeleccionado = context.Clientes
                            .Where(p => p.Telefono.ToLower().Contains(searchTerm.ToLower()))
                            .ToList();
                        break;

                    case 4:
                        ClienteSeleccionado = context.Clientes
                            .Where(p => p.Usuario.ToLower().Contains(searchTerm.ToLower()))
                            .ToList();
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                return ClienteSeleccionado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar cliente: {ex.Message}");
                return new List<Cliente>();
            }
        }

        public static void VerClientes()
        {
            var context = new DataContext();
            var clientes = context.Clientes.ToList();

            VerClienteEnPantalla();
        }

        public static void EditarCliente()
        {
            try
            {
                var context = new DataContext();
                Console.WriteLine("Digite un Id del paquete Para Editar");
                int selectedId = Convert.ToInt32(Console.ReadLine());
                var cliente = context.Clientes.Where(p => p.ClienteId == selectedId).FirstOrDefault();

                if (cliente == null)
                {
                    Console.WriteLine("Cliente no encontrado.");
                    return;
                }

                Console.Write($"El Nombre: {cliente.Nombre}, Digite el Nuevo Nombre (presiona ENTER para omitir): ");
                var nombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nombre) && nombre != " ")
                {
                    cliente.Nombre = nombre;
                }

                Console.Write($"El apellido es: {cliente.Apellido}, Digite el nuevo apellido (presiona ENTER para omitir): ");
                var apellido = Console.ReadLine();
                if (!string.IsNullOrEmpty(apellido) && apellido != " ")
                {
                    cliente.Apellido = apellido;
                }

                Console.Write($"El correo es: {cliente.Correo}, Digite el Nuevo correo (presiona ENTER para omitir): ");
                var correo = Console.ReadLine();
                if (!string.IsNullOrEmpty(correo) && correo != " ")
                {
                    cliente.Correo = correo;
                }

                Console.Write($"El Telefono es: {cliente.Telefono}, Ingrese el nuevo numero(presiona ENTER para omitir) : ");
                var telefono = Console.ReadLine();
                if (!string.IsNullOrEmpty(telefono) && telefono != " ")
                {
                    cliente.Telefono = telefono;
                }

                Console.Write($"el documento  : {cliente.DocumentoIdentidad}, ingresa el nuevo documento (presiona ENTER para omitir): ");
                var documentoIdentidad = Console.ReadLine();
                if (!string.IsNullOrEmpty(documentoIdentidad) && documentoIdentidad != " ")
                {
                    cliente.DocumentoIdentidad = documentoIdentidad;
                }

                Console.Write($"Desea editar la contraseña? 1.Si 2.No ");
                int selectOption = Convert.ToInt32(Console.ReadLine());
                if (selectOption == 1)
                {
                    Console.Write($"Ingresa la contraseña actual: ");
                    var contrasenaActual = Console.ReadLine();
                    if (contrasenaActual == cliente.Contrasena)
                    {
                        Console.WriteLine("Ingresa una nueva contraseña");
                        var contrasena = Console.ReadLine();
                        cliente.Contrasena = contrasena;
                    }
                    else
                    {
                        Console.WriteLine("Contraseña incorrecta. No se actualizó la contraseña.");
                    }
                }

                context.Clientes.Update(cliente);
                context.SaveChanges();
                Console.WriteLine("Cliente actualizado correctamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, ingrese un ID válido (número entero).");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error: Cliente no encontrado o datos incorrectos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }

        }

        public static void EliminarCliente()
        {
            try
            {
                Console.WriteLine("Digite un Id de cliente Para Eliminar");
                int selectedId = Convert.ToInt32(Console.ReadLine());
                var context = new DataContext();
                var cliente = context.Clientes.Where(p => p.ClienteId == selectedId).FirstOrDefault();

                if (cliente == null)
                {
                    Console.WriteLine("Cliente no encontrado.");
                    return;
                }

                Console.WriteLine("Seguro que desea eliminar? 1. Si, 2. No");
                int opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion == 1)
                {
                    context.Clientes.Remove(cliente);
                    context.SaveChanges();
                    Console.WriteLine("Cliente eliminado correctamente");
                    return;
                }

                Console.WriteLine("Eliminacion de Cliente cancelada");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato. Asegúrate de ingresar numeros validos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error al eliminar cliente: {ex.Message}");
            }
        }
    }
    }


