using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindMyRestaurantApi.Models
{
    public class Historial
    {
        public string Restaurante { get; set; }
        public string Usuario { get; set; }
        public string Puntuacion { get; set; }

        public List<Historial> SelectHistorial()
        {
            Data.dsMantenimientoTableAdapters.HistorialTableAdapter adapter = new Data.dsMantenimientoTableAdapters.HistorialTableAdapter();
            Data.dsMantenimiento.HistorialDataTable dt = adapter.SelectHistorial();

            var Historiales = new List<Historial>();
            if (dt.Rows.Count == 0)
                return Historiales;

            foreach (Data.dsMantenimiento.HistorialRow data in dt)
            {
                var Historial = new Historial();

                Historial.Restaurante = data.Restaurante;
                Historial.Usuario = data.Usuario;
                Historial.Puntuacion = data.Puntuacion.ToString();

                Historiales.Add(Historial);
            }

            return Historiales;
        }
    }
}