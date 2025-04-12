using turipaq.Interfaces.AI;
using turipaq.Interfaces.UI;

namespace turipaq.Login
{
    public class LoginInterfaz
    {
        public static void iniciarSesion()
        {
            bool iniciar = true;
            while (iniciar)
            {
                bool running = true;

                {
                    Console.WriteLine("===== INICIAR SESION ====");
                    Console.Write("Usuario:");
                    string usuario = Console.ReadLine();
                    Console.Write("Contraseña:");
                    string contrasena = Console.ReadLine();

                    if (LogicLogin.Login(usuario, contrasena))
                    {
                        iniciar = false;
                        Console.WriteLine($"Bienvenido {LogicLogin.UsuarioIniciado.Nombre}\n");

                        if (LogicLogin.EsAdmin())
                        {
                            Console.WriteLine("Presiona enter para continuar");
                            Console.ReadKey();
                            Console.Clear();
                            MenuAdmin.MostrarMenuAdmin();

                        }
                        else
                        {
                            Console.WriteLine("Presiona enter para continuar");
                            Console.ReadKey();
                            Console.Clear();
                            ClienteUi.MenuCliente();
                        }
                    }
                    else
                    {
                        Console.WriteLine("usuario o contraseña incorrecta");
                        Console.ReadKey();
                        Console.Clear();
                    }


                }

            }
        }
    }
}
