using turipaq.Login;
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
            try
            {
                var context = new DataContext();
                List<Reserva> reservas = context.Reservas.ToList();
                List<PaqueteTuristico> paquetes = new List<PaqueteTuristico>();
                bool back = false;
                while (!back)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("===== MENÚ DE CLIENTE =====");
                        Console.WriteLine("1. Ver mi perfil");
                        Console.WriteLine("2. Editar mi perfil");
                        Console.WriteLine("3. Hacer una reserva");
                        Console.WriteLine("4. Ver mis reservas");
                        Console.WriteLine("5. ver mi pagos");
                        Console.WriteLine("6. Cerrar sesión");
                        Console.WriteLine("======================================");
                        Console.Write("Seleccione una opción: ");
                        int option = Convert.ToInt32(Console.ReadLine());
                        var usuarioActual = LogicLogin.UsuarioIniciado;

                        switch (option)
                        {
                            case 1:
                                try
                                {
                                    Console.Clear();
                                    VistaCliente.VerClienteBuscado();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al ver el perfil: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case 2:
                                try
                                {
                                    Console.Clear();
                                    VistaCliente.EditarCliente();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al editar el perfil: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case 3:
                                try
                                {
                                    Console.Clear();
                                    ReservaCliente.CrearReserva(reservas, paquetes);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al crear la reserva: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case 4:
                                try
                                {
                                    ReservaCliente.VerMiReserva(reservas);
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al ver las reservas: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                break;
                            case 5:
                                try
                                {
                                    VistaCliente.VerPagoBuscado();
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al ver los pagos: {ex.Message}");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey();
                                }
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
                Console.WriteLine($"Error al inicializar: {ex.Message}");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}