using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindMyRestaurantApi.Models
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoRestaurante { get; set; }
        public int IdRangoPrecio { get; set; }
        public string Direccion { get; set; }
        public int IdCiudad { get; set; }
        public string Telefono { get; set; } 
        public string LatitudGps { get; set; }
        public string LongitudGps { get; set; }

        public List<Restaurante> SelectRestaurantes()
        {
            Data.dsMantenimientoTableAdapters.RestaurantesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.RestaurantesTableAdapter();
            Data.dsMantenimiento.RestaurantesDataTable dt = adapter.SelectRestaurantes();

            var Restaurantes = new List<Restaurante>();
            if (dt.Rows.Count == 0)
                return Restaurantes;

            foreach (Data.dsMantenimiento.RestaurantesRow data in dt)
            {
                var Restaurante = new Restaurante();

                Restaurante.Id = data.IdRestaurante;
                Restaurante.Nombre = data.Nombre;
                Restaurante.IdTipoRestaurante = data.IdTipoRestaurante;
                Restaurante.IdRangoPrecio = data.IdRangoPrecio;
                Restaurante.Direccion = data.Direccion;
                Restaurante.IdCiudad = data.IdCiudad;
                Restaurante.Telefono = data.Telefono;
                Restaurante.LatitudGps = data.LatitudGps;
                Restaurante.LongitudGps = data.LongitudGps;

                Restaurantes.Add(Restaurante);
            }

            return Restaurantes;
        }

        public Restaurante SelectRestaurante(int? Id)
        {
            Data.dsMantenimientoTableAdapters.RestaurantesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.RestaurantesTableAdapter();
            Data.dsMantenimiento.RestaurantesDataTable dt = adapter.SelectRestaurante(Id);

            var Restaurante = new Restaurante();
            if (dt.Rows.Count == 0)
                return Restaurante;

            foreach (Data.dsMantenimiento.RestaurantesRow data in dt)
            {

                Restaurante.Id = data.IdRestaurante;
                Restaurante.Nombre = data.Nombre;
                Restaurante.IdTipoRestaurante = data.IdTipoRestaurante;
                Restaurante.IdRangoPrecio = data.IdRangoPrecio;
                Restaurante.Direccion = data.Direccion;
                Restaurante.IdCiudad = data.IdCiudad;
                Restaurante.Telefono = data.Telefono;
                Restaurante.LatitudGps = data.LatitudGps;
                Restaurante.LongitudGps = data.LongitudGps;

            }

            return Restaurante;
        }

        public void InsertRestaurante(string Nombre, int IdTipoRestaurante, int IdRangoPrecio, string Direccion, int IdCiudad, string Telefono, string LatitudGps, string LongitudGps)
        {
            Data.dsMantenimientoTableAdapters.RestaurantesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.RestaurantesTableAdapter();
            adapter.InsertRestaurante(Nombre, IdTipoRestaurante, IdRangoPrecio, Direccion, IdCiudad, Telefono, LatitudGps, LongitudGps);
        }

        public void UpdateRestaurante(int? Id, string Nombre, int IdTipoRestaurante, int IdRangoPrecio, string Direccion, int IdCiudad, string Telefono, string LatitudGps, string LongitudGps)
        {
            Data.dsMantenimientoTableAdapters.RestaurantesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.RestaurantesTableAdapter();
            adapter.UpdateRestaurante(Id, Nombre, IdTipoRestaurante, IdRangoPrecio, Direccion, IdCiudad, Telefono, LatitudGps, LongitudGps);
        }

        public void DeleteRestaurante(int? Id)
        {
            Data.dsMantenimientoTableAdapters.RestaurantesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.RestaurantesTableAdapter();
            adapter.DeleteRestaurante(Id);
        }
    }
}