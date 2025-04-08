﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using turipaq.entities_model;
using turipaq.Logic;

namespace turipaq.AI
{
    public class ReservaAi
    {
        public static void MenuReserva()
        {
            List<Reserva> reservas = new List<Reserva>();

            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ DE Reservas =====");
                Console.WriteLine("1. Agregar una nueva reserva");
                Console.WriteLine("2. Ver todas las reservas");
                Console.WriteLine("3. Buscar reserva");
                Console.WriteLine("4. Editar una reserva");
                Console.WriteLine("5. Eliminar una reserva");
                Console.WriteLine("6. Volver al menú principal");
                Console.WriteLine("======================================");
                Console.Write("Seleccione una opción: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        ReservaBL.AgregarReserva(reservas);
                        break;

                    case "2":
                        Console.Clear();
                        ReservaBL.VerReservas(reservas);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Opción a utilizar para buscar la reserva: 1. ID 2. ID paquete 3. ID cliente");
                        var optionSearch = int.Parse(Console.ReadLine());
                        if (optionSearch == 1)
                        {
                            ReservaBL.VerReservaBuscada();
                        }
                        else
                        {
                            Console.WriteLine("Ingrese el filtro a utilizar:");
                            var filter = Console.ReadLine();

                            ReservaBL.VerReservaBuscada(optionSearch);
                        }
                        break;

                    case "4":
                        Console.Clear();
                        ReservaBL.EditarReserva();
                        break;

                    case "5":
                        Console.Clear();
                        ReservaBL.EliminarReserva(reservas);
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
