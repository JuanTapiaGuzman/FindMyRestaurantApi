using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FindMyRestaurantApi.Models;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace FindMyRestaurantApi.Controllers
{
    public class RecommendationController : ApiController
    {
        // GET: api/Historial
        public IEnumerable<string[]> Get()
        {
            var Historial = new Historial();
            var result = from c in Historial.SelectRecommendations("01")
                         select new[] { c.Usuario,
                                        c.Restaurante,
                                        c.Puntuacion
                         };
            return result;
        }

        // GET: api/Historial/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Historial
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Historial/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Historial/5
        public void Delete(int id)
        {
        }
    }
}
