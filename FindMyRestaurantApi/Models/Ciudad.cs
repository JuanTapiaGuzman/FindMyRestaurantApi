using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindMyRestaurantApi.Models
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Ciudad> SelectCiudades()
        {
            Data.dsMantenimientoTableAdapters.CiudadesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.CiudadesTableAdapter();
            Data.dsMantenimiento.CiudadesDataTable dt = adapter.SelectCiudades();

            var Ciudades = new List<Ciudad>();
            if (dt.Rows.Count == 0)
                return Ciudades;

            foreach(Data.dsMantenimiento.CiudadesRow data in dt)
            {
                var Ciudad = new Ciudad();

                Ciudad.Id = data.IdCiudad;
                Ciudad.Nombre = data.Nombre;

                Ciudades.Add(Ciudad);
            }

            return Ciudades;
        }

        public Ciudad SelectCiudad(int? Id)
        {
            Data.dsMantenimientoTableAdapters.CiudadesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.CiudadesTableAdapter();
            Data.dsMantenimiento.CiudadesDataTable dt = adapter.SelectCiudad(Id);

            var Ciudad = new Ciudad();
            if (dt.Rows.Count == 0)
                return Ciudad;

            foreach (Data.dsMantenimiento.CiudadesRow data in dt)
            {

                Ciudad.Id = data.IdCiudad;
                Ciudad.Nombre = data.Nombre;

            }

            return Ciudad;
        }

        public void InsertCiudad(string Nombre)
        {
            Data.dsMantenimientoTableAdapters.CiudadesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.CiudadesTableAdapter();
            adapter.InsertCiudad(Nombre);
        }

        public void UpdateCiudad(int? Id, string Nombre)
        {
            Data.dsMantenimientoTableAdapters.CiudadesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.CiudadesTableAdapter();
            adapter.UpdateCiudad(Id, Nombre);
        }

        public void DeleteCiudad(int? Id)
        {
            Data.dsMantenimientoTableAdapters.CiudadesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.CiudadesTableAdapter();
            adapter.DeleteCiudad(Id);
        }
    }
}