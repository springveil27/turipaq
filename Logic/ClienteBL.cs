﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turipaq.Database;
using turipaq.entities_model;
using System.Runtime.CompilerServices;

namespace turipaq.Logic
{
    public class ClienteBL
    {
        public static int GeneradorID(int count) => count++;

        public static void AgregarCliente(List<Cliente> clientes)
        {
            //TODO:AGregar usuario y contraseña.
            Console.WriteLine("===== CREAR USUARIO  ====="); ;
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
            Console.WriteLine("======================================");
            Console.WriteLine();

            var Cliente = new Cliente()
            {
                ClienteId = id,
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Telefono = telefono,
                DocumentoIdentidad = documentoIdentad
            };
            var context = new DataContext();
            context.Clientes.Add(Cliente);
            context.SaveChanges();
        }


        public static void VerClienteEnPantalla(List<Cliente> cliente)
        {


            foreach (var clientes in cliente)
            {
                Console.WriteLine($"|ID: {clientes.ClienteId }|Nombre: {clientes.Nombre} | Apellido: {clientes.Apellido} |Correo: {clientes.Correo}|  telefono: {clientes.Telefono}  | cedula: {clientes.DocumentoIdentidad} | Tipo de viaje: {clientes} |");
            }
            Console.ReadKey();
        }

        public static void VerClienteBuscado()
        {
            var context = new DataContext();
            var cliente = BuscarCliente();
            VerClienteEnPantalla(new List<Cliente> { cliente });
        }
        public static void VerClienteBuscado(int optionSearch, string searchTerm)
        {
            var cliente = BuscarCliente(optionSearch, searchTerm);
            VerClienteEnPantalla(cliente);
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
                            .Where(p => p.Nombre.ToLower().Contains(searchTerm.ToLower())|| p.Apellido.Contains(searchTerm.ToLower()))
                            .ToList();
                        break;

                    case 3:
                        ClienteSeleccionado = context.Clientes
                            .Where(p => p.Telefono.ToLower().Contains(searchTerm.ToLower()))
                            .ToList();
                        break;

                    case 4:
                        //TODO: AGREGAR busqueda por usuario
                        ClienteSeleccionado = context.Clientes
                            .Where(p => p.DocumentoIdentidad.ToLower().Contains(searchTerm.ToLower()))
                                .ToList();
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                return ClienteSeleccionado;
            }
        }
        public static void VerClientes(List<Cliente> clientes)
        {
            var context = new DataContext();
            clientes = context.Clientes.ToList();

            VerClienteEnPantalla(clientes);
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
        //TODO: AGREGAR CONTRASE
            Console.Write($"el documento  : {cliente.DocumentoIdentidad}, ingresa el nuevo e: ");
            var documentoIdentidad = Console.ReadLine();

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

        public static void EliminarCliente(List<Cliente> clientes)
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