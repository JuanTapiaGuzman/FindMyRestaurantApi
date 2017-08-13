using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FindMyRestaurantApi.Models;
using Newtonsoft.Json;

namespace FindMyRestaurantApi.Controllers
{
    public class RestauranteController : ApiController
    {
        // GET: api/Restaurante
        public string Get()
        {
            var restaurante = new Restaurante().SelectRestaurantes();

            var result = JsonConvert.SerializeObject(restaurante);

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
