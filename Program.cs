using System;
using turipaq.Logic;
using turipaq.Login;
using turipaq.entities_model;
using Microsoft.EntityFrameworkCore;
using turipaq.entities_model;

bool running = true;
while (running)
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
            VistaCliente.CrearCuenta(clientes);
            break;

        case 3:
            running = false;
            break;
    }

}