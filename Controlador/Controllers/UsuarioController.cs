using Modelo;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Controlador.Controllers
{
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
    }
}
