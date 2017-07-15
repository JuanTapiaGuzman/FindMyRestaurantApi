using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindMyRestaurantApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; } 
        public string Contraseña { get; set; } 
        public string Nombre { get; set; } 
        public string Email { get; set; } 
        public int IdTransporte { get; set; }

        public List<Usuario> SelectUsuarios()
        {
            Data.dsMantenimientoTableAdapters.UsuariosTableAdapter adapter = new Data.dsMantenimientoTableAdapters.UsuariosTableAdapter();
            Data.dsMantenimiento.UsuariosDataTable dt = adapter.SelectUsuarios();

            var Usuarios = new List<Usuario>();
            if (dt.Rows.Count == 0)
                return Usuarios;

            foreach (Data.dsMantenimiento.UsuariosRow data in dt)
            {
                var Usuario = new Usuario();

                Usuario.Id = data.IdUsuario;
                Usuario.User = data.Usuario;
                Usuario.Nombre = data.Nombre;
                Usuario.Contraseña = data.Contraseña;
                Usuario.Email = data.Email;
                Usuario.IdTransporte = data.IdTransporte;

                Usuarios.Add(Usuario);
            }

            return Usuarios;
        }

        public Usuario SelectUsuario(int? Id)
        {
            Data.dsMantenimientoTableAdapters.UsuariosTableAdapter adapter = new Data.dsMantenimientoTableAdapters.UsuariosTableAdapter();
            Data.dsMantenimiento.UsuariosDataTable dt = adapter.SelectUsuario(Id);

            var Usuario = new Usuario();
            if (dt.Rows.Count == 0)
                return Usuario;

            foreach (Data.dsMantenimiento.UsuariosRow data in dt)
            {

                Usuario.Id = data.IdUsuario;
                Usuario.User = data.Usuario;
                Usuario.Nombre = data.Nombre;
                Usuario.Contraseña = data.Contraseña;
                Usuario.Email = data.Email;
                Usuario.IdTransporte = data.IdTransporte;

            }

            return Usuario;
        }

        public void InsertUsuario(string User, string Contraseña, string Nombre, string Email, int IdTransporte)
        {
            Data.dsMantenimientoTableAdapters.UsuariosTableAdapter adapter = new Data.dsMantenimientoTableAdapters.UsuariosTableAdapter();
            adapter.InsertUsuario(Nombre, User, Contraseña, Email, IdTransporte);
        }

        public void UpdateUsuario(string User, string Contraseña, string Nombre, string Email, int IdTransporte)
        {
            Data.dsMantenimientoTableAdapters.UsuariosTableAdapter adapter = new Data.dsMantenimientoTableAdapters.UsuariosTableAdapter();
            adapter.UpdateUsuario(Id, Nombre, User, Contraseña, Email, IdTransporte);
        }

        public void DeleteUsuario(int? Id)
        {
            Data.dsMantenimientoTableAdapters.UsuariosTableAdapter adapter = new Data.dsMantenimientoTableAdapters.UsuariosTableAdapter();
            adapter.DeleteUsuario(Id);
        }
    }
}