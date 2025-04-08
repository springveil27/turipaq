using System;
using turipaq.AI;
using Microsoft.EntityFrameworkCore;

class Database
{
    static void Main(string[] args)
    {
  
        bool running = true;
        while (running)
        {
            Console.Clear();

            Console.WriteLine("===== MENÚ PRINCIPAL - TURIPAQ  =====");
            Console.WriteLine("1. Gestionar Paquetes Turísticos");
            Console.WriteLine("2. Gestionar Reservas");
            Console.WriteLine("3. Gestionar Clientes");
            Console.WriteLine("4. Procesar Pagos");
            Console.WriteLine("5. Volver al menu principal");
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
                case 6:
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


