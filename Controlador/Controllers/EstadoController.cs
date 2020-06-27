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
    public class EstadoController : ApiController
    {
        [HttpGet]
        public List<Estado> Listar()
        {
            ServicioEstado servicioEstado;

            try
            {
                servicioEstado = new ServicioEstado();
                return servicioEstado.Listar();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPost]
        public bool Crear([FromBody]Estado estado)
        {
            ServicioEstado servicioEstado;
            try
            {
                servicioEstado = new ServicioEstado();
                return servicioEstado.AgregarNuevo(estado);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPut]
        public bool Put(int Id, [FromBody]Estado estado)
        {
            ServicioEstado servicioEstado;
            try
            {
                estado.Id = Id;
                servicioEstado = new ServicioEstado();
                return servicioEstado.GuardarModificado(estado);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpDelete]
        public bool Delete(int Id)
        {
            ServicioEstado servicioEstado;
            try
            {
                servicioEstado = new ServicioEstado();
                return servicioEstado.EliminarFisico(Id);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }
    }
}
