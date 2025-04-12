using turipaq.Database;
using turipaq.entities_model;

namespace turipaq.Logic.LogicAdmin
{
    public class ClienteBL
    {
        public static int GeneradorID(int count) => count++;

        public static void AgregarCliente(List<Cliente> clientes)
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
            var context = new DataContext();
            Console.WriteLine("Digite un Id de Paquete Para Mostrar");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var cliente = context.Clientes.FirstOrDefault(p => p.ClienteId == selectedId);

            return cliente;
        }

        public static List<Cliente> BuscarCliente(int optionSearch, string searchTerm)
        {
            var context = new DataContext();
            {
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
        }

        public static void VerClientes()
        {
            var context = new DataContext();
            var clientes = context.Clientes.ToList();

            VerClienteEnPantalla();
        }

        public static void EditarCliente()
        {
            var context = new DataContext();
            Console.WriteLine("Digite un  Id del paquete Para Editar");
            int selectedId = Convert.ToInt32(Console.ReadLine());
            var cliente = context.Clientes.Where(p => p.ClienteId == selectedId).FirstOrDefault();
            Console.Write($"El Nombre: {cliente.Nombre}, Digite el Nuevo Nombre: ");
            var nombre = Console.ReadLine();
            Console.Write($"El apellido es: {cliente.Apellido}, Digite el nuevo apellido ");
            var apellido = Console.ReadLine();
            Console.Write($"El correo es: {cliente.Correo}, Digite el Nuevo correom: ");
            var correo = Console.ReadLine();
            Console.Write($"El Telefono es: {cliente.Telefono}, Ingrese el nuevo numero: ");
            var telefono = Console.ReadLine();
            Console.Write($"el documento  : {cliente.DocumentoIdentidad}, ingresa el nuevo e: ");
            var documentoIdentidad = Console.ReadLine();
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
            }

            Console.Write("Nombre (presiona espacio para omitir): ");
            nombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nombre) && nombre != " ")
            {
                cliente.Nombre = nombre;
            }

            Console.Write("Apellido (presiona espacio para omitir): ");
            apellido = Console.ReadLine();
            if (!string.IsNullOrEmpty(apellido) && apellido != " ")
            {
                cliente.Apellido = apellido;
            }

            Console.Write("Correo (presiona espacio para omitir): ");
            correo = Console.ReadLine();
            if (!string.IsNullOrEmpty(correo) && correo != " ")
            {
                cliente.Correo = correo;
            }

            Console.Write("Teléfono (presiona espacio para omitir): ");
            telefono = Console.ReadLine();
            if (!string.IsNullOrEmpty(telefono) && telefono != " ")
            {
                cliente.Telefono = telefono;
            }

            Console.Write("Documento de Identidad (presiona espacio para omitir): ");
            documentoIdentidad = Console.ReadLine();
            if (!string.IsNullOrEmpty(documentoIdentidad) && documentoIdentidad != " ")
            {
                cliente.DocumentoIdentidad = documentoIdentidad;
            }

            if (cliente != null)
            {
                context.Clientes.Update(cliente);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        public static void EliminarCliente()
        {
            Console.WriteLine("Digite un Id de cliente Para Eliminar");
            int selectedId = Convert.ToInt32(Console.ReadLine());
            var context = new DataContext();
            var cliente = context.Clientes.Where(p => p.ClienteId == selectedId).FirstOrDefault();
            Console.WriteLine("Seguro que desea eliminar? 1. Si, 2. No");
            int opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1)
            {
                context.Clientes.Remove(cliente);
                context.SaveChanges();
                Console.WriteLine("Cliente eliminado correctamente");
            }

            Console.WriteLine("Eliminacion de Cliente cancelada");
        }
    }
}

