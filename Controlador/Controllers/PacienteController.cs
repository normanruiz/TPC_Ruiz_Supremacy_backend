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
    public class PacienteController : ApiController
    {
        [HttpGet]
        public List<Paciente> Listar()
        {
            ServicioPaciente servicioPaciente;

            try
            {
                servicioPaciente = new ServicioPaciente();
                return servicioPaciente.Listar();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }
    }
}
