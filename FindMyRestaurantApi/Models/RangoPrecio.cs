﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindMyRestaurantApi.Models
{
    public class RangoPrecio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioMayor { get; set; }
        public decimal PrecioMedio { get; set; }
        public decimal PrecioMenor { get; set; }

        //public List<RangoPrecio> SelectRangoPrecios()
        //{
        //    Data.dsMantenimientoTableAdapters.RangoPreciosTableAdapter adapter = new Data.dsMantenimientoTableAdapters.RangoPreciosTableAdapter();
        //    Data.dsRangoPrecio.RangoPreciosDataTable dt = adapter.SelectRangoPrecios();

        //    var RangoPrecios = new List<RangoPrecio>();
        //    if (dt.Rows.Count == 0)
        //        return RangoPrecios;

        //    foreach (Data.dsRangoPrecio.RangoPreciosRow data in dt)
        //    {
        //        var RangoPrecio = new RangoPrecio();

        //        RangoPrecio.Id = data.IdRangoPrecio;
        //        RangoPrecio.Nombre = data.Nombre;
        //        RangoPrecio.PrecioMayor = data.PrecioMayor;
        //        RangoPrecio.PrecioMedio = data.PrecioMedio;
        //        RangoPrecio.PrecioMenor = data.PrecioMenor;

        //        RangoPrecios.Add(RangoPrecio);
        //    }

        //    return RangoPrecios;
        //}

        //public RangoPrecio SelectRangoPrecio(int? Id)
        //{
        //    Data.dsMantenimientoTableAdapters.RangoPrecioTableAdapter adapter = new Data.dsMantenimientoTableAdapters.RangoPrecioTableAdapter();
        //    Data.dsRangoPrecio.RangoPrecioDataTable dt = adapter.SelectRangoPrecio(Id);

        //    var RangoPrecio = new RangoPrecio();
        //    if (dt.Rows.Count == 0)
        //        return RangoPrecio;

        //    foreach (Data.dsRangoPrecio.RangoPrecioRow data in dt)
        //    {

        //        RangoPrecio.Id = data.IdRangoPrecio;
        //        RangoPrecio.Nombre = data.Nombre;
        //        RangoPrecio.PrecioMayor = data.PrecioMayor;
        //        RangoPrecio.PrecioMedio = data.PrecioMedio;
        //        RangoPrecio.PrecioMenor = data.PrecioMenor;

        //    }

        //    return RangoPrecio;
        //}

        //public void InsertRangoPrecio(string Nombre, decimal? PrecioMayor, decimal? PrecioMenor, decimal? PrecioMedio)
        //{
        //    Data.dsMantenimientoTableAdapters.RangoPreciosTableAdapter adapter = new Data.dsMantenimientoTableAdapters.RangoPreciosTableAdapter();
        //    adapter.InsertRangoPrecio(Nombre,PrecioMayor,PrecioMedio, PrecioMenor);
        //}

        //public void UpdateRangoPrecio(int? Id, string Nombre, decimal? PrecioMayor, decimal? PrecioMenor, decimal? PrecioMedio)
        //{
        //    Data.dsMantenimientoTableAdapters.RangoPreciosTableAdapter adapter = new Data.dsMantenimientoTableAdapters.RangoPreciosTableAdapter();
        //    adapter.UpdateRangoPrecio(Id, Nombre, PrecioMayor, PrecioMedio, PrecioMenor);
        //}

        //public void DeleteRangoPrecio(int? Id)
        //{
        //    Data.dsMantenimientoTableAdapters.RangoPreciosTableAdapter adapter = new Data.dsMantenimientoTableAdapters.RangoPreciosTableAdapter();
        //    adapter.DeleteRangoPrecio(Id);
        //}
    }
}