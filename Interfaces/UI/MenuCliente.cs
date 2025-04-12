using System;
using turipaq.Login;
using Microsoft.EntityFrameworkCore;
using turipaq.entities_model;
using turipaq.Logic;
using turipaq.Database;

namespace turipaq.UI
{
    public class ClienteUi
    {
     
            public static void MenuCliente()
        {
            List<Cliente> clientes = new List<Cliente>();

            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ DE CLIENTE =====");
                Console.WriteLine("1. Ver mi perfil");
                Console.WriteLine("2. Editar mi perfil");
                Console.WriteLine("3. Hacer una reserva");
                Console.WriteLine("4. Ver mis reservas");
                Console.WriteLine("5. Cerrar sesión");
                Console.WriteLine("======================================");
                Console.Write("Seleccione una opción: ");
                string option = Console.ReadLine();
                var usuarioActual = LogicLogin.UsuarioIniciado;
               
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        VistaCliente.VerClienteBuscado();
                        break;

                    case "2":
                        Console.Clear();
                         VistaCliente.EditarCliente();
                        break;

                    case "3":
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


