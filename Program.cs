using turipaq.Login;
using turipaq.entities_model;
using turipaq.Logic.LogicUser;

bool running = true;
while (running)
{
    try
    {

    Console.Clear();
    List<Cliente> clientes = new List<Cliente>();
    Console.WriteLine("===== TURIPAQ =====");
    Console.WriteLine(@"1. Iniciar sesion
2. Crear Cuenta 
3. Cerrar Aplicacion");
    Console.WriteLine("======================================");
    Console.Write("Seleccione una opción: ");

    int opcion = Convert.ToInt32(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.Clear();
            LoginInterfaz.iniciarSesion();
            break;
        case 2:
            Console.Clear();
            VistaCliente.CrearCuenta(clientes);
            break;

        case 3:
            running = false;
            break;
        default:
            Console.Clear();
                Console.WriteLine("INGRESA UN NUMERO VALIDO\n");
                Console.WriteLine("Presiona ENTER para continuar");
                Console.ReadKey();
                break;
    }
    }catch(Exception ex)
                            {
        Console.Clear();
        Console.WriteLine("ERROR: El programa solo permite numero\n");
        Console.WriteLine("Presiona ENTER para continuar");
        Console.ReadKey();

}

}