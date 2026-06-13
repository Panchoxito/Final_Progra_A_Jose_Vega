using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hotel.Modelos
{
    public class Hotel
    {
        private readonly List<Reserva> reservas;
        private readonly string rutaArchivo;

        public Hotel(string rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;
            reservas = new List<Reserva>();
            CargarReservas();
        }

        public void RegistrarReserva(Reserva reserva)
        {
            reservas.Add(reserva);
            GuardarReservas();
        }

        public List<Reserva> ObtenerReservas()
        {
            return reservas;
        }

        public decimal CalcularIngresoTotalEsperado()
        {
            decimal total = 0;
            foreach (Reserva reserva in reservas)
            {
                total += reserva.CalcularTotal();
            }
            return total;
        }

        public Reserva? ObtenerReservaMayorDuracion()
        {
            if (reservas.Count == 0)
            {
                return null;
            }

            return reservas.OrderByDescending(reserva => reserva.NumeroNoches).First();
        }

        private void GuardarReservas()
        {
            List<string> lineas = new List<string>();

            foreach (Reserva reserva in reservas)
            {
                lineas.Add(reserva.ConvertirAArchivo());
            }

            File.WriteAllLines(rutaArchivo, lineas);
        }

        private void CargarReservas()
        {
            if (!File.Exists(rutaArchivo))
            {
                return;
            }

            string[] lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    reservas.Add(Reserva.CrearDesdeArchivo(linea));
                }
            }
        }
    }
}
