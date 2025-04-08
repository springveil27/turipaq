using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using turipaq.Logic;
using turipaq.entities_model;
namespace turipaq.AI
{
    class PaqueteAi
    {
     public static void Menupaq()
        {
            List<PaqueteTuristico> paquetes = new List<PaqueteTuristico>();

            bool backanother = true;
            while (backanother)
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ DE PAQUETES TURÍSTICOS =====");
                Console.WriteLine("1.Agregar un nuevo paquete");
                Console.WriteLine("2. Ver todos los paquetes ");
                Console.WriteLine("3. Buscar paquete");
                Console.WriteLine("4. Editar un paquete");
                Console.WriteLine("5. Eliminar un paquete");
                Console.WriteLine("6. Volver al menu principal");
                Console.WriteLine("======================================");
                Console.Write("Seleccione una opción: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        PaqueteBL.AgregarPaquete(paquetes);
                        break;

                    case "2":
                        Console.Clear();
                        PaqueteBL.verPaquetes(paquetes);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("opcion a utilizar para buscar el Paquete: 1. ID 2.Destino  3. Tipo de viaje 4 .duraccion");
                        var OptionSearch = int.Parse(Console.ReadLine());
                        if (OptionSearch == 1)
                        {

                            PaqueteBL.VerPaqueteBuscando();
                        }
                        else
                        {
                            Console.WriteLine("Ingrese la opcion a utilizar");
                            var filter = Console.ReadLine();

                            PaqueteBL.VerPaqueteBuscando(OptionSearch, filter);
                        }
                        
                        break;

                    case "4":
                        Console.Clear();
                        PaqueteBL.EditarPaquetes();
                        break;

                    case "5":
                        Console.Clear();
                        PaqueteBL.EliminarPaquete(paquetes);
                        break;

                    case "6":
                        
                        backanother = false;
                       
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
 
