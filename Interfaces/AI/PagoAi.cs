using System;
using System.Collections.Generic;
using turipaq.entities_model;
using turipaq.Logic.LogicAdmin;

namespace turipaq.Interfaces.AI
{
    public class PagoAi
    {
        public static void MenuPago()
        {
            List<Pago> pagos = new List<Pago>();
            bool back = false;
            while (!back)
            {
                MostrarMenu();
                string option = LeerOpcion();

                switch (option)
                {
                    case "1":
                        AgregarPago(pagos);
                        break;
                    case "2":
                        VerTodosPagos();
                        break;
                    case "3":
                        BuscarPago();
                        break;
                    case "4":
                        EliminarPago();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        MostrarMensajeError("Opción no válida.");
                        break;
                }
            }
        }

        // Funciones auxiliares
        private static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("===== MENÚ DE PAGOS =====");
            Console.WriteLine("1. Agregar un nuevo pago");
            Console.WriteLine("2. Ver todos los pagos");
            Console.WriteLine("3. Buscar pago");
            Console.WriteLine("4. Eliminar un pago");
            Console.WriteLine("5. Volver al menú principal");
            Console.WriteLine("======================================");
        }

        private static string LeerOpcion()
        {
            Console.Write("Seleccione una opción: ");
            return Console.ReadLine();
        }

        private static void MostrarMensajeError(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private static void AgregarPago(List<Pago> pagos)
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Ingresa el id de la reserva que desea pagar");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int reservaId))
                {
                    throw new FormatException("El ID de reserva debe ser un número entero.");
                }

                if (reservaId <= 0)
                {
                    throw new ArgumentException("El ID de reserva debe ser mayor que cero.");
                }

                // Verificar si ya existe un pago para esta reserva
                if (pagos.Exists(p => p.ReservaId == reservaId))
                {
                    throw new InvalidOperationException($"Ya existe un pago para la reserva con ID {reservaId}.");
                }

                PagoBL.Pagar(pagos, reservaId);
            }
            catch (FormatException ex)
            {
                MostrarMensajeError($"Error de formato: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                MostrarMensajeError($"Error en los datos: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                MostrarMensajeError($"Error en la operación: {ex.Message}");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error inesperado: {ex.Message}");
            }
        }

        private static void VerTodosPagos()
        {
            Console.Clear();
            try
            {
                PagoBL.VerPagos();
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al mostrar los pagos: {ex.Message}");
            }
        }

        private static void BuscarPago()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Opción a utilizar para buscar el pago: 1. ID 2. ID reserva 3. ID cliente");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int optionSearch))
                {
                    throw new FormatException("La opción debe ser un número entero.");
                }

                if (optionSearch < 1 || optionSearch > 3)
                {
                    throw new ArgumentException("Opción de búsqueda no válida. Debe ser 1, 2 o 3.");
                }

                if (optionSearch == 1)
                {
                    PagoBL.VerPagoBuscado();
                }
                else
                {
                    Console.WriteLine("Ingrese el filtro a utilizar:");
                    string filter = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(filter))
                    {
                        throw new ArgumentException("El filtro no puede estar vacío.");
                    }

                    PagoBL.VerPagoBuscado(optionSearch, filter);
                }
            }
            catch (FormatException ex)
            {
                MostrarMensajeError($"Error de formato: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                MostrarMensajeError($"Error en los argumentos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error en la búsqueda: {ex.Message}");
            }
        }

        private static void EliminarPago()
        {
            Console.Clear();
            try
            {
                PagoBL.EliminarPago();
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al eliminar el pago: {ex.Message}");
            }
        }
    }
}