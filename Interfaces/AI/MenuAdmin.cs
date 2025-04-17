namespace turipaq.Interfaces.AI
{
public class MenuAdmin
    {

        public static void MostrarMenuAdmin()
        {

            try
            {
                bool running = true;
                while (running)
                {
                    try
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
                                try
                                {
                                    PaqueteAi.Menupaq();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error en gestión de paquetes: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case 2:
                                try
                                {
                                    ReservaAi.MenuReserva();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error en gestión de reservas: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case 3:
                                try
                                {
                                    ClienteAi.MenuCliente();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error en gestión de clientes: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case 4:
                                try
                                {
                                    PagoAi.MenuPago();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error en procesamiento de pagos: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
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
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Por favor ingrese un número válido.");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inesperado: {ex.Message}");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error crítico en el menú de administrador: {ex.Message}");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }



}

