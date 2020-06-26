using Servicio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Controlador.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MedicoController : ApiController
    {
        [HttpGet]
        public List<Medico> Listar()
        {
            ServicioMedico servicioMedico;

            try
            {
                servicioMedico = new ServicioMedico();
                return servicioMedico.Listar();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPost]
        public bool Crear([FromBody]Medico medico)
        {
            ServicioMedico servicioMedico;
            try
            {
                servicioMedico = new ServicioMedico();
                return servicioMedico.AgregarNuevo(medico);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPut]
        public bool Modificar(int Id, [FromBody]Medico medico)
        {
            ServicioMedico servicioMedico;
            try
            {
                medico.Id = Id;
                servicioMedico = new ServicioMedico();
                return servicioMedico.GuardarModificado(medico);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpDelete]
        public bool Eliminar(int Id)
        {
            ServicioMedico servicioMedico;
            try
            {
                servicioMedico = new ServicioMedico();
                return servicioMedico.EliminarFisico(Id);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

    }
}
