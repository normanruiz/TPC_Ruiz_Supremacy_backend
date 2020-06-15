﻿using Servicio;
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

    }
}
