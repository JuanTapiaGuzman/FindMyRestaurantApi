using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindMyRestaurantApi.Models
{
    public class Transporte
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //public List<Transporte> SelectTransportes()
        //{
        //    Data.dsMantenimientoTableAdapters.tr adapter = new Data.dsMantenimientoTableAdapters.TransportesTableAdapter();
        //    Data.dsMantenimiento.TransportesDataTable dt = adapter.SelectTransportes();

        //    var Transportes = new List<Transporte>();
        //    if (dt.Rows.Count == 0)
        //        return Transportes;

        //    foreach (Data.dsMantenimiento.TransportesRow data in dt)
        //    {
        //        var Transporte = new Transporte();

        //        Transporte.Id = data.IdTransporte;
        //        Transporte.Nombre = data.Nombre;

        //        Transportes.Add(Transporte);
        //    }

        //    return Transportes;
        //}

        //public Transporte SelectTransporte(int? Id)
        //{
        //    Data.dsMantenimientoTableAdapters.TransporteTableAdapter adapter = new Data.dsMantenimientoTableAdapters.TransporteTableAdapter();
        //    Data.dsMantenimiento.TransporteDataTable dt = adapter.SelectTransporte(Id);

        //    var Transporte = new Transporte();
        //    if (dt.Rows.Count == 0)
        //        return Transporte;

        //    foreach (Data.dsMantenimiento.TransporteRow data in dt)
        //    {

        //        Transporte.Id = data.IdTransporte;
        //        Transporte.Nombre = data.Nombre;

        //    }

        //    return Transporte;
        //}

        //public void InsertTransporte(string Nombre)
        //{
        //    Data.dsMantenimientoTableAdapters.TransportesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.TransportesTableAdapter();
        //    adapter.InsertTransporte(Nombre);
        //}

        //public void UpdateTransporte(int? Id, string Nombre)
        //{
        //    Data.dsMantenimientoTableAdapters.TransportesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.TransportesTableAdapter();
        //    adapter.UpdateTransporte(Id, Nombre);
        //}

        //public void DeleteTransporte(int? Id)
        //{
        //    Data.dsMantenimientoTableAdapters.TransportesTableAdapter adapter = new Data.dsMantenimientoTableAdapters.TransportesTableAdapter();
        //    adapter.DeleteTransporte(Id);
        //}
    }
}