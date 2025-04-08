using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using turipaq.entities_model;
using turipaq.Logic;

namespace turipaq.AI
{
    public class PagoAi
    {
        public static void MenuPago()
        {
            List<Pago> pagos = new List<Pago>();

            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ DE PAGOS =====");
                Console.WriteLine("1. Agregar un nuevo pago");
                Console.WriteLine("2. Ver todos los pagos");
                Console.WriteLine("3. Buscar pago");
                Console.WriteLine("4. Eliminar un pago");
                Console.WriteLine("5. Volver al menú principal");
                Console.WriteLine("======================================");
                Console.Write("Seleccione una opción: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        PagoBL.AgregarPago(pagos);
                        break;

                    case "2":
                        Console.Clear();
                        PagoBL.VerPagos(pagos);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Opción a utilizar para buscar el pago: 1. ID 2. ID reserva 3. ID cliente");
                        var optionSearch = int.Parse(Console.ReadLine());
                        if (optionSearch == 1)
                        {
                            PagoBL.VerPagoBuscado();
                        }
                        else
                        {
                            Console.WriteLine("Ingrese el filtro a utilizar:");
                            var filter = Console.ReadLine();

                            PagoBL.VerPagoBuscado(optionSearch,filter);
                        }
                        break;
                    case "4":
                        Console.Clear();
                        PagoBL.EliminarPago(pagos);
                        break;

                    case "5":
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
