namespace turipaq.Interfaces.AI
{
public class MenuAdmin
    {

        public static void MostrarMenuAdmin()
        {

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ ADMIN =====");
                Console.WriteLine("1. Gestionar Paquetes Turísticos");
                Console.WriteLine("2. Gestionar Reservas");
                Console.WriteLine("3. Gestionar Clientes");
                Console.WriteLine("4. Procesar Pagos");
                Console.WriteLine("5. Cerrar sesion");
                Console.WriteLine("======================================");
                Console.Write("Seleccione una opción: ");
                int seleccion = Convert.ToInt32(Console.ReadLine());

                switch (seleccion)
                {
                    case 1:
                        PaqueteAi.Menupaq();
                        break;
                    case 2:
                        ReservaAi.MenuReserva();
                        break;
                    case 3:
                        ClienteAi.MenuCliente();
                        break;
                    case 4:
                        PagoAi.MenuPago();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }



}

