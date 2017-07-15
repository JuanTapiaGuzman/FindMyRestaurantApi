using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FindMyRestaurantApi.Models;

namespace FindMyRestaurantApi.Controllers
{
    public class RestauranteController : ApiController
    {
        // GET: api/Restaurante
        public IEnumerable<string[]> Get()
        {
            var Restaurante = new Restaurante();
            var result = from c in Restaurante.SelectRestaurantes()
                         select new[] { c.Nombre,
                                        c.LatitudGps,
                                        c.LongitudGps,
                                        c.Direccion,
                                        c.Telefono
                         };
            return result;
        }

        // GET: api/Restaurante/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Restaurante
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Restaurante/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Restaurante/5
        public void Delete(int id)
        {
        }
    }
}
