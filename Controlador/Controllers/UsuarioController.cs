using Modelo;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Controlador.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        public List<Usuario> Listar()
        {
            ServicioUsuario servicioUsuario;

            try
            {
                servicioUsuario = new ServicioUsuario();
                return servicioUsuario.Listar();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPost]
        [Route("api/usuario/registrarse")]
        public Usuario Registrarse([FromBody]Usuario usr)
        {
            ServicioUsuario servicioUsuario;

            try
            {
                servicioUsuario = new ServicioUsuario();
                return servicioUsuario.Registrarse(usr);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPost]
        public bool Crear([FromBody]Usuario usuario)
        {
            ServicioUsuario servicioUsuario;
            try
            {
                servicioUsuario = new ServicioUsuario();
                return servicioUsuario.AgregarNuevo(usuario);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPut]
        public bool Put(int Id, [FromBody]Usuario usuario)
        {
            ServicioUsuario servicioUsuario;
            try
            {
                usuario.Id = Id;
                servicioUsuario = new ServicioUsuario();
                return servicioUsuario.GuardarModificado(usuario);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpDelete]
        public bool Delete(int Id)
        {
            ServicioUsuario servicioUsuario;
            try
            {
                servicioUsuario = new ServicioUsuario();
                return servicioUsuario.EliminarFisico(Id);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }
    }
}
