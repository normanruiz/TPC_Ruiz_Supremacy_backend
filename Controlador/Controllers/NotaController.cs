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
    public class NotaController : ApiController
    {
        [HttpGet]
        public List<Nota> Listar()
        {
            ServicioNota servicioNota;

            try
            {
                servicioNota = new ServicioNota();
                return servicioNota.Listar();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPost]
        public bool Crear([FromBody]Nota nota)
        {
            ServicioNota servicioNota;
            try
            {
                servicioNota = new ServicioNota();
                return servicioNota.AgregarNuevo(nota);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPut]
        public bool Put(int Id, [FromBody]Nota nota)
        {
            ServicioNota servicioNota;
            try
            {
                nota.Id = Id;
                servicioNota = new ServicioNota();
                return servicioNota.GuardarModificado(nota);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpDelete]
        public bool Delete(int Id)
        {
            ServicioNota servicioNota;
            try
            {
                servicioNota = new ServicioNota();
                return servicioNota.EliminarFisico(Id);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }
    }
}