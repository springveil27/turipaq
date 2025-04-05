using System;
using System.Linq;
using System.Runtime.CompilerServices;
using turipaq.Business_Logic;
using turipaq.entities_model;
using turipaq.Database;


namespace turipaq.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PaqueteTuristico> paquetes = new List<PaqueteTuristico>();

            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ DE PAQUETES TURÍSTICOS =====");
                Console.WriteLine("1.Agregar un nuevo paquete");
                Console.WriteLine("2. Ver todos los paquetes ");
                Console.WriteLine("3. Buscar paquete");
                Console.WriteLine("4. Editar un paquete");
                Console.WriteLine("5. Eliminar un paquete");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        PaqueteBL.AgregarPaquete(paquetes);
                        break;

                    case "2":
                        PaqueteBL.verPaquetes(paquetes);
                        break;

                    case "3":
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
                        PaqueteBL.EditarPaquetes();
                        break;

                    case "5":
                        PaqueteBL.EliminarPaquete(paquetes);
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
 
