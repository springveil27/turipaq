using System;
using turipaq.Login;
using Microsoft.EntityFrameworkCore;
using turipaq.entities_model;
using turipaq.Logic.LogicUser;
using turipaq.Logic.LogicAdmin;
using turipaq.Database;

namespace turipaq.Interfaces.UI
{
    public class ClienteUi
    {
     
            public static void MenuCliente()
        {

            var context = new DataContext();
          List<Reserva> reservas = context.Reservas.ToList();
            List < PaqueteTuristico > paquetes = new List<PaqueteTuristico>();

            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ DE CLIENTE =====");
                Console.WriteLine("1. Ver mi perfil");
                Console.WriteLine("2. Editar mi perfil");
                Console.WriteLine("3. Hacer una reserva");
                Console.WriteLine("4. Ver mis reservas");
                Console.WriteLine("4. ver mi pagos");
                Console.WriteLine("6. Cerrar sesión");
                Console.WriteLine("======================================");
                Console.Write("Seleccione una opción: ");
                int option = Convert.ToInt32(Console.ReadLine());
                var usuarioActual = LogicLogin.UsuarioIniciado;
               
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        VistaCliente.VerClienteBuscado();
                        break;

                    case 2:
                        Console.Clear();
                         VistaCliente.EditarCliente();
                        break;

                    case 3:
                        Console.Clear();
                        ReservaCliente.CrearReserva(reservas,paquetes);
                        break; 
                    case 4:
                        ReservaCliente.VerMiReserva(reservas);
                        break;
                    case 5:
                        PagoBL.VerPagos();
                        break;
                    case 6:
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


