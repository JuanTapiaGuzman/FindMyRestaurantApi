using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FindMyRestaurantApi.Models;

namespace FindMyRestaurantApi.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<string[]> Get()
        {
            var Usuario = new Usuario();
            var result = from c in Usuario.SelectUsuarios()
                         select new[] { c.Id.ToString(),
                                        c.Nombre,
                                        c.User,
                                        c.Email
                         };
            return result;
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
