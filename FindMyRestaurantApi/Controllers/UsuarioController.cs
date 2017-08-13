using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using FindMyRestaurantApi.Models;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace FindMyRestaurantApi.Controllers
{
    public class UsuarioController : ApiController
    {
        /// <summary>
        /// Obtener listado de usuarios
        /// </summary>
        /// <returns></returns>
        // GET: api/Usuario
        public string Get()
        {
            var Usuario = new Usuario().SelectUsuarios();

            var result = JsonConvert.SerializeObject(Usuario);

            return result;
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            var modelo = new Usuario().SelectUsuario(id);
            var json = new Usuario();

            json.Id = modelo.Id;
            json.User = modelo.User;
            json.Nombre = modelo.Nombre;
            json.Contraseña = modelo.Contraseña;
            json.Email = modelo.Email;
            json.IdTransporte = modelo.IdTransporte;

            string result = JsonConvert.SerializeObject(json);

            return result;
        }

        /// <summary>
        /// Validar datos de usuario en login
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        // GET: api/Usuario/
        public IHttpActionResult Get(string usuario, string password)
        {
            var Usuario = new Usuario();

            if(Usuario.ValidarUsuario(usuario, password))
            {
                var userModel = Usuario.SelectUsuario(usuario, password);

                var json = JsonConvert.SerializeObject(userModel);

                Ok();

                return base.Content(HttpStatusCode.OK, json, new JsonMediaTypeFormatter(), "text/plain");
            }
            else
            {
                NotFound();

                return base.Content(HttpStatusCode.OK, new { }, new JsonMediaTypeFormatter(), "text/plain");
            }
        }

        public HttpResponseMessage PostUsuario(Usuario value)
        {
            if (ModelState.IsValid)
            {
                var model = new Usuario();
                model.InsertUsuario(value.User, value.Contraseña, value.Nombre, value.Email, value.IdTransporte);

                HttpResponseMessage response =
                Request.CreateResponse(HttpStatusCode.Created, value);

                response.Headers.Location = new Uri(Url.Link("DefaultApi", new
                {
                    id = value.Id
                }));

                return response;

            }
            else
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                ModelState);

            }
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]Usuario usuario)
        {
            var model = new Usuario();
            model.UpdateUsuario(id, usuario.User, usuario.Contraseña, usuario.Nombre, usuario.Email, usuario.IdTransporte);
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
            var usuario = new Usuario();
            usuario.DeleteUsuario(id);
        }
    }
}
