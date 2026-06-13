using System;

namespace Hotel.Modelos
{
    public class Reserva
    {
        public string NombreCliente { get; private set; }
        public int NumeroHabitacion { get; private set; }
        public DateTime FechaIngreso { get; private set; }
        public int NumeroNoches { get; private set; }
        public decimal PrecioPorNoche { get; private set; }

        public Reserva(string nombreCliente, int numeroHabitacion, DateTime fechaIngreso, int numeroNoches, decimal precioPorNoche)
        {
            NombreCliente = nombreCliente;
            NumeroHabitacion = numeroHabitacion;
            FechaIngreso = fechaIngreso;
            NumeroNoches = numeroNoches;
            PrecioPorNoche = precioPorNoche;
        }

        public decimal CalcularTotal()
        {
            return NumeroNoches * PrecioPorNoche;
        }

        public string ConvertirAArchivo()
        {
            return $"{NombreCliente}|{NumeroHabitacion}|{FechaIngreso:yyyy-MM-dd}|{NumeroNoches}|{PrecioPorNoche}";
        }

        public static Reserva CrearDesdeArchivo(string linea)
        {
            string[] datos = linea.Split('|');
            return new Reserva(
                datos[0],
                int.Parse(datos[1]),
                DateTime.Parse(datos[2]),
                int.Parse(datos[3]),
                decimal.Parse(datos[4])
            );
        }

        public override string ToString()
        {
            return $"Cliente: {NombreCliente} | Habitación: {NumeroHabitacion} | Fecha ingreso: {FechaIngreso:dd/MM/yyyy} | Noches: {NumeroNoches} | Precio por noche: Q{PrecioPorNoche:F2} | Total: Q{CalcularTotal():F2}";
        }
    }
}
