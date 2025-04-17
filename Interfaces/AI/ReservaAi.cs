using turipaq.entities_model;
using turipaq.Logic.LogicAdmin;

namespace turipaq.Interfaces.AI
{
    public class ReservaAi
    {
        public static void MenuReserva()
        {
            List<Reserva> reservas = new List<Reserva>();

            bool back = false;
            while (!back)
            {
                 try
                {
                    Console.Clear();
                    Console.WriteLine("===== MENÚ DE RESERVAS =====");
                    Console.WriteLine("1. Agregar una nueva reserva");
                    Console.WriteLine("2. Ver todas las reservas");
                    Console.WriteLine("3. Buscar reserva");
                    Console.WriteLine("4. Eliminar una reserva");
                    Console.WriteLine("5. Volver al menú principal");
                    Console.WriteLine("======================================");
                    Console.Write("Seleccione una opción: ");
                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            Console.Clear();
                            try
                            {
                                ReservaBL.AgregarReserva(reservas);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error al agregar la reserva: {ex.Message}");
                                Console.ReadKey();
                            }
                            break;

                        case "2":
                            Console.Clear();
                            try
                            {
                                ReservaBL.VerReservas(reservas);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error al ver las reservas: {ex.Message}");
                                Console.ReadKey();
                            }
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Opción a utilizar para buscar la reserva: 1. ID  2. ID paquete  3. ID cliente");
                            try
                            {
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
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Debe ingresar un número válido.");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error al buscar reserva: {ex.Message}");
                                Console.ReadKey();
                            }
                            break;

                        case "4":
                            Console.Clear();
                            try
                            {
                                ReservaBL.EliminarReserva(reservas);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error al eliminar reserva: {ex.Message}");
                                Console.ReadKey();
                            }
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }
    }
            }
