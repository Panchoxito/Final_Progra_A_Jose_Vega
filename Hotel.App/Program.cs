using System;
using Hotel.Modelos;

namespace Hotel.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Hotel.Modelos.Hotel hotel = new Hotel.Modelos.Hotel("reservas.txt");
            int opcion;

            do
            {
                Console.Clear();
              
                Console.WriteLine(" Sistema de Hotel Los Arcos");
               
                Console.WriteLine("1. Registrar una nueva reserva");
                Console.WriteLine("2. Listar todas las reservas");
                Console.WriteLine("3. Calcular ingreso total esperado");
                Console.WriteLine("4. Mostrar reserva de mayor duración");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        RegistrarReserva(hotel);
                        break;
                    case 2:
                        ListarReservas(hotel);
                        break;
                    case 3:
                        MostrarIngresoTotal(hotel);
                        break;
                    case 4:
                        MostrarReservaMayorDuracion(hotel);
                        break;
                    case 5:
                        Console.WriteLine("Gracias por utilizar el sistema.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        private static void RegistrarReserva(Hotel.Modelos.Hotel hotel)
        {
            Console.WriteLine("REGISTRAR NUEVA RESERVA");
            Console.WriteLine("-----------------------");

            Console.Write("Nombre del cliente: ");
            string nombreCliente = Console.ReadLine() ?? string.Empty;

            int numeroHabitacion = LeerEntero("Número de habitación: ");
            DateTime fechaIngreso = LeerFecha("Fecha de ingreso (dd/mm/aaaa): ");
            int numeroNoches = LeerEntero("Número de noches: ");
            decimal precioPorNoche = LeerDecimal("Precio por noche: Q");

            Reserva reserva = new Reserva(nombreCliente, numeroHabitacion, fechaIngreso, numeroNoches, precioPorNoche);
            hotel.RegistrarReserva(reserva);

            Console.WriteLine();
            Console.WriteLine("Reserva registrada correctamente.");
        }

        private static void ListarReservas(Hotel.Modelos.Hotel hotel)
        {
            Console.WriteLine("LISTADO DE RESERVAS");
            Console.WriteLine("-------------------");

            if (hotel.ObtenerReservas().Count == 0)
            {
                Console.WriteLine("No existen reservas registradas.");
                return;
            }

            foreach (Reserva reserva in hotel.ObtenerReservas())
            {
                Console.WriteLine(reserva);
            }
        }

        private static void MostrarIngresoTotal(Hotel.Modelos.Hotel hotel)
        {
            Console.WriteLine("INGRESO TOTAL ESPERADO");
            Console.WriteLine("----------------------");
            Console.WriteLine($"Total esperado: Q{hotel.CalcularIngresoTotalEsperado():F2}");
        }

        private static void MostrarReservaMayorDuracion(Hotel.Modelos.Hotel hotel)
        {
            Console.WriteLine("RESERVA DE MAYOR DURACIÓN");
            Console.WriteLine("-------------------------");

            Reserva? reserva = hotel.ObtenerReservaMayorDuracion();

            if (reserva == null)
            {
                Console.WriteLine("No existen reservas registradas.");
            }
            else
            {
                Console.WriteLine(reserva);
            }
        }

        private static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            {
                Console.Write("Ingrese un número entero válido mayor que cero: ");
            }
            return valor;
        }

        private static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            {
                Console.Write("Ingrese un valor decimal válido mayor que cero: ");
            }
            return valor;
        }

        private static DateTime LeerFecha(string mensaje)
        {
            DateTime fecha;
            Console.Write(mensaje);
            while (!DateTime.TryParse(Console.ReadLine(), out fecha))
            {
                Console.Write("Ingrese una fecha válida: ");
            }
            return fecha;
        }
    }
}
