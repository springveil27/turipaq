﻿using System.Transactions;
using turipaq.Database;
using turipaq.entities_model;

namespace turipaq.Logic.LogicAdmin
{
    public class PagoBL
    {
        public static void Pagar(List<Pago>pagos, int reservaId)
        {
            try
            {
                using (var context = new DataContext())
                {
                    var reserva = context.Reservas.Find(reservaId);
                    if (reserva == null)
                    {
                        Console.WriteLine("Error: No se encontró la reserva especificada.");
                        return;
                    }

                    var monto = context.Paquete_Turisticos.Find(reserva.PaqueteId);
                    if (monto == null)
                    {
                        Console.WriteLine("Error: No se encontró el paquete turístico asociado a la reserva.");
                        return;
                    }

                    Console.WriteLine("===== REGISTRAR PAGO =====");
                    Console.Write("Metodo de pago 1.Tarjeta 2.Efectivo 3.Transferencia: ");
                    var metodoPago = Convert.ToInt32(Console.ReadLine());

                    DateTime fechaPago = DateTime.Now;

                    do
                    {
                        Pago pago = null;
                        if (metodoPago == 1)
                        {
                            pago = new Pago()
                            {
                                MetodoPago = "Tarjeta",
                                Monto = monto.Precio,
                                FechaPago = fechaPago,
                                ReservaId = reservaId
                            };
                        }
                        else if (metodoPago == 2)
                        {
                            pago = new Pago()
                            {
                                MetodoPago = "Efectivo",
                                Monto = monto.Precio,
                                FechaPago = fechaPago,
                                ReservaId = reservaId
                            };
                        }
                        else if (metodoPago == 3)
                        {
                            pago = new Pago()
                            {
                                MetodoPago = "Transferencia",
                                Monto = monto.Precio,
                                FechaPago = fechaPago,
                                ReservaId = reservaId
                            };
                        }
                        else
                        {
                            Console.WriteLine("Selecciona una opción válida");
                            continue;
                        }

                        context.Pagos.Add(pago);
                        context.SaveChanges();
                        Console.WriteLine("Pago realizado exitosamente");
                        break;

                    } while (metodoPago != 1 && metodoPago != 2 && metodoPago != 3);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El formato de entrada no es válido. Por favor, ingrese un número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar el pago: {ex.Message}");
            }
        }

        public static void VerPagoEnPantalla()
        {
            var context = new DataContext();
            var pagos = context.Pagos.ToList();

            foreach (var pago in pagos)
            {
                Console.WriteLine($"|ID: {pago.PagoId} | ID de reserva: {pago.ReservaId} | monto a pagado: {pago.Monto} | metodo: {pago.MetodoPago} | fecha de pago: {pago.FechaPago}|");
            }
        }

        public static void VerPagoBuscado()
        {
            var context = new DataContext();
            var pago = BuscarPago();
            VerPagoEnPantalla();
        }

        public static void VerPagoBuscado(int optionSearch, string searchTerm)
        {
            var pagos = BuscarPago(optionSearch, searchTerm);
            VerPagoEnPantalla();
        }

        public static Pago BuscarPago()
        {
            var context = new DataContext();
            Console.WriteLine("Digite un Id de Pago para mostrar:");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var pago = context.Pagos.FirstOrDefault(p => p.PagoId == selectedId);
            return pago;
        }

        public static List<Pago> BuscarPago(int optionSearch, string searchTerm)
        {
           try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    Console.WriteLine("Error: El término de búsqueda no puede estar vacío.");
                    return new List<Pago>();
                }

                using (var context = new DataContext())
                {
                    List<Pago> pagosSeleccionados = new List<Pago>();

                    switch (optionSearch)
                    {
                        case 2:
                            pagosSeleccionados = context.Pagos
                                .Where(p => p.MetodoPago.ToLower().Contains(searchTerm.ToLower()))
                                .ToList();
                            break;
                        case 3:
                            pagosSeleccionados = context.Pagos
                                .Where(p => p.FechaPago.ToString().ToLower().Contains(searchTerm.ToLower()))
                                .ToList();
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }

                    if (pagosSeleccionados.Count == 0)
                    {
                        Console.WriteLine("No se encontraron pagos con los criterios especificados.");
                    }

                    return pagosSeleccionados;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar pagos: {ex.Message}");
                return new List<Pago>();
            }
        }

        public static void VerPagos()
        {
            var context = new DataContext();
            var pagos = context.Pagos.ToList();
            VerPagoEnPantalla();
        }



        public static void EliminarPago()
        {
            try
            {
                using (var context = new DataContext())
                {
                    Console.WriteLine("Digite un ID de pago para eliminar:");
                    int selectedId = Convert.ToInt32(Console.ReadLine());

                    var pago = context.Pagos.FirstOrDefault(p => p.PagoId == selectedId);

                    if (pago == null)
                    {
                        Console.WriteLine("No se encontró ningún pago con el ID especificado.");
                        return;
                    }

                    Console.WriteLine("¿Seguro que desea eliminar? 1. Sí 2. No");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    if (opcion == 1)
                    {
                        context.Pagos.Remove(pago);
                        context.SaveChanges();
                        Console.WriteLine("Pago eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Eliminación cancelada.");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el pago: {ex.Message}");
            }
        }
    }
}
