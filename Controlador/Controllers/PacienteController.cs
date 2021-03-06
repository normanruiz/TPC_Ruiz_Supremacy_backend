﻿using Modelo;
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
    [EnableCors(origins: "*",headers:"*", methods:"*")]
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

        [HttpPost]
        public bool Crear([FromBody]Paciente paciente)
        {
            ServicioPaciente servicioPaciente;
            try
            {
                servicioPaciente = new ServicioPaciente();
                return servicioPaciente.AgregarNuevo(paciente);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPut]
        public bool Put(int Id, [FromBody]Paciente paciente)
        {
            ServicioPaciente servicioPaciente;
            try
            {
                paciente.Id = Id;
                servicioPaciente = new ServicioPaciente();
                return servicioPaciente.GuardarModificado(paciente);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpDelete]
        public bool Delete(int Id)
        {
            ServicioPaciente servicioPaciente;
            try
            {
                servicioPaciente = new ServicioPaciente();
                return servicioPaciente.EliminarFisico(Id);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }
    }
}
