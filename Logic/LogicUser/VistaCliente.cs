using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turipaq.Database;
using turipaq.entities_model;
using System.Runtime.CompilerServices;
using turipaq.Login;

namespace turipaq.Logic.LogicUser
{
    public class VistaCliente
    {
        public static int GeneradorID(int count) => count + 1;

        public static void CrearCuenta(List<Cliente>clientes)
        {
            Console.WriteLine("===== CREAR USUARIO  ====="); ;
            var id = GeneradorID(clientes.Count());
            Console.Write("Ingrese su nombre: ");
            var nombre = Console.ReadLine();
            Console.Write("Ingrese su apellido: ");
            var apellido = Console.ReadLine();
            Console.Write("Ingresa el correo electronico: ");
            var correo = Console.ReadLine();
            Console.Write("Ingresa el numero de telefono: ");
            var telefono = Console.ReadLine();
            Console.Write("Ingresa tu documento de identidad: ");
            var documentoIdentad = Console.ReadLine();
            Console.Write("Ingresa un Usuario: ");
            var usuario = Console.ReadLine();
            Console.Write("Ingresa una contraseña: ");
            var contrasena = Console.ReadLine();
            bool esAdmin = false;
            Console.WriteLine("======================================");
            Console.WriteLine();

            var Cliente = new Cliente()
            {
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Telefono = telefono,
                DocumentoIdentidad = documentoIdentad,
                Usuario = usuario,
                Contrasena = contrasena,
                Admin = esAdmin
            };
            var context = new DataContext();
            context.Clientes.Add(Cliente);
            context.SaveChanges();
        }


        public static void VerClienteEnPantalla(List<Cliente> cliente)
        {
            foreach (var clientes in cliente)
            {
                Console.WriteLine($"|Nombre: {clientes.Nombre} | Apellido: {clientes.Apellido} |Correo: {clientes.Correo}|  telefono: {clientes.Telefono}  | cedula: {clientes.DocumentoIdentidad} | Usuario: {clientes.Usuario} |");
            }
            Console.ReadKey();
        }

        public static void VerClienteBuscado()
        {
            var context = new DataContext();
            var cliente = BuscarCliente();
            VerClienteEnPantalla(new List<Cliente> { cliente });
        }
        public static Cliente BuscarCliente()
        {
            var usuarioActual = LogicLogin.UsuarioIniciado.ClienteId;
            var context = new DataContext();
            int selectedId = usuarioActual;
            var cliente = context.Clientes.FirstOrDefault(p => p.ClienteId == selectedId);
            return cliente;
        }
        public static void VerClientes(List<Cliente> clientes)
        {
            var context = new DataContext();
            clientes = context.Clientes.ToList();
            VerClienteEnPantalla(clientes);
        }

        public static void EditarCliente()
        {
            var usuarioActual = LogicLogin.UsuarioIniciado.ClienteId;
            var context = new DataContext();
            int selectedId = usuarioActual;
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
            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.Correo = correo;
            cliente.Telefono = telefono;
            cliente.DocumentoIdentidad = documentoIdentidad;

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

        public static void VerPagoBuscado()
        {
            var context = new DataContext();
            var pago = BuscarPago();
            VerPagoEnPantalla();
        }
        public static Pago BuscarPago()
        {
            var context = new DataContext();

            int selectedId =  LogicLogin.UsuarioIniciado.ClienteId;

            var pago = context.Pagos.FirstOrDefault(p => p.PagoId == selectedId);
            return pago;
        }
        public static void VerPagoEnPantalla()
        {
            var context = new DataContext();
            var pagos = context.Pagos.ToList();

            foreach (var pago in pagos)
            {
                Console.WriteLine($"|ID: {pago.PagoId} | ID de reserva: {pago.ReservaId} | monto a pagado: {pago.Monto} | metodo: {pago.MetodoPago} | fecha de pago: {pago.FechaPago}|");
            }
        }


    }
}

